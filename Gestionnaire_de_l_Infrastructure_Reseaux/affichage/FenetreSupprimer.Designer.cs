namespace Gestionnaire_de_l_Infrastructure_Reseaux
{
    partial class FenetreSupprimer
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
            SuspendLayout();
            // 
            // BoutonSauvegarder
            // 
            BoutonSauvegarder.Location = new Point(12, 409);
            BoutonSauvegarder.Name = "BoutonSauvegarder";
            BoutonSauvegarder.Size = new Size(105, 29);
            BoutonSauvegarder.TabIndex = 0;
            BoutonSauvegarder.Text = "sauvegarder";
            BoutonSauvegarder.UseVisualStyleBackColor = true;
            // 
            // FenetreSupprimer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BoutonSauvegarder);
            Name = "FenetreSupprimer";
            Text = "supprimer un élément";
            ResumeLayout(false);
        }

        #endregion

        private Button BoutonSauvegarder;
    }
}