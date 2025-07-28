using Controlador;
using Controlador.Interfaces;
using GestorDatos.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WfVistaSplitBuddies.Vista
{
    public partial class FormGastos : Form
    {
        // Atributos
        private Grupo Grupo;
        private Usuario usuarioLogeado;
        private IGastosControlador gastosControlador;
        private IGrupoControlador grupoControlador;
        private double montoTotal;

        // Constructor para crear un nuevo grupo
        public FormGastos(Grupo grupo, Usuario usuario, IGastosControlador gastosControlador, IGrupoControlador grupoControlador)
        {
            InitializeComponent();
            this.Grupo = grupo;
            this.usuarioLogeado = usuario; // Usuario que está creando el grupo
            this.grupoControlador= grupoControlador;
            this.gastosControlador = gastosControlador;
            mostrarPosiblesIntegrantes();
            mostrarQuienPago();
            montoTotal = 0.0;
        }

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

        private void mostrarPosiblesIntegrantes()
        {
            // Carga los posibles integrantes del grupo
            Dictionary<string, Usuario> posiblesIntegrantes = grupoControlador.cargarPosiblesIntegrantes();

            foreach (var valor in posiblesIntegrantes)
            {
                Usuario usuario = valor.Value;
                this.chckListBoxIntegrantes.Items.Add(usuario);
            }

        }

        private void mostrarQuienPago()
        {
            // Carga los posibles integrantes del grupo
            Dictionary<string, Usuario> posiblesIntegrantes = grupoControlador.cargarPosiblesIntegrantes();

            foreach (var valor in posiblesIntegrantes)
            {
                Usuario usuario = valor.Value;

                this.cbBxQuienPago.Items.Add(usuario);
            }

            // Selecciona el primer integrante por defecto
            if (cbBxQuienPago.Items.Count > 0)
            {
                cbBxQuienPago.SelectedIndex = 0;
            }



        }

        private void txtBmonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Controla que no e ingresen caracteres no numéricos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Previene que se ingrese el carácter
            }
        }

        // Método para obtener los integrantes seleccionados
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarFormulario();
            this.Close();
        }

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
        }

        private void btnAgregarGasto_Click(object sender, EventArgs e)
        {
            montoTotal += txtBmonto.Text == string.Empty ? 0 : double.Parse(txtBmonto.Text);
            lbMonto.Text = $"Monto Total: {montoTotal:C}"; // Formatea el monto total como moneda
            txtBmonto.Text = string.Empty;
        }

        private void FormGastos_Load(object sender, EventArgs e)
        {

        }
    }
}
