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
    public partial class FenetreAjoutSite : Form
    {
        private Communication comm = new Communication();
        public FenetreAjoutSite()
        {
            InitializeComponent();
        }

        // sert a rajoyté un site dans la bdd
        private void button1_Click(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
            {
                connection.Open();
                string insertQuery = $"INSERT INTO Site (id, nom, XPosition, YPosition) VALUES (NUll, '{textBox1.Text}', '0','0');";
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
