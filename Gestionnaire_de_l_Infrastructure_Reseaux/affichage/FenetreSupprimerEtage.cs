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
    public partial class FenetreSupprimerEtage : Form
    {
        private Communication comm = new Communication();
        public FenetreSupprimerEtage()
        {
            InitializeComponent();

            RemplirComboBox();
        }

        //sert a remplir tout les étages afin de pouvoir choisir lequel supprimer
        private void RemplirComboBox()
        {
            string query = $"SELECT id, nom FROM etage;";

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(query, connection);
                connection.Open();
                MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);

                    comboBox1.Items.Add(new ComboBoxItem(id, name));
                }
                reader.Close();
            }
            comboBox1.DisplayMember = "Name"; // Propriété à afficher
            comboBox1.ValueMember = "Id"; // Valeur utilisée en interne
        }

        //sert a ouvrir la fenetre de confirmation afin de savoir si c'est vraiment ce que vous voulez faire
        private void button1_Click(object sender, EventArgs e)
        {
            FenetreConfirmationcs fenetreConfirmationcs = new FenetreConfirmationcs();
            DialogResult result = fenetreConfirmationcs.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (SupprimerElement())
                {
                    MessageBox.Show("élément supprimer de la base de données ");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("élément non-supprimer de la base de données");
                this.Close();
            }
        }


        //supprime l'élément de la bdd
        private bool SupprimerElement()
        {
            bool flag = false;
            int id;
            var selectedId = comboBox1.SelectedItem as ComboBoxItem;
            if (selectedId != null)
            {
                id = selectedId.Id;
                string query = $"DELETE FROM etage WHERE id = {id}";

                using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
                {
                    MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(query, connection);
                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                flag = true;
            }
            else
            {
                MessageBox.Show("vous n'avez rien choisi", "erreur de saisie");
            }
            return flag;
        }
    }
}
