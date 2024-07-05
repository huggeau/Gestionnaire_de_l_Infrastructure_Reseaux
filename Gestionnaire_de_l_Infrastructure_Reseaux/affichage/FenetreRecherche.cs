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
    public partial class FenetreRecherche : Form
    {
        private TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
        private Communication comm = new Communication();
        public FenetreRecherche()
        {
            InitializeComponent();

            // créer un tableau a colonne et le rajoute a la fenetre
            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.Cornsilk,
            };

            // j'ai prit un panneaux séparé a la verticale afin d'avoir en bas le résultat de la requete et en haut les éléments nécessaire a la recherche
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel);

            LoadDataAndPopulateTable();
            RemplirComboBox();
        }

        // sert a afficher le résultat de notre recherche
        private void button1_Click(object sender, EventArgs e)
        {
            // affiche le résultat de la requete de recherche
            DataTable results = Recherche();
            DisplayResults(results);
        }


        // sert a afficher tout les materiel de la bdd
        private void LoadDataAndPopulateTable()
        {
            using (MySqlConnector.MySqlConnection conn = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                try
                {
                    conn.Open();
                    //requete qui va permettre d'affichr tout les materiel de la table des materiels
                    string query = $"SELECT mr.id, mr.ip,  mr.nom, s.nom, e.nom AS etage,  cm.nom AS categorie_de_materiel, emplacement, commentaire FROM  Materiel_Reseau mr " +
                        $"INNER JOIN  etage e ON mr.id_etage = e.id " +
                        $"INNER JOIN   categorie_de_materiel cm ON mr.id_categorie_de_materiel = cm.id " +
                        $"INNER JOIN Site s ON mr.id_Site = s.id " +
                        $"ORDER BY e.nom DESC, cm.nom DESC";
                    MySqlConnector.MySqlCommand cmd = new MySqlConnector.MySqlCommand(query, conn);

                    // créer une table de donnée avec tout les valeurs récupérer de la requete
                    MySqlConnector.MySqlDataAdapter adapter = new MySqlConnector.MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    PopulateTableLayoutPanel(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void PopulateTableLayoutPanel(DataTable dataTable)
        {
            // créer un tableau a colonne 
            tableLayoutPanel.ColumnCount = dataTable.Columns.Count;
            tableLayoutPanel.RowCount = dataTable.Rows.Count + 1;

            // rajoute des titres aux colonnes
            for (int col = 0; col < dataTable.Columns.Count; col++)
            {
                Label headerLabel = new Label
                {
                    Text = dataTable.Columns[col].ColumnName,
                    Dock = DockStyle.Fill,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle
                };
                tableLayoutPanel.Controls.Add(headerLabel, col, 0);
            }

            // rajoute les données dans chauqe ligne pour chaque colonnes 
            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    TextBox cellTextBox = new TextBox
                    {
                        Text = dataTable.Rows[row][col].ToString(),
                        Dock = DockStyle.Fill,
                        TextAlign = HorizontalAlignment.Center,
                        Size = new System.Drawing.Size(10, 50),
                        BorderStyle = BorderStyle.FixedSingle,
                        Enabled = false,
                    };

                    tableLayoutPanel.Controls.Add(cellTextBox, col, row + 1);
                }
            }
        }

        //sert a remplir le combobox des sites pour la recherche
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

        //méthode qui va faire la recherche avec ce qu'on aura choisi dans le combobox et ce qu'on aura écrit dans le text box
        private DataTable Recherche()
        {
            using (var conn = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                conn.Open();

                var selectedSite = comboBox1.SelectedItem as ComboBoxItem;
                int idSite = selectedSite.Id;

                //requete sql qui permet de faire une recherche dans la table des Materiel_Reseau qui prend en compe l'id du site et qui va faire une recherche en 
                //sur les catégorie nom ou ip
                string sqlQuery = "SELECT mr.ip, mr.nom AS NomMateriel, s.nom AS NomSite, e.nom AS NomEtage, cm.nom AS NomCategorie, mr.commentaire " +
                                   "FROM Materiel_Reseau mr " +
                                   "INNER JOIN etage e ON mr.id_etage = e.id " +
                                   "INNER JOIN categorie_de_materiel cm ON mr.id_categorie_de_materiel = cm.id " +
                                   "INNER JOIN Site s ON mr.id_Site = s.id " +
                                   "WHERE s.id = @idSite AND " + 
                                   "(mr.ip LIKE @searchTerm OR mr.nom LIKE @searchTerm)";

                // rempli une table de donnée avec les résultat de la requête
                // et va ensuite recréer le tableau a colonne avec les données de la table de donnée 
                using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
                {
                    using (MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@idSite", idSite);
                        command.Parameters.AddWithValue("@searchTerm", "%" + textBox1.Text + "%");

                        MySqlConnector.MySqlDataAdapter adapter = new MySqlConnector.MySqlDataAdapter(command);
                        DataTable results = new DataTable();
                        adapter.Fill(results);

                        return results;
                    }
                }
            }
        }

        // sert a donner le résultat de notre recherche
        private void DisplayResults(DataTable results)
        {
            // supprime toute les données du tableau afin de pouvoir écrire les nouvelles
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowStyles.Clear();
            tableLayoutPanel.ColumnStyles.Clear();
            tableLayoutPanel.RowCount = 0;
            tableLayoutPanel.ColumnCount = results.Columns.Count;

            tableLayoutPanel.ColumnCount = results.Columns.Count;
            tableLayoutPanel.RowCount = results.Rows.Count + 1;

            // nom des colonnes
            for (int col = 0; col < results.Columns.Count; col++)
            {
                Label headerLabel = new Label
                {
                    Text = results.Columns[col].ColumnName,
                    Dock = DockStyle.Fill,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    BorderStyle = BorderStyle.FixedSingle
                };
                tableLayoutPanel.Controls.Add(headerLabel, col, 0);
            }

            //donnée remplie dans les colonnes
            for (int row = 0; row < results.Rows.Count; row++)
            {
                for (int col = 0; col < results.Columns.Count; col++)
                {
                    TextBox cellTextBox = new TextBox
                    {
                        Text = results.Rows[row][col].ToString(),
                        Dock = DockStyle.Fill,
                        TextAlign = HorizontalAlignment.Center,
                        Size = new System.Drawing.Size(10, 50),
                        BorderStyle = BorderStyle.FixedSingle,
                        Enabled = false,
                    };

                    tableLayoutPanel.Controls.Add(cellTextBox, col, row + 1);
                }
            }
        }


        // reload la page à la normale
        private void button2_Click(object sender, EventArgs e)
        {
            // supprime tout les données du tableau 
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowStyles.Clear();
            tableLayoutPanel.ColumnStyles.Clear();

            //reremplie la page avec la requête d'affichage de base sans modificateur
            LoadDataAndPopulateTable();
        }
    }
}
