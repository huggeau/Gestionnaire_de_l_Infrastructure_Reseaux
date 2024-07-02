namespace Gestionnaire_de_l_Infrastructure_Reseaux
{
    partial class FenetreAdministrationSite
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            modificationToolStripMenuItem = new ToolStripMenuItem();
            ajouterToolStripMenuItem = new ToolStripMenuItem();
            supprimerToolStripMenuItem = new ToolStripMenuItem();
            panelPrinicpale = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            forcerPingToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { modificationToolStripMenuItem, forcerPingToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(858, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
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
            ajouterToolStripMenuItem.Size = new Size(224, 26);
            ajouterToolStripMenuItem.Text = "ajouter";
            ajouterToolStripMenuItem.Click += ajouterToolStripMenuItem_Click;
            // 
            // supprimerToolStripMenuItem
            // 
            supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            supprimerToolStripMenuItem.Size = new Size(224, 26);
            supprimerToolStripMenuItem.Text = "supprimer";
            supprimerToolStripMenuItem.Click += supprimerToolStripMenuItem_Click;
            // 
            // panelPrinicpale
            // 
            panelPrinicpale.Dock = DockStyle.Fill;
            panelPrinicpale.Location = new Point(0, 28);
            panelPrinicpale.Name = "panelPrinicpale";
            panelPrinicpale.Size = new Size(858, 564);
            panelPrinicpale.TabIndex = 1;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 10000;
            timer1.Tick += timer1_Tick;
            // 
            // forcerPingToolStripMenuItem
            // 
            forcerPingToolStripMenuItem.Name = "forcerPingToolStripMenuItem";
            forcerPingToolStripMenuItem.Size = new Size(96, 24);
            forcerPingToolStripMenuItem.Text = "forcer ping";
            forcerPingToolStripMenuItem.Click += forcerPingToolStripMenuItem_Click;
            // 
            // FenetreAdministrationSite
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 592);
            Controls.Add(panelPrinicpale);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FenetreAdministrationSite";
            Text = "Fenêtre d'Administration";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem modificationToolStripMenuItem;
        private ToolStripMenuItem ajouterToolStripMenuItem;
        private ToolStripMenuItem supprimerToolStripMenuItem;
        private Panel panelPrinicpale;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem forcerPingToolStripMenuItem;
    }
}