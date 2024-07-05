namespace Gestionnaire_de_l_Infrastructure_Reseaux.affichage
{
    partial class FenetreRecherche
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
            splitContainer1 = new SplitContainer();
            button2 = new Button();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(textBox1);
            splitContainer1.Panel1.Controls.Add(comboBox1);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Size = new Size(917, 558);
            splitContainer1.SplitterDistance = 40;
            splitContainer1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(742, 7);
            button2.Name = "button2";
            button2.Size = new Size(163, 29);
            button2.TabIndex = 5;
            button2.Text = "Recharger la page";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(402, 11);
            label2.Name = "label2";
            label2.Size = new Size(128, 20);
            label2.TabIndex = 4;
            label2.Text = "Nom de l'élément";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(178, 13);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 3;
            label1.Text = "Site";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(536, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(218, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(12, 8);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "rechercher";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FenetreRecherche
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 558);
            Controls.Add(splitContainer1);
            Name = "FenetreRecherche";
            Text = "fenetre de recherche";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
    }
}