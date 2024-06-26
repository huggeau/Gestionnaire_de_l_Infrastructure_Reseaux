using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Collections;

namespace Gestionnaire_de_l_Infrastructure_Reseaux.métier
{
    internal class Communication
    {
        private Ping pingSender = new Ping();
        private PingReply pingReply;
        private PingOptions options = new PingOptions();

        //variable de classe nécessaire à la connexion pour la base de données 
        private MySqlConnector.MySqlConnection conn;
        private string host;
        private string database;
        private string username;
        private string password;
        private string connString;
        

        public Communication()
        {
        }

        public void connexionBDD()
        {
            //variable permettant la connexion à la base de données 
            
            host = "192.168.10.145";
            database = "db_Reseau_Mairie";
            username = "administrateur";
            password = "Admin07200&";
            connString = $"SERVER={host}; DATABASE={database}; UID={username}; PASSWORD={password}";

            using (conn = new MySqlConnector.MySqlConnection(connString))
            {
                try
                {
                    Console.WriteLine("Openning Connection ...");
                    conn.Open();

                    Console.WriteLine("Connection successful!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }

        //sert à envoyer les pings 
        public bool EnvoieEtReceptionPing(string requete)
        {
            connexionBDD();
            using (conn = new MySqlConnector.MySqlConnection(connString))
            {
                //booléen permettant de savoir si notre ping a répondu
                bool flag = true;
                try
                {
                    conn.Open();
                    MySqlConnector.MySqlCommand commande = conn.CreateCommand();
                    commande.CommandText = requete;
                    MySqlConnector.MySqlDataReader reader = commande.ExecuteReader();
                    ArrayList ip = new ArrayList();

                    // on dit de prendre toute les options à la disposition de la variable Ping options.
                    options.DontFragment = true;

                    // créer un buffer de 32 octets de données à transmettre.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;

                    //sert à prendre les ip qui sont dans la BDD afin de les placer dans une liste.
                    while (reader.Read())
                    {
                        ip.Add(reader["ip"]);
                    }

                    //sert à ping les @ip qui seront dans la liste des @ip
                    foreach (string add_ip in ip)
                    {
                        pingReply = pingSender.Send($"{add_ip}", timeout, buffer, options);
                        //sert à savoir si le ping a obtenu une réponse positive ou négative et modifie le flag en conséquence.
                        if (pingReply.Status == IPStatus.Success)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                            
                        }
                    }
                    

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return flag;
            }
            
            
        }
    }
}
