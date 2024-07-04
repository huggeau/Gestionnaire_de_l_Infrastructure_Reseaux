namespace Gestionnaire_de_l_Infrastructure_Reseaux
{
    partial class FenetreAjoutMateriel
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
            BoutonSauvegarder = new Button();
            textBoxNomMateriel = new TextBox();
            labelMateriel = new Label();
            labelEtage = new Label();
            labelIP = new Label();
            comboBoxEtage = new ComboBox();
            textBoxIpMateriel = new TextBox();
            labelCategorie = new Label();
            comboBoxCategorie = new ComboBox();
            textBoxEmplacement = new TextBox();
            textBoxCommentaire = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // BoutonSauvegarder
            // 
            BoutonSauvegarder.Location = new Point(261, 371);
            BoutonSauvegarder.Name = "BoutonSauvegarder";
            BoutonSauvegarder.Size = new Size(102, 29);
            BoutonSauvegarder.TabIndex = 0;
            BoutonSauvegarder.Text = "sauvegarder";
            BoutonSauvegarder.UseVisualStyleBackColor = true;
            BoutonSauvegarder.Click += BoutonSauvegarder_Click;
            // 
            // textBoxNomMateriel
            // 
            textBoxNomMateriel.Location = new Point(6, 40);
            textBoxNomMateriel.Name = "textBoxNomMateriel";
            textBoxNomMateriel.Size = new Size(282, 27);
            textBoxNomMateriel.TabIndex = 1;
            // 
            // labelMateriel
            // 
            labelMateriel.AutoSize = true;
            labelMateriel.Location = new Point(87, 17);
            labelMateriel.Name = "labelMateriel";
            labelMateriel.Size = new Size(122, 20);
            labelMateriel.TabIndex = 2;
            labelMateriel.Text = "Nom du Materiel";
            // 
            // labelEtage
            // 
            labelEtage.AutoSize = true;
            labelEtage.Location = new Point(82, 242);
            labelEtage.Name = "labelEtage";
            labelEtage.Size = new Size(127, 20);
            labelEtage.TabIndex = 4;
            labelEtage.Text = "etage du Materiel";
            // 
            // labelIP
            // 
            labelIP.AutoSize = true;
            labelIP.Location = new Point(98, 86);
            labelIP.Name = "labelIP";
            labelIP.Size = new Size(102, 20);
            labelIP.TabIndex = 5;
            labelIP.Text = "Ip du Materiel";
            // 
            // comboBoxEtage
            // 
            comboBoxEtage.FormattingEnabled = true;
            comboBoxEtage.Location = new Point(71, 277);
            comboBoxEtage.Name = "comboBoxEtage";
            comboBoxEtage.Size = new Size(151, 28);
            comboBoxEtage.TabIndex = 6;
            // 
            // textBoxIpMateriel
            // 
            textBoxIpMateriel.Location = new Point(9, 109);
            textBoxIpMateriel.Name = "textBoxIpMateriel";
            textBoxIpMateriel.Size = new Size(279, 27);
            textBoxIpMateriel.TabIndex = 8;
            // 
            // labelCategorie
            // 
            labelCategorie.AutoSize = true;
            labelCategorie.Location = new Point(68, 170);
            labelCategorie.Name = "labelCategorie";
            labelCategorie.Size = new Size(154, 20);
            labelCategorie.TabIndex = 9;
            labelCategorie.Text = "Categorie de Materiel";
            // 
            // comboBoxCategorie
            // 
            comboBoxCategorie.FormattingEnabled = true;
            comboBoxCategorie.Location = new Point(71, 193);
            comboBoxCategorie.Name = "comboBoxCategorie";
            comboBoxCategorie.Size = new Size(151, 28);
            comboBoxCategorie.TabIndex = 10;
            // 
            // textBoxEmplacement
            // 
            textBoxEmplacement.Location = new Point(352, 40);
            textBoxEmplacement.Multiline = true;
            textBoxEmplacement.Name = "textBoxEmplacement";
            textBoxEmplacement.Size = new Size(289, 96);
            textBoxEmplacement.TabIndex = 11;
            // 
            // textBoxCommentaire
            // 
            textBoxCommentaire.Location = new Point(352, 193);
            textBoxCommentaire.Multiline = true;
            textBoxCommentaire.Name = "textBoxCommentaire";
            textBoxCommentaire.Size = new Size(279, 112);
            textBoxCommentaire.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(352, 17);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 13;
            label1.Text = "Emplacement";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(352, 170);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 14;
            label2.Text = "Commentaire";
            // 
            // FenetreAjoutMateriel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(653, 427);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxCommentaire);
            Controls.Add(textBoxEmplacement);
            Controls.Add(comboBoxCategorie);
            Controls.Add(labelCategorie);
            Controls.Add(textBoxIpMateriel);
            Controls.Add(comboBoxEtage);
            Controls.Add(labelIP);
            Controls.Add(labelEtage);
            Controls.Add(labelMateriel);
            Controls.Add(textBoxNomMateriel);
            Controls.Add(BoutonSauvegarder);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FenetreAjoutMateriel";
            Text = "ajout d'un élément";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BoutonSauvegarder;
        private TextBox textBoxNomMateriel;
        private Label labelMateriel;
        private Label labelEtage;
        private Label labelIP;
        private ComboBox comboBoxEtage;
        private TextBox textBoxIpMateriel;
        private Label labelCategorie;
        private ComboBox comboBoxCategorie;
        private TextBox textBoxEmplacement;
        private TextBox textBoxCommentaire;
        private Label label1;
        private Label label2;
    }
}