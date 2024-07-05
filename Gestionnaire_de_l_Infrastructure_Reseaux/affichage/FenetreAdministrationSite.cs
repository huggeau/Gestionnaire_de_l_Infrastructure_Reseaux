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

            //créer un tableaua evc des colonnes et des lignes afin de le remplir avec les données de la bdd
            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.Cornsilk,
            };

            panel1.Controls.Add(tableLayoutPanel);

            LoadDataAndPopulateTable();

            //enlève la modification de l'id de chaque élément afin d'empêcher de modifier un élément non-modifiable de la bdd
            for (int i = 0; i < listTextBox.Count; i+=5) { 
                listTextBox[i].Enabled = false;
            }
        }

        // ouvre les fentres d'ajout et pour supprimer un matériel d'un site 
        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FenetreAjoutMateriel fenetreAjout = new FenetreAjoutMateriel(idSite);
            fenetreAjout.ShowDialog();
        }
        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FenetreSupprimerMateriel fenetreSupprimer = new FenetreSupprimerMateriel(idSite);
            fenetreSupprimer.ShowDialog();
        }

        // force le pings des éléments du site
        private void forcerPingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ping();
        }

        //méthode provoquan un refresh des pings tout les 10 secondes
        private void timer1_Tick(object sender, EventArgs e)
        {
            Ping();
        }

        //méthode permettant de sauvegarder les  donnés modifier dans la base de données
        private void FenetreAdministrationSite_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateInfoBDD();
        }





        // charge les donnée de la BDD et les transforms un un tableau 
        private void LoadDataAndPopulateTable()
        {
            using (MySqlConnector.MySqlConnection conn = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                try
                {
                    conn.Open();

                    //requete récupérant les infos nécessaire a l'affichage du tableau avec les infos de la bdd récupérer
                    string query = $"SELECT mr.id, mr.ip,  mr.nom, e.nom AS etage,  cm.nom AS categorie_de_materiel, emplacement, commentaire FROM  Materiel_Reseau mr " +
                        $"INNER JOIN  etage e ON mr.id_etage = e.id " +
                        $"INNER JOIN   categorie_de_materiel cm ON mr.id_categorie_de_materiel = cm.id" +
                        $" WHERE mr.id_site = {idSite} " +
                        $"ORDER BY e.nom DESC, cm.nom DESC";
                    MySqlConnector.MySqlCommand cmd = new MySqlConnector.MySqlCommand(query, conn);

                    //viens mettre les valeurs récupérer pour chaque colonne et chaque ligne dans une table de donnée que je donne a ma méthode afin de créer un
                    //tableLayoutPnale, donc un tableau avec des lignes et des colonnes.
                    MySqlConnector.MySqlDataAdapter adapter = new MySqlConnector.MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    //appelle la méthode de création du tableau a colonne
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
            // prend les valeurs de taille du tableau afin de savoir combien de colonne il lui faudra créer
            tableLayoutPanel.ColumnCount = dataTable.Columns.Count;
            tableLayoutPanel.RowCount = dataTable.Rows.Count + 1;


            // rajoute les nom des colonnes 
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

            // rajoute les données dans chanque colonnes et pour chaque ligne si besoins
            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    //dans les colonnes 3 et 4 je mets des combobox car ce sont les id des etages et des categorie donc pas un choix ou l'on peut écrire
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
                    // le reste des colonnes je créer des textbox afin de pouvoir modifier leur données
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

        // sert a ping les différents éléments
        private void Ping()
        {
            //teste pour chaque colonne ou les ip se trouve si leur ping répond et si oui alorsles affiches en vert sinon en rouge
            int IndexLabel = 1;
            // boucle qui va regarder pour chaque ligne 
            for (int i = 0; i < listIps.Count; i++)
            {

                if (comm.PingSpecifique(listIps[i]))
                {
                    listTextBox[IndexLabel].BackColor = Color.Green;
                    listTextBox[IndexLabel].ForeColor = Color.White;
                }
                else
                {
                    listTextBox[IndexLabel].BackColor = Color.Red;
                    listTextBox[IndexLabel].ForeColor = Color.White;

                }
                // je rajoute toute les 5 colonnes car ce sont les nombres exacte de colonne qui se trouve entre chaque ip
                IndexLabel += 5;
            }
        }

        // sert a mettre a jour la BDD
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
                    //requête sql qui me permet de mettre a jour tout les données de la table Materiel_reseau sauf l'id qui lui ne dois jamais changer
                    string updateQuery = "UPDATE Materiel_Reseau mr " +
                                         "INNER JOIN etage e ON mr.id_etage = e.id " +
                                         "INNER JOIN categorie_de_materiel cm ON mr.id_categorie_de_materiel = cm.id " +
                                         "SET mr.ip = @ip, " +
                                         "mr.nom = @nom, " +
                                         "mr.emplacement = @emplacement, " +
                                         "mr.commentaire = @commentaire, " +
                                         "mr.id_etage = @id_etage, " +
                                         "mr.id_categorie_de_materiel = @id_categorie " +
                                         "WHERE mr.id = @id";

                    using (var command = new MySqlConnector.MySqlCommand(updateQuery, connection))
                    {
                        try
                        {
                            //prend les paramètres des textbox et les incrémente a la requete
                            int id = Convert.ToInt32(listTextBox[indexTextBox].Text);
                            command.Parameters.AddWithValue("@ip", listTextBox[indexTextBox + 1].Text);
                            command.Parameters.AddWithValue("@nom", listTextBox[indexTextBox + 2].Text);
                            command.Parameters.AddWithValue("@emplacement", listTextBox[indexTextBox + 3].Text);
                            command.Parameters.AddWithValue("@commentaire", listTextBox[indexTextBox + 4].Text);

                            try
                            {
                                //pour tout les conditions suivante, le code viens regarder si quelque chose a étaiot choisi dans les combobox, si oui alors il prend la 
                                //valeur choisi et les mets dans les parametres de la requete, si non alors il prend ce qui est écrit de base dedans quand on ne fais pas de chois
                                //et les mets en parametre de la requete
                                int idEtage;
                                if (listComboBox[indexComboBox].SelectedItem != null)
                                {
                                    var selectedEtage = listComboBox[indexComboBox].SelectedItem as ComboBoxItem;
                                    idEtage = selectedEtage.Id;
                                }
                                else
                                {
                                    // Rechercher l'ID correspondant au texte actuel dans le ComboBox
                                    idEtage = GetEtageIdByName(listComboBox[indexComboBox].Text);
                                }

                                int idCategorie;
                                if (listComboBox[indexComboBox + 1].SelectedItem != null)
                                {
                                    var selectedCategorie = listComboBox[indexComboBox + 1].SelectedItem as ComboBoxItem;
                                    idCategorie = selectedCategorie.Id;
                                }
                                else
                                {
                                    // Rechercher l'ID correspondant au texte actuel dans le ComboBox
                                    idCategorie = GetCategorieIdByName(listComboBox[indexComboBox + 1].Text);
                                }

                                command.Parameters.AddWithValue("@id_etage", idEtage);
                                command.Parameters.AddWithValue("@id_categorie", idCategorie);
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

        //sert a a chercher les ids du text qui est dans la combobox de base si on ne choisi aucune option qui est dedans
        private int GetEtageIdByName(string name)
        {
            // viens chercher l'id qui a été donné dans la combobox
            using (var connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                connection.Open();
                string query = "SELECT id FROM etage WHERE nom = @name";
                using (var command = new MySqlConnector.MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        throw new Exception("Etage not found.");
                    }
                }
            }
        }
        private int GetCategorieIdByName(string name)
        {
            //viens chercher l'id de la combobox
            using (var connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                connection.Open();
                string query = "SELECT id FROM categorie_de_materiel WHERE nom = @name";
                using (var command = new MySqlConnector.MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        throw new Exception("Categorie de materiel not found.");
                    }
                }
            }
        }

        // sert a remplir des combobox et mettre leur valeur dans une classe d'objet afin d'avoir et leur nom et leur ip
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
