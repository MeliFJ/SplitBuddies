using Projecto.Modelo;
using Projecto.src.Controlador;
using Projecto.src.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projecto.src.Vista
{
    public partial class FormGastos : Form
    {
        // Atributos
        private Grupo Grupo;
        private readonly IGestorDatos gestorDatos;
        private Usuario usuarioLogeado;
        private GrupoControlador grupoControlador;

        // Constructor para crear un nuevo grupo
        public FormGastos(Grupo grupo, Usuario usuario, IGestorDatos gestorDatos)
        {
            InitializeComponent();
            this.Grupo = grupo;
            this.gestorDatos = gestorDatos; // Gestor de datos para acceder a los datos
            this.usuarioLogeado = usuario; // Usuario que está creando el grupo
            this.grupoControlador = new GrupoControlador(gestorDatos);
            mostrarPosiblesIntegrantes();
            mostrarQuienPago();
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            string nombreGasto = txtBnombre.Text;
            string descripcionGasto = txtBdescripcion.Text;
            string enlaceGasto = txtBenlace.Text;
            double montoGasto = txtBmonto.Text == string.Empty ? 0 : double.Parse(txtBmonto.Text);
            Usuario quienPago = (Usuario)cbBxQuienPago.SelectedItem;
            List<string> integrantes = obtenerIntegrantes();
            DateTime fechaSeleccionada = dtPckFecha.Value;

            bool guardado = this.grupoControlador.guardarGasto(Grupo, quienPago, nombreGasto, descripcionGasto, enlaceGasto, montoGasto, integrantes, fechaSeleccionada);

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
            // Agregamos todos los id de los integrantes seleccionados
            foreach (var item in chckListBoxIntegrantes.CheckedItems)
            {
                Usuario usuario = item as Usuario;
                if (usuario != null)
                {
                    integrantes.Add(usuario.Identificacion);
                }
            }
            // Agregamos el id del que creo el grupo
            integrantes.Add(usuarioLogeado.Identificacion);
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
        }

    }
}
