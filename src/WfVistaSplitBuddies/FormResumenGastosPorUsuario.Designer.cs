namespace WfVistaSplitBuddies
{
    partial class FormResumenGastosPorUsuario
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
            this.label2 = new System.Windows.Forms.Label();
            this.cboGruposDelusuarioResumen = new System.Windows.Forms.ComboBox();
            this.lblusuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSaldoUsuario = new System.Windows.Forms.Label();
            this.lbltotalPorIntegrante = new System.Windows.Forms.Label();
            this.lblgastosPagosPorusuario = new System.Windows.Forms.Label();
            this.dgtGrupos = new System.Windows.Forms.DataGridView();
            this.lblSaldoDelusuario = new System.Windows.Forms.Label();
            this.lblTotalGastosGrupo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCantidadIntegrantes = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboUsuario = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnVerBalance = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgtGrupos)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Grupo";
            // 
            // cboGruposDelusuarioResumen
            // 
            this.cboGruposDelusuarioResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGruposDelusuarioResumen.FormattingEnabled = true;
            this.cboGruposDelusuarioResumen.Location = new System.Drawing.Point(238, 35);
            this.cboGruposDelusuarioResumen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboGruposDelusuarioResumen.Name = "cboGruposDelusuarioResumen";
            this.cboGruposDelusuarioResumen.Size = new System.Drawing.Size(422, 28);
            this.cboGruposDelusuarioResumen.TabIndex = 7;
            this.cboGruposDelusuarioResumen.SelectedIndexChanged += new System.EventHandler(this.cboGruposDelusuario_SelectedIndexChanged);
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.Location = new System.Drawing.Point(151, 45);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(59, 20);
            this.lblusuario.TabIndex = 6;
            this.lblusuario.Text = "yanixa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Gastos usuario";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(260, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Gastos totales por integrante";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(264, 407);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Gastos pagados del usuario";
            // 
            // lblSaldoUsuario
            // 
            this.lblSaldoUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSaldoUsuario.AutoSize = true;
            this.lblSaldoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoUsuario.Location = new System.Drawing.Point(578, 359);
            this.lblSaldoUsuario.Name = "lblSaldoUsuario";
            this.lblSaldoUsuario.Size = new System.Drawing.Size(19, 20);
            this.lblSaldoUsuario.TabIndex = 11;
            this.lblSaldoUsuario.Text = "0";
            // 
            // lbltotalPorIntegrante
            // 
            this.lbltotalPorIntegrante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbltotalPorIntegrante.AutoSize = true;
            this.lbltotalPorIntegrante.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalPorIntegrante.Location = new System.Drawing.Point(261, 359);
            this.lbltotalPorIntegrante.Name = "lbltotalPorIntegrante";
            this.lbltotalPorIntegrante.Size = new System.Drawing.Size(59, 20);
            this.lbltotalPorIntegrante.TabIndex = 12;
            this.lbltotalPorIntegrante.Text = "10000";
            // 
            // lblgastosPagosPorusuario
            // 
            this.lblgastosPagosPorusuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblgastosPagosPorusuario.AutoSize = true;
            this.lblgastosPagosPorusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgastosPagosPorusuario.Location = new System.Drawing.Point(264, 441);
            this.lblgastosPagosPorusuario.Name = "lblgastosPagosPorusuario";
            this.lblgastosPagosPorusuario.Size = new System.Drawing.Size(59, 20);
            this.lblgastosPagosPorusuario.TabIndex = 13;
            this.lblgastosPagosPorusuario.Text = "10000";
            // 
            // dgtGrupos
            // 
            this.dgtGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgtGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgtGrupos.Location = new System.Drawing.Point(8, 116);
            this.dgtGrupos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgtGrupos.Name = "dgtGrupos";
            this.dgtGrupos.RowHeadersWidth = 51;
            this.dgtGrupos.RowTemplate.Height = 24;
            this.dgtGrupos.Size = new System.Drawing.Size(878, 184);
            this.dgtGrupos.TabIndex = 14;
            // 
            // lblSaldoDelusuario
            // 
            this.lblSaldoDelusuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSaldoDelusuario.AutoSize = true;
            this.lblSaldoDelusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoDelusuario.Location = new System.Drawing.Point(567, 326);
            this.lblSaldoDelusuario.Name = "lblSaldoDelusuario";
            this.lblSaldoDelusuario.Size = new System.Drawing.Size(148, 20);
            this.lblSaldoDelusuario.TabIndex = 15;
            this.lblSaldoDelusuario.Text = "Saldo del usuario";
            // 
            // lblTotalGastosGrupo
            // 
            this.lblTotalGastosGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalGastosGrupo.AutoSize = true;
            this.lblTotalGastosGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGastosGrupo.Location = new System.Drawing.Point(7, 359);
            this.lblTotalGastosGrupo.Name = "lblTotalGastosGrupo";
            this.lblTotalGastosGrupo.Size = new System.Drawing.Size(59, 20);
            this.lblTotalGastosGrupo.TabIndex = 17;
            this.lblTotalGastosGrupo.Text = "10000";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 326);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(207, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Gastos totales del grupo";
            // 
            // lblCantidadIntegrantes
            // 
            this.lblCantidadIntegrantes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCantidadIntegrantes.AutoSize = true;
            this.lblCantidadIntegrantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadIntegrantes.Location = new System.Drawing.Point(15, 441);
            this.lblCantidadIntegrantes.Name = "lblCantidadIntegrantes";
            this.lblCantidadIntegrantes.Size = new System.Drawing.Size(59, 20);
            this.lblCantidadIntegrantes.TabIndex = 19;
            this.lblCantidadIntegrantes.Text = "10000";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 407);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(202, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "Cantidad de integrantes";
            // 
            // cboUsuario
            // 
            this.cboUsuario.FormattingEnabled = true;
            this.cboUsuario.Location = new System.Drawing.Point(8, 35);
            this.cboUsuario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboUsuario.Name = "cboUsuario";
            this.cboUsuario.Size = new System.Drawing.Size(136, 28);
            this.cboUsuario.TabIndex = 20;
            this.cboUsuario.SelectedIndexChanged += new System.EventHandler(this.cboUsuario_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Lista de gastos";
            // 
            // btnVerBalance
            // 
            this.btnVerBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerBalance.Location = new System.Drawing.Point(684, 16);
            this.btnVerBalance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVerBalance.Name = "btnVerBalance";
            this.btnVerBalance.Size = new System.Drawing.Size(201, 93);
            this.btnVerBalance.TabIndex = 22;
            this.btnVerBalance.Text = "Mostrar balance";
            this.btnVerBalance.UseVisualStyleBackColor = true;
            this.btnVerBalance.Click += new System.EventHandler(this.btnVerBalance_Click);
            // 
            // FormResumenGastosPorUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(900, 490);
            this.Controls.Add(this.btnVerBalance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboUsuario);
            this.Controls.Add(this.lblCantidadIntegrantes);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTotalGastosGrupo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblSaldoDelusuario);
            this.Controls.Add(this.dgtGrupos);
            this.Controls.Add(this.lblgastosPagosPorusuario);
            this.Controls.Add(this.lbltotalPorIntegrante);
            this.Controls.Add(this.lblSaldoUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboGruposDelusuarioResumen);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormResumenGastosPorUsuario";
            this.Text = "FormResumenGastosPorUsuario";
            this.Load += new System.EventHandler(this.FormResumenGastosPorUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgtGrupos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboGruposDelusuarioResumen;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSaldoUsuario;
        private System.Windows.Forms.Label lbltotalPorIntegrante;
        private System.Windows.Forms.Label lblgastosPagosPorusuario;
        private System.Windows.Forms.DataGridView dgtGrupos;
        private System.Windows.Forms.Label lblSaldoDelusuario;
        private System.Windows.Forms.Label lblTotalGastosGrupo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCantidadIntegrantes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnVerBalance;
    }
}