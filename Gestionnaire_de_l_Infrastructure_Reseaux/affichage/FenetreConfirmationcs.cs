using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestionnaire_de_l_Infrastructure_Reseaux.affichage
{
    public partial class FenetreConfirmationcs : Form
    {
        public FenetreConfirmationcs()
        {
            InitializeComponent();
        }

        //cette fenetre sert lors de la suppression d'un élément a confirmer notre choix

        //fenêtre servant a savoir si vous voule vraiment accepter la suppression de l'élément choisi
        private void button1_Click(object sender, EventArgs e)
        {
            //sert a renvoyer un résultat positif a la fenetre qui a ouvert celle ci 
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sert a envoyer un résultat négatif a la fenetre qui a ouvert celle ci
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
