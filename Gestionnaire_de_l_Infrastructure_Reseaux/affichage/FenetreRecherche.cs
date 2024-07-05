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

            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.Cornsilk,
            };

            splitContainer1.Panel2.Controls.Add(tableLayoutPanel);

            LoadDataAndPopulateTable();
            RemplirComboBox();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DataTable results = Recherche();
            DisplayResults(results);
        }


        private void LoadDataAndPopulateTable()
        {
            using (MySqlConnector.MySqlConnection conn = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                try
                {
                    conn.Open();
                    string query = $"SELECT mr.id, mr.ip,  mr.nom, s.nom, e.nom AS etage,  cm.nom AS categorie_de_materiel, emplacement, commentaire FROM  Materiel_Reseau mr " +
                        $"INNER JOIN  etage e ON mr.id_etage = e.id " +
                        $"INNER JOIN   categorie_de_materiel cm ON mr.id_categorie_de_materiel = cm.id " +
                        $"INNER JOIN Site s ON mr.id_Site = s.id " +
                        $"ORDER BY e.nom DESC, cm.nom DESC";
                    MySqlConnector.MySqlCommand cmd = new MySqlConnector.MySqlCommand(query, conn);


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
            tableLayoutPanel.ColumnCount = dataTable.Columns.Count;
            tableLayoutPanel.RowCount = dataTable.Rows.Count + 1;

            // Add headers
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

            // Add data
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

        private DataTable Recherche()
        {
            using (var conn = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                conn.Open();

                var selectedSite = comboBox1.SelectedItem as ComboBoxItem;
                int idSite = selectedSite.Id;

                string sqlQuery = "SELECT mr.ip, mr.nom AS NomMateriel, s.nom AS NomSite, e.nom AS NomEtage, cm.nom AS NomCategorie, mr.commentaire " +
                                   "FROM Materiel_Reseau mr " +
                                   "INNER JOIN etage e ON mr.id_etage = e.id " +
                                   "INNER JOIN categorie_de_materiel cm ON mr.id_categorie_de_materiel = cm.id " +
                                   "INNER JOIN Site s ON mr.id_Site = s.id " +
                                   "WHERE s.id = @idSite AND " + // Utilisation correcte de l'alias et nom de colonne 
                                   "(mr.ip LIKE @searchTerm OR mr.nom LIKE @searchTerm)";

                // Utilisation d'une connexion et de paramètres SQL
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

        private void DisplayResults(DataTable results)
        {
            // Clear previous results
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowStyles.Clear();
            tableLayoutPanel.ColumnStyles.Clear();
            tableLayoutPanel.RowCount = 0;
            tableLayoutPanel.ColumnCount = results.Columns.Count;

            tableLayoutPanel.ColumnCount = results.Columns.Count;
            tableLayoutPanel.RowCount = results.Rows.Count + 1;

            // Add headers
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

            // Add data
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

        private void button2_Click(object sender, EventArgs e)
        {
            // Clear previous results
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowStyles.Clear();
            tableLayoutPanel.ColumnStyles.Clear();

            LoadDataAndPopulateTable();
        }
    }
}
