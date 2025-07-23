namespace Projecto.src.Vista
{
    partial class FormGrupo
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
            this.btnCrearGrupo = new System.Windows.Forms.Button();
            this.txtNombreGrupo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNombreGrupo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pcBoxCarga = new System.Windows.Forms.PictureBox();
            this.btnCargaImagen = new System.Windows.Forms.Button();
            this.chckListBoxIntegrantes = new System.Windows.Forms.CheckedListBox();
            this.lbGuardado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcBoxCarga)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrearGrupo
            // 
            this.btnCrearGrupo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCrearGrupo.Location = new System.Drawing.Point(484, 642);
            this.btnCrearGrupo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnCrearGrupo.Name = "btnCrearGrupo";
            this.btnCrearGrupo.Size = new System.Drawing.Size(108, 37);
            this.btnCrearGrupo.TabIndex = 9;
            this.btnCrearGrupo.Text = "Crear";
            this.btnCrearGrupo.UseVisualStyleBackColor = false;
            this.btnCrearGrupo.Click += new System.EventHandler(this.btnCrearGrupo_Click);
            // 
            // txtNombreGrupo
            // 
            this.txtNombreGrupo.AccessibleDescription = "";
            this.txtNombreGrupo.AccessibleName = "";
            this.txtNombreGrupo.Location = new System.Drawing.Point(476, 183);
            this.txtNombreGrupo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtNombreGrupo.Name = "txtNombreGrupo";
            this.txtNombreGrupo.Size = new System.Drawing.Size(223, 26);
            this.txtNombreGrupo.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(472, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Seleccione la imagen del grupo";
            // 
            // lbNombreGrupo
            // 
            this.lbNombreGrupo.AutoSize = true;
            this.lbNombreGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombreGrupo.Location = new System.Drawing.Point(472, 148);
            this.lbNombreGrupo.Name = "lbNombreGrupo";
            this.lbNombreGrupo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbNombreGrupo.Size = new System.Drawing.Size(151, 20);
            this.lbNombreGrupo.TabIndex = 5;
            this.lbNombreGrupo.Text = "Nombre del grupo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(354, 65);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(545, 40);
            this.label1.TabIndex = 10;
            this.label1.Text = "Formulario para crear un grupo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(472, 482);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Seleccionar los integrantes";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.Location = new System.Drawing.Point(600, 642);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 37);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pcBoxCarga
            // 
            this.pcBoxCarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcBoxCarga.Location = new System.Drawing.Point(484, 255);
            this.pcBoxCarga.Name = "pcBoxCarga";
            this.pcBoxCarga.Size = new System.Drawing.Size(230, 127);
            this.pcBoxCarga.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcBoxCarga.TabIndex = 13;
            this.pcBoxCarga.TabStop = false;
            // 
            // btnCargaImagen
            // 
            this.btnCargaImagen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCargaImagen.Location = new System.Drawing.Point(484, 414);
            this.btnCargaImagen.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnCargaImagen.Name = "btnCargaImagen";
            this.btnCargaImagen.Size = new System.Drawing.Size(108, 37);
            this.btnCargaImagen.TabIndex = 14;
            this.btnCargaImagen.Text = "Seleccionar imagen";
            this.btnCargaImagen.UseVisualStyleBackColor = false;
            this.btnCargaImagen.Click += new System.EventHandler(this.btnCargaImagen_Click);
            // 
            // chckListBoxIntegrantes
            // 
            this.chckListBoxIntegrantes.FormattingEnabled = true;
            this.chckListBoxIntegrantes.Location = new System.Drawing.Point(375, 511);
            this.chckListBoxIntegrantes.Name = "chckListBoxIntegrantes";
            this.chckListBoxIntegrantes.Size = new System.Drawing.Size(518, 96);
            this.chckListBoxIntegrantes.TabIndex = 15;
            // 
            // lbGuardado
            // 
            this.lbGuardado.AutoSize = true;
            this.lbGuardado.Location = new System.Drawing.Point(480, 683);
            this.lbGuardado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbGuardado.Name = "lbGuardado";
            this.lbGuardado.Size = new System.Drawing.Size(0, 20);
            this.lbGuardado.TabIndex = 16;
            // 
            // FormGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1194, 760);
            this.Controls.Add(this.lbGuardado);
            this.Controls.Add(this.chckListBoxIntegrantes);
            this.Controls.Add(this.btnCargaImagen);
            this.Controls.Add(this.pcBoxCarga);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCrearGrupo);
            this.Controls.Add(this.txtNombreGrupo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbNombreGrupo);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FormGrupo";
            this.Text = "FormGrupo";
            this.Load += new System.EventHandler(this.FormGrupo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcBoxCarga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrearGrupo;
        private System.Windows.Forms.TextBox txtNombreGrupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNombreGrupo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pcBoxCarga;
        private System.Windows.Forms.Button btnCargaImagen;
        private System.Windows.Forms.CheckedListBox chckListBoxIntegrantes;
        private System.Windows.Forms.Label lbGuardado;
    }
}