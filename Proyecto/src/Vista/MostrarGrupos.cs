using Projecto.Modelo;
using Projecto.src.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projecto.src.Vista
{
    public partial class MostrarGrupos : Form
    {
        private readonly IGestorDatos gestorDatos;
        private string carpetaDestino = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Proyecto\src\assets\img\"));

        public MostrarGrupos(IGestorDatos gestorDatos)
        {
            InitializeComponent();
            this.gestorDatos = gestorDatos;
        }
        private void ConfigurarListView()
        {
            listMostrarGrupos.View = View.Details;
            listMostrarGrupos.FullRowSelect = true;
            listMostrarGrupos.Columns.Clear();
            listMostrarGrupos.Columns.Add("Logo", 150);
            listMostrarGrupos.Columns.Add("Nombre del Grupo", 100);
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void MostrarGrupos_Load(object sender, EventArgs e)
        {
            ConfigurarListView();

            List<Grupo> grupos = gestorDatos.CargarGrupos();
            grupos.ForEach(x =>
            {
                var img = new Bitmap(Path.Combine(carpetaDestino, x.NombreLogo));
                imageList1.Images.Add(x.NombreLogo,img);
            });
            listMostrarGrupos.Items.Clear();
           
            foreach (var grupo in grupos)
            {
     
                ListViewItem item = new ListViewItem(grupo.Id.ToString());


               item.SubItems.Add(grupo.Nombre);
                item.SubItems.Add(grupo.CreadorId);
                item.ImageKey = grupo.NombreLogo;
                listMostrarGrupos.Items.Add(item);
            }
        }

    }
}
