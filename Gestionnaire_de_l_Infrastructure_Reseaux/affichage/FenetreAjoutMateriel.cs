﻿using Gestionnaire_de_l_Infrastructure_Reseaux.affichage;
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

        private void BoutonSauvegarder_Click(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                var selectedEtage = comboBoxEtage.SelectedItem as ComboBoxItem;
                int idEtage = selectedEtage.Id;

                var selectedCategorie = comboBoxCategorie.SelectedItem as ComboBoxItem;
                int idCategorie = selectedCategorie.Id;
                connection.Open();
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
            }
            this.Close();
        }
    }
}