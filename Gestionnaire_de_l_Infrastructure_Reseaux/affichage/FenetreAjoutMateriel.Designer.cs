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
            labelSite = new Label();
            labelEtage = new Label();
            labelIP = new Label();
            comboBoxEtage = new ComboBox();
            comboBoxSite = new ComboBox();
            textBoxIpMateriel = new TextBox();
            labelCategorie = new Label();
            comboBoxCategorie = new ComboBox();
            SuspendLayout();
            // 
            // BoutonSauvegarder
            // 
            BoutonSauvegarder.Location = new Point(12, 409);
            BoutonSauvegarder.Name = "BoutonSauvegarder";
            BoutonSauvegarder.Size = new Size(102, 29);
            BoutonSauvegarder.TabIndex = 0;
            BoutonSauvegarder.Text = "sauvegarder";
            BoutonSauvegarder.UseVisualStyleBackColor = true;
            // 
            // textBoxNomMateriel
            // 
            textBoxNomMateriel.Location = new Point(12, 40);
            textBoxNomMateriel.Name = "textBoxNomMateriel";
            textBoxNomMateriel.Size = new Size(218, 27);
            textBoxNomMateriel.TabIndex = 1;
            // 
            // labelMateriel
            // 
            labelMateriel.AutoSize = true;
            labelMateriel.Location = new Point(12, 17);
            labelMateriel.Name = "labelMateriel";
            labelMateriel.Size = new Size(122, 20);
            labelMateriel.TabIndex = 2;
            labelMateriel.Text = "Nom du Materiel";
            // 
            // labelSite
            // 
            labelSite.AutoSize = true;
            labelSite.Location = new Point(12, 116);
            labelSite.Name = "labelSite";
            labelSite.Size = new Size(114, 20);
            labelSite.TabIndex = 3;
            labelSite.Text = "Site du Materiel";
            // 
            // labelEtage
            // 
            labelEtage.AutoSize = true;
            labelEtage.Location = new Point(359, 116);
            labelEtage.Name = "labelEtage";
            labelEtage.Size = new Size(127, 20);
            labelEtage.TabIndex = 4;
            labelEtage.Text = "etage du Materiel";
            // 
            // labelIP
            // 
            labelIP.AutoSize = true;
            labelIP.Location = new Point(359, 17);
            labelIP.Name = "labelIP";
            labelIP.Size = new Size(102, 20);
            labelIP.TabIndex = 5;
            labelIP.Text = "Ip du Materiel";
            // 
            // comboBoxEtage
            // 
            comboBoxEtage.FormattingEnabled = true;
            comboBoxEtage.Location = new Point(363, 148);
            comboBoxEtage.Name = "comboBoxEtage";
            comboBoxEtage.Size = new Size(151, 28);
            comboBoxEtage.TabIndex = 6;
            // 
            // comboBoxSite
            // 
            comboBoxSite.FormattingEnabled = true;
            comboBoxSite.Location = new Point(12, 148);
            comboBoxSite.Name = "comboBoxSite";
            comboBoxSite.Size = new Size(151, 28);
            comboBoxSite.TabIndex = 7;
            // 
            // textBoxIpMateriel
            // 
            textBoxIpMateriel.Location = new Point(359, 40);
            textBoxIpMateriel.Name = "textBoxIpMateriel";
            textBoxIpMateriel.Size = new Size(168, 27);
            textBoxIpMateriel.TabIndex = 8;
            // 
            // labelCategorie
            // 
            labelCategorie.AutoSize = true;
            labelCategorie.Location = new Point(15, 228);
            labelCategorie.Name = "labelCategorie";
            labelCategorie.Size = new Size(154, 20);
            labelCategorie.TabIndex = 9;
            labelCategorie.Text = "Categorie de Materiel";
            // 
            // comboBoxCategorie
            // 
            comboBoxCategorie.FormattingEnabled = true;
            comboBoxCategorie.Location = new Point(12, 251);
            comboBoxCategorie.Name = "comboBoxCategorie";
            comboBoxCategorie.Size = new Size(151, 28);
            comboBoxCategorie.TabIndex = 10;
            // 
            // FenetreAjout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 481);
            Controls.Add(comboBoxCategorie);
            Controls.Add(labelCategorie);
            Controls.Add(textBoxIpMateriel);
            Controls.Add(comboBoxSite);
            Controls.Add(comboBoxEtage);
            Controls.Add(labelIP);
            Controls.Add(labelEtage);
            Controls.Add(labelSite);
            Controls.Add(labelMateriel);
            Controls.Add(textBoxNomMateriel);
            Controls.Add(BoutonSauvegarder);
            Name = "FenetreAjout";
            Text = "ajout d'un élément";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BoutonSauvegarder;
        private TextBox textBoxNomMateriel;
        private Label labelMateriel;
        private Label labelSite;
        private Label labelEtage;
        private Label labelIP;
        private ComboBox comboBoxEtage;
        private ComboBox comboBoxSite;
        private TextBox textBoxIpMateriel;
        private Label labelCategorie;
        private ComboBox comboBoxCategorie;
    }
}