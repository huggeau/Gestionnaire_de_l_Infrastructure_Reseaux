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
            boutonTest = new Button();
            MairiePrincipaleTextBlock = new TextBox();
            timerFenetrePrinicipale = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            menuStripFenetrePrincipale.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripFenetrePrincipale
            // 
            menuStripFenetrePrincipale.ImageScalingSize = new Size(20, 20);
            menuStripFenetrePrincipale.Items.AddRange(new ToolStripItem[] { modificationToolStripMenuItem, rechercheToolStripMenuItem, forcerUnPingToolStripMenuItem });
            menuStripFenetrePrincipale.Location = new Point(0, 0);
            menuStripFenetrePrincipale.Name = "menuStripFenetrePrincipale";
            menuStripFenetrePrincipale.Size = new Size(1279, 28);
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
            // boutonTest
            // 
            boutonTest.ForeColor = SystemColors.InfoText;
            boutonTest.Location = new Point(5, 3);
            boutonTest.Name = "boutonTest";
            boutonTest.Size = new Size(147, 29);
            boutonTest.TabIndex = 1;
            boutonTest.Text = "Mairie Principale";
            boutonTest.UseVisualStyleBackColor = true;
            boutonTest.Click += boutonMairiePrincipale;
            // 
            // MairiePrincipaleTextBlock
            // 
            MairiePrincipaleTextBlock.BackColor = SystemColors.ButtonHighlight;
            MairiePrincipaleTextBlock.BorderStyle = BorderStyle.FixedSingle;
            MairiePrincipaleTextBlock.Enabled = false;
            MairiePrincipaleTextBlock.Font = new Font("Segoe UI", 9F);
            MairiePrincipaleTextBlock.ForeColor = SystemColors.ActiveCaptionText;
            MairiePrincipaleTextBlock.Location = new Point(3, 38);
            MairiePrincipaleTextBlock.Multiline = true;
            MairiePrincipaleTextBlock.Name = "MairiePrincipaleTextBlock";
            MairiePrincipaleTextBlock.Size = new Size(147, 125);
            MairiePrincipaleTextBlock.TabIndex = 2;
            MairiePrincipaleTextBlock.TextAlign = HorizontalAlignment.Center;
            // 
            // timerFenetrePrinicipale
            // 
            timerFenetrePrinicipale.Interval = 360000;
            timerFenetrePrinicipale.Tick += timer_Tick;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(MairiePrincipaleTextBlock);
            panel1.Controls.Add(boutonTest);
            panel1.Location = new Point(526, 218);
            panel1.Name = "panel1";
            panel1.Size = new Size(157, 170);
            panel1.TabIndex = 3;
            // 
            // FenetrePrincipale
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(1279, 607);
            Controls.Add(panel1);
            Controls.Add(menuStripFenetrePrincipale);
            ForeColor = SystemColors.Window;
            MainMenuStrip = menuStripFenetrePrincipale;
            Name = "FenetrePrincipale";
            Text = "Fenêtre principale";
            menuStripFenetrePrincipale.ResumeLayout(false);
            menuStripFenetrePrincipale.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStripFenetrePrincipale;
        private ToolStripMenuItem modificationToolStripMenuItem;
        private ToolStripMenuItem ajouterToolStripMenuItem;
        private ToolStripMenuItem supprimerToolStripMenuItem;
        private ToolStripMenuItem rechercheToolStripMenuItem;
        private Button boutonTest;
        private TextBox MairiePrincipaleTextBlock;
        private System.Windows.Forms.Timer timerFenetrePrinicipale;
        private ToolStripMenuItem forcerUnPingToolStripMenuItem;
        private Panel panel1;
    }
}
