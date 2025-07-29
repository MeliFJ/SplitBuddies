using Controlador;
using Controlador.Interfaces;
using GestorDatos.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WfVistaSplitBuddies.Vista
{
    /// <summary>
    /// Formulario para la gestión y registro de gastos dentro de un grupo.
    /// Permite seleccionar integrantes, registrar quién pagó, agregar montos y guardar la información del gasto.
    /// </summary>
    public partial class FormGastos : Form
    {
        /// <summary>
        /// Grupo al que pertenece el gasto.
        /// </summary>
        private Grupo Grupo;

        /// <summary>
        /// Usuario actualmente logueado.
        /// </summary>
        private Usuario usuarioLogeado;

        /// <summary>
        /// Controlador encargado de la gestión de gastos.
        /// </summary>
        private IGastosControlador gastosControlador;

        /// <summary>
        /// Controlador encargado de la gestión de grupos.
        /// </summary>
        private IGrupoControlador grupoControlador;

        /// <summary>
        /// Monto total acumulado de los gastos ingresados.
        /// </summary>
        private double montoTotal;

        /// <summary>
        /// Lista de usuarios cargados.
        /// </summary>
        private List<Usuario> integrantesDelGrupo;

        /// <summary>
        /// Constructor del formulario para crear y registrar un nuevo gasto en un grupo.
        /// </summary>
        /// <param name="grupo">Grupo al que pertenece el gasto.</param>
        /// <param name="usuario">Usuario actualmente logueado.</param>
        /// <param name="gastosControlador">Controlador de gastos.</param>
        /// <param name="grupoControlador">Controlador de grupos.</param>
        public FormGastos(Grupo grupo, List<Usuario> integrantesDelGrupo, Usuario usuario, IGastosControlador gastosControlador, IGrupoControlador grupoControlador)
        {
            InitializeComponent();
            this.Grupo = grupo;
            this.usuarioLogeado = usuario; // Usuario que está creando el grupo
            this.grupoControlador = grupoControlador;
            this.gastosControlador = gastosControlador;
            this.integrantesDelGrupo = integrantesDelGrupo;
            mostrarPosiblesIntegrantes();
            mostrarQuienPago();
            montoTotal = 0.0;
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón Guardar.
        /// Guarda el gasto ingresado y muestra un mensaje de éxito o error.
        /// </summary>
        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            string nombreGasto = txtBnombre.Text;
            string descripcionGasto = txtBdescripcion.Text;
            string enlaceGasto = txtBenlace.Text;
            Usuario quienPago = (Usuario)cbBxQuienPago.SelectedItem;
            List<string> integrantes = obtenerIntegrantes();
            DateTime fechaSeleccionada = dtPckFecha.Value;

            bool guardado = this.gastosControlador.guardarGasto(Grupo, quienPago, nombreGasto, descripcionGasto, enlaceGasto, montoTotal, integrantes, fechaSeleccionada);

            if (guardado)
            {
                lbGuardado.ForeColor = System.Drawing.Color.Green;
                lbGuardado.Text = "Gasto guardado correctamente";
            }
            else
            {
                lbGuardado.ForeColor = System.Drawing.Color.Red;
                lbGuardado.Text = "Error al guardar el gasto";
            }

            this.LimpiarFormulario();
        }

        /// <summary>
        /// Muestra en el CheckedListBox los posibles integrantes del grupo.
        /// </summary>
        private void mostrarPosiblesIntegrantes()
        {

            foreach (Usuario usuario in integrantesDelGrupo)
            {
                this.chckListBoxIntegrantes.Items.Add(usuario);
            }
        }

        /// <summary>
        /// Muestra en el ComboBox los posibles integrantes que pueden haber pagado el gasto.
        /// </summary>
        private void mostrarQuienPago()
        {
            foreach (Usuario usuario in integrantesDelGrupo)
            {
                this.cbBxQuienPago.Items.Add(usuario);
            }

            // Selecciona el primer integrante por defecto
            if (cbBxQuienPago.Items.Count > 0)
            {
                cbBxQuienPago.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Controla que solo se puedan ingresar caracteres numéricos en el campo de monto.
        /// </summary>
        private void txtBmonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Controla que no se ingresen caracteres no numéricos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Previene que se ingrese el carácter
            }
        }

        /// <summary>
        /// Obtiene la lista de identificaciones de los integrantes seleccionados en el CheckedListBox.
        /// </summary>
        /// <returns>Lista de identificaciones de los integrantes seleccionados.</returns>
        private List<string> obtenerIntegrantes()
        {
            List<string> integrantes = new List<string>();
            // Agregamos todos los id de los integrantes seleccionados en el gasto
            foreach (var item in chckListBoxIntegrantes.CheckedItems)
            {
                Usuario usuario = item as Usuario;
                if (usuario != null)
                {
                    integrantes.Add(usuario.Identificacion);
                }
            }
            return integrantes;
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón Cancelar.
        /// Limpia el formulario y lo cierra.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarFormulario();
            this.Close();
        }

        /// <summary>
        /// Limpia todos los campos del formulario y desmarca los integrantes seleccionados.
        /// </summary>
        private void LimpiarFormulario()
        {
            txtBnombre.Text = string.Empty;
            txtBdescripcion.Text = string.Empty;
            txtBenlace.Text = string.Empty;
            txtBmonto.Text = string.Empty;
            cbBxQuienPago.SelectedIndex = -1;
            dtPckFecha.Value = DateTime.Now;

            // Desmarca todos los elementos del CheckedListBox
            for (int i = 0; i < chckListBoxIntegrantes.Items.Count; i++)
            {
                chckListBoxIntegrantes.SetItemChecked(i, false);
            }
            montoTotal = 0.0;
            lbMonto.Text = $"Monto Total: {montoTotal:C}"; // Formatea el monto total como moneda
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón Agregar Gasto.
        /// Suma el monto ingresado al total y actualiza la etiqueta de monto total.
        /// </summary>
        private void btnAgregarGasto_Click(object sender, EventArgs e)
        {
            montoTotal += txtBmonto.Text == string.Empty ? 0 : double.Parse(txtBmonto.Text);
            lbMonto.Text = $"Monto Total: {montoTotal:C}"; // Formatea el monto total como moneda
            txtBmonto.Text = string.Empty;
        }

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario de gastos.
        /// </summary>
        private void FormGastos_Load(object sender, EventArgs e)
        {

        }
    }
}
