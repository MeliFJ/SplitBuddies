namespace SlitBuddies
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Lbnombre = new Label();
            label1 = new Label();
            TxtbxNombre = new TextBox();
            Texbxcedula = new TextBox();
            lbcedula = new Label();
            textBox1 = new TextBox();
            lbcontraseña = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // Lbnombre
            // 
            Lbnombre.AutoSize = true;
            Lbnombre.Location = new Point(208, 149);
            Lbnombre.Name = "Lbnombre";
            Lbnombre.Size = new Size(82, 25);
            Lbnombre.TabIndex = 1;
            Lbnombre.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 84);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 2;
            // 
            // TxtbxNombre
            // 
            TxtbxNombre.BackColor = SystemColors.HighlightText;
            TxtbxNombre.Location = new Point(315, 143);
            TxtbxNombre.Name = "TxtbxNombre";
            TxtbxNombre.Size = new Size(150, 31);
            TxtbxNombre.TabIndex = 3;
            // 
            // Texbxcedula
            // 
            Texbxcedula.Location = new Point(315, 210);
            Texbxcedula.Name = "Texbxcedula";
            Texbxcedula.Size = new Size(150, 31);
            Texbxcedula.TabIndex = 4;
            Texbxcedula.TextChanged += textBox1_TextChanged_1;
            // 
            // lbcedula
            // 
            lbcedula.AutoSize = true;
            lbcedula.Location = new Point(208, 216);
            lbcedula.Name = "lbcedula";
            lbcedula.Size = new Size(70, 25);
            lbcedula.TabIndex = 6;
            lbcedula.Text = "Cedula:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(315, 276);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 7;
            textBox1.UseSystemPasswordChar = true;
            // 
            // lbcontraseña
            // 
            lbcontraseña.AutoSize = true;
            lbcontraseña.Location = new Point(208, 282);
            lbcontraseña.Name = "lbcontraseña";
            lbcontraseña.Size = new Size(101, 25);
            lbcontraseña.TabIndex = 8;
            lbcontraseña.Text = "Contraseña";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(344, 84);
            label2.Name = "label2";
            label2.Size = new Size(77, 25);
            label2.TabIndex = 9;
            label2.Text = "Registro";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(lbcontraseña);
            Controls.Add(textBox1);
            Controls.Add(lbcedula);
            Controls.Add(Texbxcedula);
            Controls.Add(TxtbxNombre);
            Controls.Add(label1);
            Controls.Add(Lbnombre);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label Lbnombre;
        private Label label1;
        private TextBox TxtbxNombre;
        private TextBox Texbxcedula;
        private Label lbcedula;
        private TextBox textBox1;
        private Label lbcontraseña;
        private Label label2;
    }
}
