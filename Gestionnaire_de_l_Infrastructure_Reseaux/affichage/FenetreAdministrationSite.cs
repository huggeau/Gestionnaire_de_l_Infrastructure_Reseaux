using Gestionnaire_de_l_Infrastructure_Reseaux.métier;
using Mysqlx.Crud;
using Mysqlx.Resultset;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Gestionnaire_de_l_Infrastructure_Reseaux
{
    public partial class FenetreAdministrationSite : Form
    {
        private int idSite;
        private Communication comm = new Communication();
        private int taille = 230;
        private Panel[]? panels;
        private TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
        private List<TextBox> listTextBox = new List<TextBox>();
        private List<string> listIps = new List<string>();
        private List<ComboBox> listComboBox = new List<ComboBox>();


        public FenetreAdministrationSite(int id)
        {
            InitializeComponent();
            idSite = id;
            listIps = comm.RemplirListIps(id);


            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.Cornsilk,
            };

            panel1.Controls.Add(tableLayoutPanel);

            LoadDataAndPopulateTable();

            for (int i = 0; i < listTextBox.Count; i+=5) { 
                listTextBox[i].Enabled = false;
            }
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FenetreAjoutMateriel fenetreAjout = new FenetreAjoutMateriel();
            fenetreAjout.ShowDialog();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FenetreSupprimerMateriel fenetreSupprimer = new FenetreSupprimerMateriel();
            fenetreSupprimer.ShowDialog();
        }
        private void forcerPingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ping();
        }

        //méthode provoquan un refresh des pings tout les 10 secondes
        private void timer1_Tick(object sender, EventArgs e)
        {
            Ping();
        }
        private void FenetreAdministrationSite_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateInfoBDD();
        }





        private void LoadDataAndPopulateTable()
        {
            using (MySqlConnector.MySqlConnection conn = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                try
                {
                    conn.Open();
                    string query = $"SELECT mr.id, mr.ip,  mr.nom, e.nom AS etage,  cm.nom AS categorie_de_materiel, commentaire, emplacement FROM  Materiel_Reseau mr " +
                        $"INNER JOIN  etage e ON mr.id_etage = e.id " +
                        $"INNER JOIN   categorie_de_materiel cm ON mr.id_categorie_de_materiel = cm.id" +
                        $" WHERE mr.id_site = {idSite};";
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
                    if (col == 3) 
                    {
                        ComboBox comboBox = new ComboBox
                        {
                            Text = dataTable.Rows[row][col].ToString(),
                            Dock = DockStyle.Fill,
                        };
                        RemplirComboBoxEtage(comboBox);

                        listComboBox.Add(comboBox);

                        tableLayoutPanel.Controls.Add(comboBox);
                        
                    }
                    else if (col == 4)
                    {
                        ComboBox comboBox = new ComboBox
                        {
                            Text = dataTable.Rows[row][col].ToString(),
                            Dock = DockStyle.Fill,
                        };
                        RemplirComboBoxCategorie(comboBox);

                        listComboBox.Add(comboBox);

                        tableLayoutPanel.Controls.Add(comboBox);
                    }
                    else 
                    { 
                        TextBox cellTextBox = new TextBox
                        {
                            Text = dataTable.Rows[row][col].ToString(),
                            Dock = DockStyle.Fill,
                            TextAlign = HorizontalAlignment.Center,
                            Size = new System.Drawing.Size(10, 50),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                    tableLayoutPanel.Controls.Add(cellTextBox, col, row + 1);

                    listTextBox.Add(cellTextBox);
                    }
                }
            }
        }

        private void Ping()
        {
            int IndexLabel = 1;
            for (int i = 0; i < listIps.Count; i++)
            {

                if (comm.PingSpecifique(listIps[i]))
                {
                    listTextBox[IndexLabel].BackColor = Color.Green;
                }
                else
                {
                    listTextBox[IndexLabel].BackColor = Color.Red;
                }

                IndexLabel += 5;
            }
        }

        private void UpdateInfoBDD()
        {
            using (var connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                connection.Open();
                int indexTextBox = 0;
                int indexComboBox = 0;
                // Insert new position
                for (int i = 0; i < tableLayoutPanel.RowCount; i++)
                {
                    string updateQuery = "UPDATE Materiel_Reseau mr " +
                                         "INNER JOIN etage e ON mr.id_etage = e.id " +
                                         "INNER JOIN categorie_de_materiel cm ON mr.id_categorie_de_materiel = cm.id " +
                                         "SET mr.ip = @ip, " +
                                         "mr.nom = @nom, " +
                                         "mr.commentaire = @commentaire, " +
                                         "mr.emplacement = @emplacement, " +
                                         "mr.id_etage = @id_etage, " +
                                         "mr.id_categorie_de_materiel = @id_categorie " +
                                         "WHERE mr.id = @id";

                    using (var command = new MySqlConnector.MySqlCommand(updateQuery, connection))
                    {
                        try
                        {
                            int id = Convert.ToInt32(listTextBox[indexTextBox].Text);
                            command.Parameters.AddWithValue("@ip", listTextBox[indexTextBox + 1].Text);
                            command.Parameters.AddWithValue("@nom", listTextBox[indexTextBox + 2].Text);
                            command.Parameters.AddWithValue("@commentaire", listTextBox[indexTextBox + 3].Text);
                            command.Parameters.AddWithValue("@emplacement", listTextBox[indexTextBox + 4].Text);
                            try
                            {
                                var selectedEtage = listComboBox[indexComboBox].SelectedItem as ComboBoxItem;
                                var selectedCategorie = listComboBox[indexComboBox + 1].SelectedItem as ComboBoxItem;
                                if (selectedEtage != null && selectedCategorie != null)
                                {
                                    command.Parameters.AddWithValue("@id_etage", selectedEtage.Id);
                                    command.Parameters.AddWithValue("@id_categorie", selectedCategorie.Id);
                                }
                                else
                                {
                                    throw new Exception("Sélection invalide dans les ComboBox.");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
                            }
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();

                            indexTextBox += 5;
                            indexComboBox += 2;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }
            }
        }
        public void RemplirComboBoxEtage(ComboBox comboBox)
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

                    comboBox.Items.Add(new ComboBoxItem(id, name));
                }
                reader.Close();
            }
            comboBox.DisplayMember = "Name"; // Propriété à afficher
            comboBox.ValueMember = "Id"; // Valeur utilisée en interne
        }

        public void RemplirComboBoxCategorie(ComboBox comboBox)
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

                    comboBox.Items.Add(new ComboBoxItem(id, name));
                }
                reader.Close();
            }
            comboBox.DisplayMember = "Name"; // Propriété à afficher
            comboBox.ValueMember = "Id"; // Valeur utilisée en interne
        }
    }
}
