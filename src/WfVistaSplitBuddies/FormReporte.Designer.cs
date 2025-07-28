using System.Windows.Forms;

namespace WfVistaSplitBuddies
{
    partial class FormReporte
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
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpMes = new System.Windows.Forms.DateTimePicker();
            this.btnGenerarXFechas = new System.Windows.Forms.Button();
            this.btnGenerarMes = new System.Windows.Forms.Button();
            this.lbMontoMontoGastado = new System.Windows.Forms.Label();
            this.lbMonteAdeudado = new System.Windows.Forms.Label();
            this.btnGenerarAnual = new System.Windows.Forms.Button();
            this.dtpAnno = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lbDisponible = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.LbUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "dd MMMM yyyy";
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(133, 108);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(130, 20);
            this.dtpDesde.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 99);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(270, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta";
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "dd MMMM yyyy";
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(353, 109);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(2);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(130, 20);
            this.dtpHasta.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mes";
            // 
            // dtpMes
            // 
            this.dtpMes.CustomFormat = "MMMM yyyy";
            this.dtpMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMes.Location = new System.Drawing.Point(133, 151);
            this.dtpMes.Margin = new System.Windows.Forms.Padding(2);
            this.dtpMes.Name = "dtpMes";
            this.dtpMes.ShowUpDown = true;
            this.dtpMes.Size = new System.Drawing.Size(130, 20);
            this.dtpMes.TabIndex = 6;
            // 
            // btnGenerarXFechas
            // 
            this.btnGenerarXFechas.Location = new System.Drawing.Point(497, 109);
            this.btnGenerarXFechas.Name = "btnGenerarXFechas";
            this.btnGenerarXFechas.Size = new System.Drawing.Size(75, 23);
            this.btnGenerarXFechas.TabIndex = 7;
            this.btnGenerarXFechas.Text = "Generar";
            this.btnGenerarXFechas.UseVisualStyleBackColor = true;
            this.btnGenerarXFechas.Click += new System.EventHandler(this.btnGenerarXFechas_Click);
            // 
            // btnGenerarMes
            // 
            this.btnGenerarMes.Location = new System.Drawing.Point(289, 151);
            this.btnGenerarMes.Name = "btnGenerarMes";
            this.btnGenerarMes.Size = new System.Drawing.Size(75, 23);
            this.btnGenerarMes.TabIndex = 8;
            this.btnGenerarMes.Text = "Generar";
            this.btnGenerarMes.UseVisualStyleBackColor = true;
            this.btnGenerarMes.Click += new System.EventHandler(this.btnGenerarMes_Click);
            // 
            // lbMontoMontoGastado
            // 
            this.lbMontoMontoGastado.AutoSize = true;
            this.lbMontoMontoGastado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMontoMontoGastado.Location = new System.Drawing.Point(19, 227);
            this.lbMontoMontoGastado.Name = "lbMontoMontoGastado";
            this.lbMontoMontoGastado.Size = new System.Drawing.Size(386, 30);
            this.lbMontoMontoGastado.TabIndex = 9;
            this.lbMontoMontoGastado.Text = "Monto pagado en el periodo: 0";
            // 
            // lbMonteAdeudado
            // 
            this.lbMonteAdeudado.AutoSize = true;
            this.lbMonteAdeudado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMonteAdeudado.Location = new System.Drawing.Point(19, 276);
            this.lbMonteAdeudado.Name = "lbMonteAdeudado";
            this.lbMonteAdeudado.Size = new System.Drawing.Size(416, 30);
            this.lbMonteAdeudado.TabIndex = 10;
            this.lbMonteAdeudado.Text = "Monto adeudado en el periodo: 0";
            // 
            // btnGenerarAnual
            // 
            this.btnGenerarAnual.Location = new System.Drawing.Point(289, 189);
            this.btnGenerarAnual.Name = "btnGenerarAnual";
            this.btnGenerarAnual.Size = new System.Drawing.Size(75, 23);
            this.btnGenerarAnual.TabIndex = 13;
            this.btnGenerarAnual.Text = "Generar";
            this.btnGenerarAnual.UseVisualStyleBackColor = true;
            this.btnGenerarAnual.Click += new System.EventHandler(this.btnGenerarAnual_Click);
            // 
            // dtpAnno
            // 
            this.dtpAnno.CustomFormat = "yyyy";
            this.dtpAnno.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAnno.Location = new System.Drawing.Point(133, 189);
            this.dtpAnno.Margin = new System.Windows.Forms.Padding(2);
            this.dtpAnno.Name = "dtpAnno";
            this.dtpAnno.ShowUpDown = true;
            this.dtpAnno.Size = new System.Drawing.Size(130, 20);
            this.dtpAnno.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 178);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 31);
            this.label4.TabIndex = 11;
            this.label4.Text = "Año";
            // 
            // lbDisponible
            // 
            this.lbDisponible.AutoSize = true;
            this.lbDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDisponible.Location = new System.Drawing.Point(19, 318);
            this.lbDisponible.Name = "lbDisponible";
            this.lbDisponible.Size = new System.Drawing.Size(421, 30);
            this.lbDisponible.TabIndex = 14;
            this.lbDisponible.Text = "Monto disponible en el periodo: 0";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(9, 395);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 15;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // LbUsuario
            // 
            this.LbUsuario.AutoSize = true;
            this.LbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbUsuario.Location = new System.Drawing.Point(33, 28);
            this.LbUsuario.Name = "LbUsuario";
            this.LbUsuario.Size = new System.Drawing.Size(0, 84);
            this.LbUsuario.TabIndex = 16;
            // 
            // FormReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1033, 738);
            this.Controls.Add(this.LbUsuario);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lbDisponible);
            this.Controls.Add(this.btnGenerarAnual);
            this.Controls.Add(this.dtpAnno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbMonteAdeudado);
            this.Controls.Add(this.lbMontoMontoGastado);
            this.Controls.Add(this.btnGenerarMes);
            this.Controls.Add(this.btnGenerarXFechas);
            this.Controls.Add(this.dtpMes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormReporte";
            this.Text = "FormReporte";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private Label label3;
        private DateTimePicker dtpMes;
        private Button btnGenerarXFechas;
        private Button btnGenerarMes;
        private Label lbMontoMontoGastado;
        private Label lbMonteAdeudado;
        private Button btnGenerarAnual;
        private DateTimePicker dtpAnno;
        private Label label4;
        private Label lbDisponible;
        private Button btnLimpiar;
        private Label LbUsuario;
    }
}