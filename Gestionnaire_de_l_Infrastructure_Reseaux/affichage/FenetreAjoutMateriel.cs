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

namespace Gestionnaire_de_l_Infrastructure_Reseaux
{
    public partial class FenetreAjoutMateriel : Form
    {
        private Communication comm = new Communication();
        public FenetreAjoutMateriel()
        {
            InitializeComponent();
            RemplirComboBoxSite();
            RemplirComboBoxEtage();
            RemplirComboBoxCategorie();
        }
        public void RemplirComboBoxSite()
        {
            string query = "SELECT id, nom FROM Site ";

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(query, connection);
                connection.Open();
                MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);

                    comboBoxSite.Items.Add(id + " - "+name);
                }
                reader.Close();
            }
        }
        public void RemplirComboBoxEtage()
        {
            string query = "SELECT id, nom FROM etage ";

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(query, connection);
                connection.Open();
                MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);

                    comboBoxEtage.Items.Add(id + " - " + name);
                }
                reader.Close();
            }
        }
        public void RemplirComboBoxCategorie()
        {
            string query = "SELECT id, nom FROM categorie_de_materiel ";

            using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(query, connection);
                connection.Open();
                MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);

                    comboBoxCategorie.Items.Add(id + " - " + name);
                }
                reader.Close();
            }
        }
    } 
}
