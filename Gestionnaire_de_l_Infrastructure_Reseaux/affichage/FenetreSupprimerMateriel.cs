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

namespace Gestionnaire_de_l_Infrastructure_Reseaux
{
    public partial class FenetreSupprimerMateriel : Form
    {
        private Communication comm = new Communication();
        private int idSite;
        public FenetreSupprimerMateriel(int id)
        {
            InitializeComponent();

            idSite = id;
            RemplirComboBox();
        }


        private void RemplirComboBox()
        {
            string query = $"SELECT id, nom FROM Materiel_Reseau WHERE id_site = {idSite}";

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

        private void BoutonSupprimer_Click(object sender, EventArgs e)
        {
            FenetreConfirmationcs fenetreConfirmationcs = new FenetreConfirmationcs();
            DialogResult result = fenetreConfirmationcs.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show("élément supprimer de la base de données ");
            }
            else
            {
                MessageBox.Show("élément non-supprimer de la base de données");
            }
        }

        private void SupprimerElement()
        {
            int id;
            var selectedId = comboBox1.SelectedItem as ComboBoxItem;
            id = selectedId.Id;
            string query = $"DELETE FROM Materiel_Reseau WHERE id = {id}";

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
        }
    }
}
