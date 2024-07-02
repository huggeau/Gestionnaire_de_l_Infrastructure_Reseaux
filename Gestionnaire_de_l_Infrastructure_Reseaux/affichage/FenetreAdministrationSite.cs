using Gestionnaire_de_l_Infrastructure_Reseaux.métier;
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
    public partial class FenetreAdministrationSite : Form
    {
        private int idSite;
        private Communication comm = new Communication();
        private int taille = 230;
        public FenetreAdministrationSite(int id)
        {
            InitializeComponent();
            idSite = id;

            AfficherTextBox();
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

        public void AfficherTextBox()
        {
            List<int> listIds = comm.RemplirListSite();

            
            foreach (int id in listIds)
            {
                if (id == idSite)
                {
                    string query = $"SELECT * FROM Materiel_Reseau WHERE id_site = {id};";
                    using (MySqlConnector.MySqlConnection conn = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
                    {
                        MySqlConnector.MySqlCommand cmd = new MySqlConnector.MySqlCommand(query, conn);
                        conn.Open();
                        MySqlConnector.MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            int largeur = this.panelPrinicpale.Width;
                            int nombre = panelPrinicpale.Controls.Count;
                            int nombreMaxParLigne = largeur / taille;
                            int nombreDeLigne = nombre / nombreMaxParLigne;
                            int numLigne = nombre / nombreMaxParLigne;
                            int colonne = nombre - (nombreMaxParLigne * numLigne);

                            string ip = reader.GetString(1);
                            string name = reader.GetString(2);
                            int etage = reader.GetInt32(4);
                            int categorie_de_materiel = reader.GetInt32(5);


                            Panel panel = new Panel
                            {
                                Size = new Size(230, 53),
                                Location = new Point(colonne * taille , numLigne * taille),
                                Enabled = false,
                            };

                            Label label = new Label
                            {
                                Text = $"{ip}\r\n{name}",
                                Dock = DockStyle.Fill,
                                TextAlign = ContentAlignment.MiddleCenter
                            };
                            panel.Controls.Add(label);

                            if (comm.PingSpecifique(ip))
                            {
                                panel.BackColor = Color.Green;
                            }
                            else
                            {
                                panel.BackColor= Color.Red;
                            }

                            panelPrinicpale.Controls.Add(panel);
                        }
                    }
                }
            }
        }
    }
}
