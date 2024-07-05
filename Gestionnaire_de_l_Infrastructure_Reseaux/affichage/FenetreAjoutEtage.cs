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

namespace Gestionnaire_de_l_Infrastructure_Reseaux.affichage
{
    public partial class FenetreAjoutEtage : Form
    {
        private Communication comm = new Communication();
        public FenetreAjoutEtage()
        {
            InitializeComponent();
        }

        //rajoute un étage dans la bdd
        private void button1_Click(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                connection.Open();
                // regarde si le textbox n'est pas vide
                if (textBox1.Text != null)
                {
                    // si vraie alors il insère dans la table etage, la valeur donné dans la textbox
                    string insertQuery = $"INSERT INTO etage (id, nom) VALUES (NUll, '{textBox1.Text}');";
                    using (var command = new MySqlConnector.MySqlCommand(insertQuery, connection))
                    {
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                    this.Close();
                }
                else
                {
                    //si faux aors montre une alerte qui dit que le champs est vide
                    MessageBox.Show("vous n'avez pas donner de nom a cette étage ou batiment", "erreur de saisie");
                }
            }
            
        }
    }
}
