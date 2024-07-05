using Gestionnaire_de_l_Infrastructure_Reseaux.affichage;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

namespace Gestionnaire_de_l_Infrastructure_Reseaux
{
    public partial class FenetreAjoutMateriel : Form
    {
        private Communication comm = new Communication();
        private int idSite;
        public FenetreAjoutMateriel(int id)
        {
            InitializeComponent();

            idSite = id;
            RemplirComboBoxEtage();
            RemplirComboBoxCategorie();
        }
        // sert a remplir des combobox
        public void RemplirComboBoxEtage()
        {
            string query = "SELECT id, nom FROM etage";

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(query, connection);
                connection.Open();
                MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);

                    comboBoxEtage.Items.Add(new ComboBoxItem(id, name));
                }
                reader.Close();
            }
            comboBoxEtage.DisplayMember = "Name"; // Propriété à afficher
            comboBoxEtage.ValueMember = "Id"; // Valeur utilisée en interne
        }
        public void RemplirComboBoxCategorie()
        {
            string query = "SELECT id, nom FROM categorie_de_materiel";

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(query, connection);
                connection.Open();
                MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);

                    comboBoxCategorie.Items.Add(new ComboBoxItem(id, name));
                }
                reader.Close();
            }
            comboBoxCategorie.DisplayMember = "Name"; // Propriété à afficher
            comboBoxCategorie.ValueMember = "Id"; // Valeur utilisée en interne
        }

        // sert à enregistrer un nouveau materiel dans la bdd appartenant au site sur lequel on a ouvert la fenetre d'administration 
        private void BoutonSauvegarder_Click(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                //viens mettre en mémoire les éléments choisi des combobox
                var selectedEtage = comboBoxEtage.SelectedItem as ComboBoxItem;
                int idEtage = selectedEtage.Id;

                var selectedCategorie = comboBoxCategorie.SelectedItem as ComboBoxItem;
                int idCategorie = selectedCategorie.Id;
                connection.Open();

                //viens regarder si l'addresse ip est bien écrite et qu'il y a un nom au materiel
                if (IpValid(textBoxIpMateriel.Text) && textBoxNomMateriel.Text != null)
                {
                    string insertQuery = $"INSERT INTO Materiel_Reseau (id, ip, nom, id_site, id_etage, id_categorie_de_materiel, emplacement, commentaire " +
                    $") VALUES (NUll, '{textBoxIpMateriel.Text}', '{textBoxNomMateriel.Text}', '{idSite}', '{idEtage}', '{idCategorie}', '{textBoxEmplacement.Text}', '{textBoxCommentaire.Text}');";
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
                    MessageBox.Show("l'addresse ip que vous avez rentré n'en ai pas une veuillez la réecrire\r\n " +
                        "ou vous n'avez rien écrit en guise de nom ", "formulation incorrect");
                }
                
            }
        }

        //sert a créer un regex pour l'ip
        private bool IpValid(string ip)
        {
            // sert a créer un regex qui va permettre de tester si lip écrite est correctement écrite
            string regexIpv4 = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

            Regex ipValid = new Regex(regexIpv4);

            return ipValid.IsMatch(ip);
        }
    }
}
