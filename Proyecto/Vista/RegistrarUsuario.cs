using System;
using Projecto.Controlador;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projecto.Modelo;

namespace Projecto.Vista
{
    public partial class RegistrarUsuario : Form
    {
        private void Limpiar()
        {
            txtIdentificacion.Clear();
            txtNombre.Clear();
            TxtApellido.Clear();
            txtContrasena.Clear();
        }
        public RegistrarUsuario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        
        private void btnguardar_Click(object sender, EventArgs e)
        {
            string Identificacion = txtIdentificacion.Text;
            string nombre = txtNombre.Text;
            string apellido = TxtApellido.Text;
            string password = txtContrasena.Text;
            GestorDatos gestorDatos = new GestorDatos();
            Usuario NuevoUsuario = new Usuario (Identificacion,password,nombre,apellido);
 
            var usuario = gestorDatos.BuscarUsuario(Identificacion);
            if (usuario is null)
            {
                gestorDatos.GuardarUsuario(NuevoUsuario);
                MessageBox.Show ( "Registro éxitoso","Registro de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                this.Close();
            }
            else
            {
                MessageBox.Show("El Usuario ya éxiste", "Registro de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Limpiar();
                this.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
