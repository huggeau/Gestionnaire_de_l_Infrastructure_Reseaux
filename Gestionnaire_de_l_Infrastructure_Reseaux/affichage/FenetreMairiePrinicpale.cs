using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestionnaire_de_l_Infrastructure_Reseaux
{
    public partial class FenetreMairiePrinicpale : Form
    {
        public FenetreMairiePrinicpale()
        {
            InitializeComponent();
            
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FenetreAjout fenetreAjout = new FenetreAjout();
            fenetreAjout.ShowDialog();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FenetreSupprimer fenetreSupprimer = new FenetreSupprimer();
            fenetreSupprimer.ShowDialog();
        }
    }
}
