﻿namespace Gestionnaire_de_l_Infrastructure_Reseaux
{
    partial class FenetreSupprimerMateriel
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
            BoutonSupprimer = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // BoutonSupprimer
            // 
            BoutonSupprimer.Location = new Point(104, 66);
            BoutonSupprimer.Name = "BoutonSupprimer";
            BoutonSupprimer.Size = new Size(105, 29);
            BoutonSupprimer.TabIndex = 0;
            BoutonSupprimer.Text = "supprimer";
            BoutonSupprimer.UseVisualStyleBackColor = true;
            BoutonSupprimer.Click += BoutonSupprimer_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(63, 28);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(194, 28);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 5);
            label1.Name = "label1";
            label1.Size = new Size(147, 20);
            label1.TabIndex = 2;
            label1.Text = "matériel à supprimer";
            // 
            // FenetreSupprimerMateriel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 107);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(BoutonSupprimer);
            Name = "FenetreSupprimerMateriel";
            Text = "supprimer un élément";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BoutonSupprimer;
        private ComboBox comboBox1;
        private Label label1;
    }
}