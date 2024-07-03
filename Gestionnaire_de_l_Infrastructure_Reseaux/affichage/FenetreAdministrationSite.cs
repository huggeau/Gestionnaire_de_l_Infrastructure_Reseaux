﻿using Gestionnaire_de_l_Infrastructure_Reseaux.métier;
using Mysqlx.Resultset;
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
    public partial class FenetreAdministrationSite : Form
    {
        private int idSite;
        private Communication comm = new Communication();
        private int taille = 230;
        private Panel[]? panels;
        private TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
        private List<Label> listLabel = new List<Label>();
        private List<string> listIps = new List<string>();
        public FenetreAdministrationSite(int id)
        {
            InitializeComponent();
            idSite = id;


            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            panel1.Controls.Add(tableLayoutPanel);

            LoadDataAndPopulateTable();
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


        

        //méthode provoquan un refresh des pings tout les 10 secondes
        private void timer1_Tick(object sender, EventArgs e)
        {
            using (MySqlConnector.MySqlConnection conn = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                try
                {
                    conn.Open();
                    string query = $"SELECT ip FROM Materiel_Reseau WHERE id_site = {idSite}";
                    MySqlConnector.MySqlCommand cmd = new MySqlConnector.MySqlCommand(query, conn);

                    MySqlConnector.MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read()) 
                    {
                        string ip = reader.GetString(0);

                        listIps.Add(ip);

                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            Ping();
        }

        //méthode qui sert a forcer le refresh des pings 
        private void forcerPingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (MySqlConnector.MySqlConnection conn = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                try
                {
                    conn.Open();
                    string query = $"SELECT ip FROM Materiel_Reseau WHERE id_site = {idSite}";
                    MySqlConnector.MySqlCommand cmd = new MySqlConnector.MySqlCommand(query, conn);

                    MySqlConnector.MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string ip = reader.GetString(0);

                        listIps.Add(ip);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            Ping();
        }

        private void LoadDataAndPopulateTable()
        {
            using (MySqlConnector.MySqlConnection conn = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                try
                {
                    conn.Open();
                    string query = $"SELECT mr.ip,  mr.nom, e.nom AS etage,  cm.nom AS categorie_de_materiel FROM  Materiel_Reseau mr " +
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
                    Label cellLabel = new Label
                    {
                        Text = dataTable.Rows[row][col].ToString(),
                        Dock = DockStyle.Fill,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        Size = new System.Drawing.Size(10,50),
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    tableLayoutPanel.Controls.Add(cellLabel, col, row + 1);

                    listLabel.Add(cellLabel);
                }
            }
        }

        private void Ping()
        {
            for (int i = 0; i < listLabel.Count; i += 4)
            {
                string ip = listIps[i-4]; // Assurez-vous que listIPs a la même longueur que listLabel

                if (comm.PingSpecifique(ip))
                {
                    listLabel[i].BackColor = Color.Green;
                }
                else
                {
                    listLabel[i].BackColor = Color.Red;
                }
            }
        }
    }
}
