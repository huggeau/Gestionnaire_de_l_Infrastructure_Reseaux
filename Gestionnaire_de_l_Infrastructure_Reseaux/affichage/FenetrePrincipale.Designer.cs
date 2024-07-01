namespace Gestionnaire_de_l_Infrastructure_Reseaux
{
    partial class FenetrePrincipale
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
            components = new System.ComponentModel.Container();
            menuStripFenetrePrincipale = new MenuStrip();
            modificationToolStripMenuItem = new ToolStripMenuItem();
            ajouterToolStripMenuItem = new ToolStripMenuItem();
            supprimerToolStripMenuItem = new ToolStripMenuItem();
            rechercheToolStripMenuItem = new ToolStripMenuItem();
            forcerUnPingToolStripMenuItem = new ToolStripMenuItem();
            activerLeDeplacementDesPanelsToolStripMenuItem = new ToolStripMenuItem();
            timerFenetrePrinicipale = new System.Windows.Forms.Timer(components);
            menuStripFenetrePrincipale.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripFenetrePrincipale
            // 
            menuStripFenetrePrincipale.ImageScalingSize = new Size(20, 20);
            menuStripFenetrePrincipale.Items.AddRange(new ToolStripItem[] { modificationToolStripMenuItem, rechercheToolStripMenuItem, forcerUnPingToolStripMenuItem, activerLeDeplacementDesPanelsToolStripMenuItem });
            menuStripFenetrePrincipale.Location = new Point(0, 0);
            menuStripFenetrePrincipale.Name = "menuStripFenetrePrincipale";
            menuStripFenetrePrincipale.Size = new Size(1513, 28);
            menuStripFenetrePrincipale.TabIndex = 0;
            menuStripFenetrePrincipale.Text = "menuStripFenetrePrincipale";
            // 
            // modificationToolStripMenuItem
            // 
            modificationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ajouterToolStripMenuItem, supprimerToolStripMenuItem });
            modificationToolStripMenuItem.Name = "modificationToolStripMenuItem";
            modificationToolStripMenuItem.Size = new Size(108, 24);
            modificationToolStripMenuItem.Text = "modification";
            // 
            // ajouterToolStripMenuItem
            // 
            ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            ajouterToolStripMenuItem.Size = new Size(159, 26);
            ajouterToolStripMenuItem.Text = "ajouter";
            ajouterToolStripMenuItem.Click += ajouterToolStripMenuItem_Click;
            // 
            // supprimerToolStripMenuItem
            // 
            supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            supprimerToolStripMenuItem.Size = new Size(159, 26);
            supprimerToolStripMenuItem.Text = "supprimer";
            supprimerToolStripMenuItem.Click += supprimerToolStripMenuItem_Click;
            // 
            // rechercheToolStripMenuItem
            // 
            rechercheToolStripMenuItem.Name = "rechercheToolStripMenuItem";
            rechercheToolStripMenuItem.Size = new Size(87, 24);
            rechercheToolStripMenuItem.Text = "recherche";
            rechercheToolStripMenuItem.Click += rechercheToolStripMenuItem_Click;
            // 
            // forcerUnPingToolStripMenuItem
            // 
            forcerUnPingToolStripMenuItem.Name = "forcerUnPingToolStripMenuItem";
            forcerUnPingToolStripMenuItem.Size = new Size(116, 24);
            forcerUnPingToolStripMenuItem.Text = "forcer un ping";
            forcerUnPingToolStripMenuItem.Click += forcerUnPingToolStripMenuItem_Click;
            // 
            // activerLeDeplacementDesPanelsToolStripMenuItem
            // 
            activerLeDeplacementDesPanelsToolStripMenuItem.Name = "activerLeDeplacementDesPanelsToolStripMenuItem";
            activerLeDeplacementDesPanelsToolStripMenuItem.Size = new Size(250, 24);
            activerLeDeplacementDesPanelsToolStripMenuItem.Text = "Activer le Deplacement des Panels";
            activerLeDeplacementDesPanelsToolStripMenuItem.Click += activerLeDeplacementDesPanelsToolStripMenuItem_Click;
            // 
            // timerFenetrePrinicipale
            // 
            timerFenetrePrinicipale.Interval = 360000;
            timerFenetrePrinicipale.Tick += timer_Tick;
            // 
            // FenetrePrincipale
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(1513, 729);
            Controls.Add(menuStripFenetrePrincipale);
            ForeColor = SystemColors.Window;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStripFenetrePrincipale;
            Name = "FenetrePrincipale";
            Text = "Fenêtre principale";
            WindowState = FormWindowState.Maximized;
            FormClosing += FenetrePrincipale_FormClosing;
            menuStripFenetrePrincipale.ResumeLayout(false);
            menuStripFenetrePrincipale.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStripFenetrePrincipale;
        private ToolStripMenuItem modificationToolStripMenuItem;
        private ToolStripMenuItem ajouterToolStripMenuItem;
        private ToolStripMenuItem supprimerToolStripMenuItem;
        private ToolStripMenuItem rechercheToolStripMenuItem;
        private System.Windows.Forms.Timer timerFenetrePrinicipale;
        private ToolStripMenuItem forcerUnPingToolStripMenuItem;
        private ToolStripMenuItem activerLeDeplacementDesPanelsToolStripMenuItem;
    }
}
