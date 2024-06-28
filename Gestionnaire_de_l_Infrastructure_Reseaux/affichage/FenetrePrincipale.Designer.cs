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
            panel2 = new Panel();
            MairieAnnexeTextBox = new TextBox();
            boutonMairieAnnexe = new Button();
            panel3 = new Panel();
            AgoraTextBox = new TextBox();
            boutonAgora = new Button();
            panel4 = new Panel();
            CTMTextBox = new TextBox();
            boutonCTM = new Button();
            panel9 = new Panel();
            CentreBournotTextBox = new TextBox();
            BoutonCentreBournot = new Button();
            panel10 = new Panel();
            PMTextBox = new TextBox();
            boutonPM = new Button();
            menuStripFenetrePrincipale.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel9.SuspendLayout();
            panel10.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripFenetrePrincipale
            // 
            menuStripFenetrePrincipale.ImageScalingSize = new Size(20, 20);
            menuStripFenetrePrincipale.Items.AddRange(new ToolStripItem[] { modificationToolStripMenuItem, rechercheToolStripMenuItem, forcerUnPingToolStripMenuItem });
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
            // boutonTest
            // 
            boutonTest.ForeColor = SystemColors.InfoText;
            boutonTest.Location = new Point(3, 3);
            boutonTest.Name = "boutonTest";
            boutonTest.Size = new Size(147, 29);
            boutonTest.TabIndex = 1;
            boutonTest.Text = "Mairie Principale";
            boutonTest.UseVisualStyleBackColor = true;
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
            MairiePrincipaleTextBlock.Size = new Size(149, 46);
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
            panel1.Location = new Point(640, 477);
            panel1.Name = "panel1";
            panel1.Size = new Size(156, 97);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(MairieAnnexeTextBox);
            panel2.Controls.Add(boutonMairieAnnexe);
            panel2.Location = new Point(408, 328);
            panel2.Name = "panel2";
            panel2.Size = new Size(165, 98);
            panel2.TabIndex = 4;
            // 
            // MairieAnnexeTextBox
            // 
            MairieAnnexeTextBox.Enabled = false;
            MairieAnnexeTextBox.Location = new Point(3, 38);
            MairieAnnexeTextBox.Multiline = true;
            MairieAnnexeTextBox.Name = "MairieAnnexeTextBox";
            MairieAnnexeTextBox.Size = new Size(157, 47);
            MairieAnnexeTextBox.TabIndex = 1;
            // 
            // boutonMairieAnnexe
            // 
            boutonMairieAnnexe.ForeColor = SystemColors.WindowText;
            boutonMairieAnnexe.Location = new Point(3, 3);
            boutonMairieAnnexe.Name = "boutonMairieAnnexe";
            boutonMairieAnnexe.Size = new Size(157, 29);
            boutonMairieAnnexe.TabIndex = 0;
            boutonMairieAnnexe.Text = "Mairie Annexe";
            boutonMairieAnnexe.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(AgoraTextBox);
            panel3.Controls.Add(boutonAgora);
            panel3.Location = new Point(636, 328);
            panel3.Name = "panel3";
            panel3.Size = new Size(165, 98);
            panel3.TabIndex = 5;
            // 
            // AgoraTextBox
            // 
            AgoraTextBox.Enabled = false;
            AgoraTextBox.Location = new Point(3, 38);
            AgoraTextBox.Multiline = true;
            AgoraTextBox.Name = "AgoraTextBox";
            AgoraTextBox.Size = new Size(157, 47);
            AgoraTextBox.TabIndex = 1;
            // 
            // boutonAgora
            // 
            boutonAgora.ForeColor = SystemColors.WindowText;
            boutonAgora.Location = new Point(3, 3);
            boutonAgora.Name = "boutonAgora";
            boutonAgora.Size = new Size(157, 29);
            boutonAgora.TabIndex = 0;
            boutonAgora.Text = "Agora";
            boutonAgora.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(CTMTextBox);
            panel4.Controls.Add(boutonCTM);
            panel4.Location = new Point(408, 188);
            panel4.Name = "panel4";
            panel4.Size = new Size(165, 98);
            panel4.TabIndex = 6;
            // 
            // CTMTextBox
            // 
            CTMTextBox.Enabled = false;
            CTMTextBox.Location = new Point(3, 38);
            CTMTextBox.Multiline = true;
            CTMTextBox.Name = "CTMTextBox";
            CTMTextBox.Size = new Size(157, 47);
            CTMTextBox.TabIndex = 1;
            // 
            // boutonCTM
            // 
            boutonCTM.ForeColor = SystemColors.WindowText;
            boutonCTM.Location = new Point(3, 3);
            boutonCTM.Name = "boutonCTM";
            boutonCTM.Size = new Size(157, 29);
            boutonCTM.TabIndex = 0;
            boutonCTM.Text = "CTM";
            boutonCTM.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(CentreBournotTextBox);
            panel9.Controls.Add(BoutonCentreBournot);
            panel9.Location = new Point(867, 445);
            panel9.Name = "panel9";
            panel9.Size = new Size(165, 98);
            panel9.TabIndex = 11;
            // 
            // CentreBournotTextBox
            // 
            CentreBournotTextBox.Enabled = false;
            CentreBournotTextBox.Location = new Point(3, 38);
            CentreBournotTextBox.Multiline = true;
            CentreBournotTextBox.Name = "CentreBournotTextBox";
            CentreBournotTextBox.Size = new Size(157, 47);
            CentreBournotTextBox.TabIndex = 1;
            // 
            // BoutonCentreBournot
            // 
            BoutonCentreBournot.ForeColor = SystemColors.WindowText;
            BoutonCentreBournot.Location = new Point(3, 3);
            BoutonCentreBournot.Name = "BoutonCentreBournot";
            BoutonCentreBournot.Size = new Size(157, 29);
            BoutonCentreBournot.TabIndex = 0;
            BoutonCentreBournot.Text = "Centre le Bournot";
            BoutonCentreBournot.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(PMTextBox);
            panel10.Controls.Add(boutonPM);
            panel10.Location = new Point(871, 584);
            panel10.Name = "panel10";
            panel10.Size = new Size(165, 98);
            panel10.TabIndex = 12;
            // 
            // PMTextBox
            // 
            PMTextBox.Enabled = false;
            PMTextBox.Location = new Point(3, 38);
            PMTextBox.Multiline = true;
            PMTextBox.Name = "PMTextBox";
            PMTextBox.Size = new Size(157, 47);
            PMTextBox.TabIndex = 1;
            // 
            // boutonPM
            // 
            boutonPM.ForeColor = SystemColors.WindowText;
            boutonPM.Location = new Point(3, 3);
            boutonPM.Name = "boutonPM";
            boutonPM.Size = new Size(157, 29);
            boutonPM.TabIndex = 0;
            boutonPM.Text = "Police Municipale";
            boutonPM.UseVisualStyleBackColor = true;
            // 
            // FenetrePrincipale
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(1513, 729);
            Controls.Add(panel10);
            Controls.Add(panel9);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStripFenetrePrincipale);
            ForeColor = SystemColors.Window;
            MainMenuStrip = menuStripFenetrePrincipale;
            Name = "FenetrePrincipale";
            Text = "Fenêtre principale";
            FormClosing += FenetrePrincipale_FormClosing;
            menuStripFenetrePrincipale.ResumeLayout(false);
            menuStripFenetrePrincipale.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
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
        private Panel panel2;
        private TextBox MairieAnnexeTextBox;
        private Button boutonMairieAnnexe;
        private Panel panel3;
        private TextBox AgoraTextBox;
        private Button boutonAgora;
        private Panel panel4;
        private TextBox CTMTextBox;
        private Button boutonCTM;
        private Panel panel9;
        private TextBox CentreBournotTextBox;
        private Button BoutonCentreBournot;
        private Panel panel10;
        private TextBox PMTextBox;
        private Button boutonPM;
    }
}
