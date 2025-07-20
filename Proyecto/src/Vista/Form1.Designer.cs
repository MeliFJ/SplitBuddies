namespace Projecto
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(472, 176);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identificación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(472, 318);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // txtbxIdentificacion
            // 
            this.txtbxIdentificacion.AccessibleDescription = "";
            this.txtbxIdentificacion.AccessibleName = "";
            this.txtbxIdentificacion.Location = new System.Drawing.Point(477, 226);
            this.txtbxIdentificacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtbxIdentificacion.Name = "txtbxIdentificacion";
            this.txtbxIdentificacion.Size = new System.Drawing.Size(295, 31);
            this.txtbxIdentificacion.TabIndex = 2;
            // 
            // txtbxContrasena
            // 
            this.txtbxContrasena.Location = new System.Drawing.Point(477, 392);
            this.txtbxContrasena.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtbxContrasena.Name = "txtbxContrasena";
            this.txtbxContrasena.Size = new System.Drawing.Size(295, 31);
            this.txtbxContrasena.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogin.Location = new System.Drawing.Point(477, 468);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(144, 48);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegistrarse.Location = new System.Drawing.Point(629, 468);
            this.btnRegistrarse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new System.Drawing.Size(144, 48);
            this.btnRegistrarse.TabIndex = 5;
            this.btnRegistrarse.Text = "Registrarse";
            this.btnRegistrarse.UseVisualStyleBackColor = false;
            this.btnRegistrarse.Click += new System.EventHandler(this.button2_Click);
            // 
            // LbErrorLogin
            // 
            this.LbErrorLogin.AutoSize = true;
            this.LbErrorLogin.ForeColor = System.Drawing.Color.Red;
            this.LbErrorLogin.Location = new System.Drawing.Point(472, 538);
            this.LbErrorLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbErrorLogin.Name = "LbErrorLogin";
            this.LbErrorLogin.Size = new System.Drawing.Size(0, 25);
            this.LbErrorLogin.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 62);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(87, 47);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(8, 8);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "button2";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1200, 702);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LbErrorLogin);
            this.Controls.Add(this.btnRegistrarse);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtbxContrasena);
            this.Controls.Add(this.txtbxIdentificacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTest;
    }
}

