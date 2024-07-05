using Gestionnaire_de_l_Infrastructure_Reseaux.métier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestionnaire_de_l_Infrastructure_Reseaux.affichage
{
    public partial class FenetreSupprimerSite : Form
    {
        private Communication comm = new Communication();
        public FenetreSupprimerSite()
        {
            InitializeComponent();

            RemplirComboBox();
        }

        private void RemplirComboBox()
        {
            string query = $"SELECT id, nom FROM Site";

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
        private void SupprimerElement()
        {
            int id;
            var selectedId = comboBox1.SelectedItem as ComboBoxItem;
            id = selectedId.Id;
            string query = $"DELETE FROM Site WHERE id = {id}";

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FenetreConfirmationcs fenetreConfirmationcs = new FenetreConfirmationcs();
            DialogResult result = fenetreConfirmationcs.ShowDialog();

            if (result == DialogResult.OK)
            {
                SupprimerElement();
                MessageBox.Show("élément supprimer de la base de données ");
                this.Close();
            }
            else
            {
                MessageBox.Show("élément non-supprimer de la base de données");
                this.Close();
            }
        }
    }
}
