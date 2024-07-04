namespace Gestionnaire_de_l_Infrastructure_Reseaux.affichage
{
    partial class FenetreAjoutSite
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
            panel1 = new Panel();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(310, 142);
            panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 32);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(288, 71);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(108, 9);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 1;
            label1.Text = "nom du site ";
            // 
            // button1
            // 
            button1.Location = new Point(108, 109);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "sauvegarder";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FenetreAjoutSite
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(310, 142);
            Controls.Add(panel1);
            Name = "FenetreAjoutSite";
            Text = "FenetreAjoutSite";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
    }
}