namespace WfVistaSplitBuddies.Vista
{
    partial class FormGastos
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
            this.lbtitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBnombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBdescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBenlace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBmonto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtPckFecha = new System.Windows.Forms.DateTimePicker();
            this.chckListBoxIntegrantes = new System.Windows.Forms.CheckedListBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbBxQuienPago = new System.Windows.Forms.ComboBox();
            this.lbGuardado = new System.Windows.Forms.Label();
            this.btnAgregarGasto = new System.Windows.Forms.Button();
            this.lbMonto = new System.Windows.Forms.Label();
            this.btnCargaGasto = new System.Windows.Forms.Button();
            this.cbxGastosId = new System.Windows.Forms.ComboBox();
            this.lbId = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbtitulo
            // 
            this.lbtitulo.AutoSize = true;
            this.lbtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtitulo.Location = new System.Drawing.Point(618, 17);
            this.lbtitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtitulo.Name = "lbtitulo";
            this.lbtitulo.Size = new System.Drawing.Size(446, 51);
            this.lbtitulo.TabIndex = 0;
            this.lbtitulo.Text = "Formulario de gastos";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(754, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // txtBnombre
            // 
            this.txtBnombre.Location = new System.Drawing.Point(590, 169);
            this.txtBnombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtBnombre.Multiline = true;
            this.txtBnombre.Name = "txtBnombre";
            this.txtBnombre.Size = new System.Drawing.Size(554, 54);
            this.txtBnombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(730, 250);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción";
            // 
            // txtBdescripcion
            // 
            this.txtBdescripcion.Location = new System.Drawing.Point(590, 308);
            this.txtBdescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtBdescripcion.Multiline = true;
            this.txtBdescripcion.Name = "txtBdescripcion";
            this.txtBdescripcion.Size = new System.Drawing.Size(556, 200);
            this.txtBdescripcion.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(764, 512);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 37);
            this.label3.TabIndex = 5;
            this.label3.Text = "Enlace";
            // 
            // txtBenlace
            // 
            this.txtBenlace.Location = new System.Drawing.Point(590, 615);
            this.txtBenlace.Margin = new System.Windows.Forms.Padding(4);
            this.txtBenlace.Multiline = true;
            this.txtBenlace.Name = "txtBenlace";
            this.txtBenlace.Size = new System.Drawing.Size(556, 110);
            this.txtBenlace.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(764, 748);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 37);
            this.label4.TabIndex = 7;
            this.label4.Text = "Monto";
            // 
            // txtBmonto
            // 
            this.txtBmonto.Location = new System.Drawing.Point(584, 823);
            this.txtBmonto.Margin = new System.Windows.Forms.Padding(4);
            this.txtBmonto.Multiline = true;
            this.txtBmonto.Name = "txtBmonto";
            this.txtBmonto.Size = new System.Drawing.Size(532, 66);
            this.txtBmonto.TabIndex = 8;
            this.txtBmonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBmonto_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(688, 1012);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 37);
            this.label5.TabIndex = 9;
            this.label5.Text = "Quién lo pagó";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(714, 1127);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 37);
            this.label6.TabIndex = 11;
            this.label6.Text = "Integrantes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(764, 1321);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 37);
            this.label7.TabIndex = 13;
            this.label7.Text = "Fecha";
            // 
            // dtPckFecha
            // 
            this.dtPckFecha.Location = new System.Drawing.Point(578, 1412);
            this.dtPckFecha.Margin = new System.Windows.Forms.Padding(4);
            this.dtPckFecha.Name = "dtPckFecha";
            this.dtPckFecha.Size = new System.Drawing.Size(562, 31);
            this.dtPckFecha.TabIndex = 15;
            // 
            // chckListBoxIntegrantes
            // 
            this.chckListBoxIntegrantes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chckListBoxIntegrantes.FormattingEnabled = true;
            this.chckListBoxIntegrantes.Location = new System.Drawing.Point(578, 1198);
            this.chckListBoxIntegrantes.Margin = new System.Windows.Forms.Padding(4);
            this.chckListBoxIntegrantes.Name = "chckListBoxIntegrantes";
            this.chckListBoxIntegrantes.Size = new System.Drawing.Size(562, 116);
            this.chckListBoxIntegrantes.TabIndex = 16;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(562, 1504);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(260, 88);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(856, 1504);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(270, 88);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbBxQuienPago
            // 
            this.cbBxQuienPago.FormattingEnabled = true;
            this.cbBxQuienPago.Location = new System.Drawing.Point(578, 1079);
            this.cbBxQuienPago.Margin = new System.Windows.Forms.Padding(4);
            this.cbBxQuienPago.Name = "cbBxQuienPago";
            this.cbBxQuienPago.Size = new System.Drawing.Size(568, 33);
            this.cbBxQuienPago.TabIndex = 20;
            this.cbBxQuienPago.SelectedIndexChanged += new System.EventHandler(this.cbBxQuienPago_SelectedIndexChanged);
            // 
            // lbGuardado
            // 
            this.lbGuardado.Location = new System.Drawing.Point(562, 1610);
            this.lbGuardado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbGuardado.Name = "lbGuardado";
            this.lbGuardado.Size = new System.Drawing.Size(562, 125);
            this.lbGuardado.TabIndex = 21;
            this.lbGuardado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAgregarGasto
            // 
            this.btnAgregarGasto.Location = new System.Drawing.Point(590, 910);
            this.btnAgregarGasto.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarGasto.Name = "btnAgregarGasto";
            this.btnAgregarGasto.Size = new System.Drawing.Size(242, 67);
            this.btnAgregarGasto.TabIndex = 22;
            this.btnAgregarGasto.Text = "Agregar";
            this.btnAgregarGasto.UseVisualStyleBackColor = true;
            this.btnAgregarGasto.Click += new System.EventHandler(this.btnAgregarGasto_Click);
            // 
            // lbMonto
            // 
            this.lbMonto.AccessibleName = "";
            this.lbMonto.AutoSize = true;
            this.lbMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMonto.Location = new System.Drawing.Point(1144, 838);
            this.lbMonto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMonto.Name = "lbMonto";
            this.lbMonto.Size = new System.Drawing.Size(0, 42);
            this.lbMonto.TabIndex = 24;
            // 
            // btnCargaGasto
            // 
            this.btnCargaGasto.Location = new System.Drawing.Point(1188, 281);
            this.btnCargaGasto.Margin = new System.Windows.Forms.Padding(4);
            this.btnCargaGasto.Name = "btnCargaGasto";
            this.btnCargaGasto.Size = new System.Drawing.Size(260, 88);
            this.btnCargaGasto.TabIndex = 25;
            this.btnCargaGasto.Text = "Cargar gasto";
            this.btnCargaGasto.UseVisualStyleBackColor = true;
            this.btnCargaGasto.Click += new System.EventHandler(this.btnCargaGasto_Click);
            // 
            // cbxGastosId
            // 
            this.cbxGastosId.FormattingEnabled = true;
            this.cbxGastosId.Location = new System.Drawing.Point(1188, 187);
            this.cbxGastosId.Margin = new System.Windows.Forms.Padding(4);
            this.cbxGastosId.Name = "cbxGastosId";
            this.cbxGastosId.Size = new System.Drawing.Size(568, 33);
            this.cbxGastosId.TabIndex = 26;
            // 
            // lbId
            // 
            this.lbId.AutoEllipsis = true;
            this.lbId.AutoSize = true;
            this.lbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbId.Location = new System.Drawing.Point(1174, 112);
            this.lbId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(45, 37);
            this.lbId.TabIndex = 27;
            this.lbId.Text = "Id";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(1476, 281);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(260, 88);
            this.btnEliminar.TabIndex = 28;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // FormGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(2414, 2042);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lbId);
            this.Controls.Add(this.cbxGastosId);
            this.Controls.Add(this.btnCargaGasto);
            this.Controls.Add(this.lbMonto);
            this.Controls.Add(this.btnAgregarGasto);
            this.Controls.Add(this.lbGuardado);
            this.Controls.Add(this.cbBxQuienPago);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.chckListBoxIntegrantes);
            this.Controls.Add(this.dtPckFecha);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBmonto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBenlace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBdescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBnombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbtitulo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGastos";
            this.Text = "FormGastos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormGastos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbtitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBnombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBdescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBenlace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBmonto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtPckFecha;
        private System.Windows.Forms.CheckedListBox chckListBoxIntegrantes;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbBxQuienPago;
        private System.Windows.Forms.Label lbGuardado;
        public System.Windows.Forms.Button btnAgregarGasto;
        private System.Windows.Forms.Label lbMonto;
        private System.Windows.Forms.Button btnCargaGasto;
        private System.Windows.Forms.ComboBox cbxGastosId;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.Button btnEliminar;
    }
}