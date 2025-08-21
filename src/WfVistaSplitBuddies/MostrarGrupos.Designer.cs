namespace WfVistaSplitBuddies.Vista
{
    partial class MostrarGrupos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("");
            this.listMostrarGrupos = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAgregarGasto = new System.Windows.Forms.Button();
            this.btnGastos = new System.Windows.Forms.Button();
            this.btnCrearGrupo = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.listMiembros = new System.Windows.Forms.ListView();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listMostrarGrupos
            // 
            this.listMostrarGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listMostrarGrupos.HideSelection = false;
            this.listMostrarGrupos.LargeImageList = this.imageList1;
            this.listMostrarGrupos.Location = new System.Drawing.Point(8, 31);
            this.listMostrarGrupos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listMostrarGrupos.Name = "listMostrarGrupos";
            this.listMostrarGrupos.Size = new System.Drawing.Size(532, 1833);
            this.listMostrarGrupos.SmallImageList = this.imageList1;
            this.listMostrarGrupos.TabIndex = 0;
            this.listMostrarGrupos.UseCompatibleStateImageBehavior = false;
            this.listMostrarGrupos.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(30, 30);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.listMostrarGrupos);
            this.groupBox1.Location = new System.Drawing.Point(16, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(576, 1904);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grupos";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnCerrarSesion);
            this.groupBox2.Controls.Add(this.btnReporte);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnAgregarGasto);
            this.groupBox2.Controls.Add(this.btnGastos);
            this.groupBox2.Controls.Add(this.btnCrearGrupo);
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.listMiembros);
            this.groupBox2.Location = new System.Drawing.Point(600, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(2842, 1992);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Miembros";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1854, 1923);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 62);
            this.button1.TabIndex = 5;
            this.button1.Text = "Modificar Gastos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnAgregarGasto
            // 
            this.btnAgregarGasto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarGasto.Location = new System.Drawing.Point(2094, 1925);
            this.btnAgregarGasto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregarGasto.Name = "btnAgregarGasto";
            this.btnAgregarGasto.Size = new System.Drawing.Size(232, 62);
            this.btnAgregarGasto.TabIndex = 4;
            this.btnAgregarGasto.Text = "Registrar gastos";
            this.btnAgregarGasto.UseVisualStyleBackColor = true;
            this.btnAgregarGasto.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGastos
            // 
            this.btnGastos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGastos.Location = new System.Drawing.Point(2336, 1925);
            this.btnGastos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGastos.Name = "btnGastos";
            this.btnGastos.Size = new System.Drawing.Size(184, 60);
            this.btnGastos.TabIndex = 3;
            this.btnGastos.Text = "Mostrar gastos";
            this.btnGastos.UseVisualStyleBackColor = true;
            this.btnGastos.Click += new System.EventHandler(this.btnGastos_Click);
            // 
            // btnCrearGrupo
            // 
            this.btnCrearGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrearGrupo.Location = new System.Drawing.Point(2530, 1925);
            this.btnCrearGrupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCrearGrupo.Name = "btnCrearGrupo";
            this.btnCrearGrupo.Size = new System.Drawing.Size(152, 60);
            this.btnCrearGrupo.TabIndex = 2;
            this.btnCrearGrupo.Text = "Crear Grupo";
            this.btnCrearGrupo.UseVisualStyleBackColor = true;
            this.btnCrearGrupo.Click += new System.EventHandler(this.btnCrearGrupo_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.Location = new System.Drawing.Point(2692, 1925);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(152, 60);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // listMiembros
            // 
            this.listMiembros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listMiembros.HideSelection = false;
            this.listMiembros.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6});
            this.listMiembros.Location = new System.Drawing.Point(8, 31);
            this.listMiembros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listMiembros.Name = "listMiembros";
            this.listMiembros.Size = new System.Drawing.Size(2828, 1871);
            this.listMiembros.TabIndex = 0;
            this.listMiembros.UseCompatibleStateImageBehavior = false;
            this.listMiembros.SelectedIndexChanged += new System.EventHandler(this.listMiembros_SelectedIndexChanged);
            // 
            // btnReporte
            // 
            this.btnReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReporte.Location = new System.Drawing.Point(1212, 1921);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(260, 62);
            this.btnReporte.TabIndex = 6;
            this.btnReporte.Text = "Mostrar reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click_1);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarSesion.Location = new System.Drawing.Point(1495, 1922);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(260, 62);
            this.btnCerrarSesion.TabIndex = 7;
            this.btnCerrarSesion.Text = "Cerrar sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click_1);
            // 
            // MostrarGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(3460, 2021);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1574, 1088);
            this.Name = "MostrarGrupos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MostrarGrupos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MostrarGrupos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listMostrarGrupos;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listMiembros;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCrearGrupo;
        private System.Windows.Forms.Button btnGastos;
        private System.Windows.Forms.Button btnAgregarGasto;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}