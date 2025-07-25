namespace WfVistaSplitBuddies
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbxIdentificacion = new System.Windows.Forms.TextBox();
            this.txtbxContrasena = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegistrarse = new System.Windows.Forms.Button();
            this.LbErrorLogin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identificación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 165);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // txtbxIdentificacion
            // 
            this.txtbxIdentificacion.AccessibleDescription = "";
            this.txtbxIdentificacion.AccessibleName = "";
            this.txtbxIdentificacion.Location = new System.Drawing.Point(238, 118);
            this.txtbxIdentificacion.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtbxIdentificacion.Name = "txtbxIdentificacion";
            this.txtbxIdentificacion.Size = new System.Drawing.Size(150, 20);
            this.txtbxIdentificacion.TabIndex = 2;
            // 
            // txtbxContrasena
            // 
            this.txtbxContrasena.Location = new System.Drawing.Point(238, 204);
            this.txtbxContrasena.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtbxContrasena.Name = "txtbxContrasena";
            this.txtbxContrasena.Size = new System.Drawing.Size(150, 20);
            this.txtbxContrasena.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogin.Location = new System.Drawing.Point(238, 243);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(72, 25);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegistrarse.Location = new System.Drawing.Point(314, 243);
            this.btnRegistrarse.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new System.Drawing.Size(72, 25);
            this.btnRegistrarse.TabIndex = 5;
            this.btnRegistrarse.Text = "Registrarse";
            this.btnRegistrarse.UseVisualStyleBackColor = false;
            this.btnRegistrarse.Click += new System.EventHandler(this.button2_Click);
            // 
            // LbErrorLogin
            // 
            this.LbErrorLogin.AutoSize = true;
            this.LbErrorLogin.ForeColor = System.Drawing.Color.Red;
            this.LbErrorLogin.Location = new System.Drawing.Point(236, 280);
            this.LbErrorLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LbErrorLogin.Name = "LbErrorLogin";
            this.LbErrorLogin.Size = new System.Drawing.Size(0, 13);
            this.LbErrorLogin.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(600, 365);
            this.Controls.Add(this.LbErrorLogin);
            this.Controls.Add(this.btnRegistrarse);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtbxContrasena);
            this.Controls.Add(this.txtbxIdentificacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbxIdentificacion;
        private System.Windows.Forms.TextBox txtbxContrasena;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegistrarse;
        private System.Windows.Forms.Label LbErrorLogin;
    }
}

