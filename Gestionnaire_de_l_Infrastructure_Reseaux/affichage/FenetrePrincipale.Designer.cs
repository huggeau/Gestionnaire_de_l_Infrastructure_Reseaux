﻿namespace Gestionnaire_de_l_Infrastructure_Reseaux
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
            menuStrip1 = new MenuStrip();
            modificationToolStripMenuItem = new ToolStripMenuItem();
            ajouterToolStripMenuItem = new ToolStripMenuItem();
            supprimerToolStripMenuItem = new ToolStripMenuItem();
            rechercheToolStripMenuItem = new ToolStripMenuItem();
            boutonTest = new Button();
            MairiePrincipale = new TextBox();
            timer = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { modificationToolStripMenuItem, rechercheToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1279, 28);
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
            // boutonTest
            // 
            boutonTest.Location = new Point(594, 214);
            boutonTest.Name = "boutonTest";
            boutonTest.Size = new Size(94, 29);
            boutonTest.TabIndex = 1;
            boutonTest.Text = "test";
            boutonTest.UseVisualStyleBackColor = true;
            boutonTest.Click += boutonTest_Click;
            // 
            // MairiePrincipale
            // 
            MairiePrincipale.BackColor = SystemColors.Highlight;
            MairiePrincipale.Enabled = false;
            MairiePrincipale.Location = new Point(570, 249);
            MairiePrincipale.Multiline = true;
            MairiePrincipale.Name = "MairiePrincipale";
            MairiePrincipale.Size = new Size(156, 130);
            MairiePrincipale.TabIndex = 2;
            MairiePrincipale.Text = "                                   Mairie Principale\r\n";
            MairiePrincipale.TextAlign = HorizontalAlignment.Center;
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // FenetrePrincipale
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1279, 607);
            Controls.Add(MairiePrincipale);
            Controls.Add(boutonTest);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FenetrePrincipale";
            Text = "Fenêtre principale";
            FormClosing += FenetrePrincipale_FormClosing;
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
        private ToolStripMenuItem rechercheToolStripMenuItem;
        private Button boutonTest;
        private TextBox MairiePrincipale;
        private System.Windows.Forms.Timer timer;
    }
}
