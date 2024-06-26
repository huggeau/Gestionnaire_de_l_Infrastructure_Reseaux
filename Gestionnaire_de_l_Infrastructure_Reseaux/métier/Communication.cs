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

        //sert à envoyer les pings au différents site du réseaux de la mairie
        public bool PingMairiePrincipale()
        {
            connexionBDD();
            using (conn = new MySqlConnector.MySqlConnection(connString))
            {
                //booléen permettant de savoir si notre ping a répondu
                bool flagMairiePrincipale = false;
                try
                {
                    conn.Open();
                    MySqlConnector.MySqlCommand commandeMairiePrincipale = conn.CreateCommand();
                    commandeMairiePrincipale.CommandText = "SELECT id, ip FROM Materiel_Reseau WHERE id_site = 1;";
                    MySqlConnector.MySqlDataReader readerMairiePrincipale = commandeMairiePrincipale.ExecuteReader();
                    ArrayList ip = new ArrayList();

                    // on dit de prendre toute les options à la disposition de la variable Ping options.
                    options.DontFragment = true;

                    // créer un buffer de 32 octets de données à transmettre.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;

                    //sert à prendre les ip qui sont dans la BDD afin de les placer dans une liste.
                    while (readerMairiePrincipale.Read())
                    {
                        ip.Add(readerMairiePrincipale["ip"]);
                    }

                    //sert à ping les @ip qui seront dans la liste des @ip
                    foreach (string add_ip in ip)
                    {
                        pingReply = pingSender.Send($"{add_ip}", timeout, buffer, options);
                        //sert à savoir si le ping a obtenu une réponse positive ou négative et modifie le flag en conséquence.
                        if (pingReply.Status == IPStatus.Success)
                        {
                            flagMairiePrincipale = true;
                        }
                        else
                        {
                            flagMairiePrincipale = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return flagMairiePrincipale;
               
            } 
        }
        public bool PingMairieAnnexe()
        {
            connexionBDD();
            using (conn = new MySqlConnector.MySqlConnection(connString))
            {
                //booléen permettant de savoir si notre ping a répondu
                bool flagMairieAnnexe = false;
                try
                {
                    conn.Open();
                    MySqlConnector.MySqlCommand commandeMairieAnnexe = conn.CreateCommand();
                    commandeMairieAnnexe.CommandText = "SELECT id, ip FROM Materiel_Reseau WHERE id_site = 3;";
                    MySqlConnector.MySqlDataReader readerMairieAnnexe = commandeMairieAnnexe.ExecuteReader();
                    ArrayList ip = new ArrayList();

                    // on dit de prendre toute les options à la disposition de la variable Ping options.
                    options.DontFragment = true;

                    // créer un buffer de 32 octets de données à transmettre.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;

                    //sert à prendre les ip qui sont dans la BDD afin de les placer dans une liste.
                    while (readerMairieAnnexe.Read())
                    {
                        ip.Add(readerMairieAnnexe["ip"]);
                    }

                    //sert à ping les @ip qui seront dans la liste des @ip
                    foreach (string add_ip in ip)
                    {
                        pingReply = pingSender.Send($"{add_ip}", timeout, buffer, options);
                        //sert à savoir si le ping a obtenu une réponse positive ou négative et modifie le flag en conséquence.
                        if (pingReply.Status == IPStatus.Success)
                        {
                            flagMairieAnnexe = true;
                        }
                        else
                        {
                            flagMairieAnnexe = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return flagMairieAnnexe;

            }
        }
        public bool PingAgora()
        {
            connexionBDD();
            using (conn = new MySqlConnector.MySqlConnection(connString))
            {
                //booléen permettant de savoir si notre ping a répondu
                bool flagAgora = false;
                try
                {
                    conn.Open();
                    MySqlConnector.MySqlCommand commandeAgora = conn.CreateCommand();
                    commandeAgora.CommandText = "SELECT id, ip FROM Materiel_Reseau WHERE id_site = 5;";
                    MySqlConnector.MySqlDataReader readerAgora = commandeAgora.ExecuteReader();
                    ArrayList ip = new ArrayList();

                    // on dit de prendre toute les options à la disposition de la variable Ping options.
                    options.DontFragment = true;

                    // créer un buffer de 32 octets de données à transmettre.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;

                    //sert à prendre les ip qui sont dans la BDD afin de les placer dans une liste.
                    while (readerAgora.Read())
                    {
                        ip.Add(readerAgora["ip"]);
                    }

                    //sert à ping les @ip qui seront dans la liste des @ip
                    foreach (string add_ip in ip)
                    {
                        pingReply = pingSender.Send($"{add_ip}", timeout, buffer, options);
                        //sert à savoir si le ping a obtenu une réponse positive ou négative et modifie le flag en conséquence.
                        if (pingReply.Status == IPStatus.Success)
                        {
                            flagAgora = true;
                        }
                        else
                        {
                            flagAgora = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return flagAgora;

            }
        }
        public bool PingCentreLeBournot()
        {
            connexionBDD();
            using (conn = new MySqlConnector.MySqlConnection(connString))
            {
                //booléen permettant de savoir si notre ping a répondu
                bool flagCentreLeBournot = false;
                try
                {
                    conn.Open();
                    MySqlConnector.MySqlCommand commandeCentreLeBournot = conn.CreateCommand();
                    commandeCentreLeBournot.CommandText = "SELECT id, ip FROM Materiel_Reseau WHERE id_site = 6;";
                    MySqlConnector.MySqlDataReader readerCentreLeBournot = commandeCentreLeBournot.ExecuteReader();
                    ArrayList ip = new ArrayList();

                    // on dit de prendre toute les options à la disposition de la variable Ping options.
                    options.DontFragment = true;

                    // créer un buffer de 32 octets de données à transmettre.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;

                    //sert à prendre les ip qui sont dans la BDD afin de les placer dans une liste.
                    while (readerCentreLeBournot.Read())
                    {
                        ip.Add(readerCentreLeBournot["ip"]);
                    }

                    //sert à ping les @ip qui seront dans la liste des @ip
                    foreach (string add_ip in ip)
                    {
                        pingReply = pingSender.Send($"{add_ip}", timeout, buffer, options);
                        //sert à savoir si le ping a obtenu une réponse positive ou négative et modifie le flag en conséquence.
                        if (pingReply.Status == IPStatus.Success)
                        {
                            flagCentreLeBournot = true;
                        }
                        else
                        {
                            flagCentreLeBournot = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return flagCentreLeBournot;

            }
        }
        public bool PingPoliceMunicipale()
        {
            connexionBDD();
            using (conn = new MySqlConnector.MySqlConnection(connString))
            {
                //booléen permettant de savoir si notre ping a répondu
                bool flagPoliceMunicipale = false;
                try
                {
                    conn.Open();
                    MySqlConnector.MySqlCommand commandePoliceMunicipale = conn.CreateCommand();
                    commandePoliceMunicipale.CommandText = "SELECT id, ip FROM Materiel_Reseau WHERE id_site = 7;";
                    MySqlConnector.MySqlDataReader readerPoliceMunicipale = commandePoliceMunicipale.ExecuteReader();
                    ArrayList ip = new ArrayList();

                    // on dit de prendre toute les options à la disposition de la variable Ping options.
                    options.DontFragment = true;

                    // créer un buffer de 32 octets de données à transmettre.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;

                    //sert à prendre les ip qui sont dans la BDD afin de les placer dans une liste.
                    while (readerPoliceMunicipale.Read())
                    {
                        ip.Add(readerPoliceMunicipale["ip"]);
                    }

                    //sert à ping les @ip qui seront dans la liste des @ip
                    foreach (string add_ip in ip)
                    {
                        pingReply = pingSender.Send($"{add_ip}", timeout, buffer, options);
                        //sert à savoir si le ping a obtenu une réponse positive ou négative et modifie le flag en conséquence.
                        if (pingReply.Status == IPStatus.Success)
                        {
                            flagPoliceMunicipale = true;
                        }
                        else
                        {
                            flagPoliceMunicipale = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return flagPoliceMunicipale;

            }
        }
        public bool Ping18A()
        {
            connexionBDD();
            using (conn = new MySqlConnector.MySqlConnection(connString))
            {
                //booléen permettant de savoir si notre ping a répondu
                bool flag18A = false;
                try
                {
                    conn.Open();
                    MySqlConnector.MySqlCommand commande18A = conn.CreateCommand();
                    commande18A.CommandText = "SELECT id, ip FROM Materiel_Reseau WHERE id_site = 8;";
                    MySqlConnector.MySqlDataReader reader18A = commande18A.ExecuteReader();
                    ArrayList ip = new ArrayList();

                    // on dit de prendre toute les options à la disposition de la variable Ping options.
                    options.DontFragment = true;

                    // créer un buffer de 32 octets de données à transmettre.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;

                    //sert à prendre les ip qui sont dans la BDD afin de les placer dans une liste.
                    while (reader18A.Read())
                    {
                        ip.Add(reader18A["ip"]);
                    }

                    //sert à ping les @ip qui seront dans la liste des @ip
                    foreach (string add_ip in ip)
                    {
                        pingReply = pingSender.Send($"{add_ip}", timeout, buffer, options);
                        //sert à savoir si le ping a obtenu une réponse positive ou négative et modifie le flag en conséquence.
                        if (pingReply.Status == IPStatus.Success)
                        {
                            flag18A = true;
                        }
                        else
                        {
                            flag18A = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return flag18A;

            }
        }
        public bool PingCTM()
        {
            connexionBDD();
            using (conn = new MySqlConnector.MySqlConnection(connString))
            {
                //booléen permettant de savoir si notre ping a répondu
                bool flagCTM = false;
                try
                {
                    conn.Open();
                    MySqlConnector.MySqlCommand commandeCTM = conn.CreateCommand();
                    commandeCTM.CommandText = "SELECT id, ip FROM Materiel_Reseau WHERE id_site = 10;";
                    MySqlConnector.MySqlDataReader readerCTM = commandeCTM.ExecuteReader();
                    ArrayList ip = new ArrayList();

                    // on dit de prendre toute les options à la disposition de la variable Ping options.
                    options.DontFragment = true;

                    // créer un buffer de 32 octets de données à transmettre.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;

                    //sert à prendre les ip qui sont dans la BDD afin de les placer dans une liste.
                    while (readerCTM.Read())
                    {
                        ip.Add(readerCTM["ip"]);
                    }

                    //sert à ping les @ip qui seront dans la liste des @ip
                    foreach (string add_ip in ip)
                    {
                        pingReply = pingSender.Send($"{add_ip}", timeout, buffer, options);
                        //sert à savoir si le ping a obtenu une réponse positive ou négative et modifie le flag en conséquence.
                        if (pingReply.Status == IPStatus.Success)
                        {
                            flagCTM = true;
                        }
                        else
                        {
                            flagCTM = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return flagCTM;

            }
        }
        public bool PingLienhart()
        {
            connexionBDD();
            using (conn = new MySqlConnector.MySqlConnection(connString))
            {
                //booléen permettant de savoir si notre ping a répondu
                bool flagLienhart = false;
                try
                {
                    conn.Open();
                    MySqlConnector.MySqlCommand commandeLienhart = conn.CreateCommand();
                    commandeLienhart.CommandText = "SELECT id, ip FROM Materiel_Reseau WHERE id_site = 11;";
                    MySqlConnector.MySqlDataReader readerLienhart = commandeLienhart.ExecuteReader();
                    ArrayList ip = new ArrayList();

                    // on dit de prendre toute les options à la disposition de la variable Ping options.
                    options.DontFragment = true;

                    // créer un buffer de 32 octets de données à transmettre.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;

                    //sert à prendre les ip qui sont dans la BDD afin de les placer dans une liste.
                    while (readerLienhart.Read())
                    {
                        ip.Add(readerLienhart["ip"]);
                    }

                    //sert à ping les @ip qui seront dans la liste des @ip
                    foreach (string add_ip in ip)
                    {
                        pingReply = pingSender.Send($"{add_ip}", timeout, buffer, options);
                        //sert à savoir si le ping a obtenu une réponse positive ou négative et modifie le flag en conséquence.
                        if (pingReply.Status == IPStatus.Success)
                        {
                            flagLienhart = true;
                        }
                        else
                        {
                            flagLienhart = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return flagLienhart;

            }
        }
        public bool PingEauxETAssainissement()
        {
            connexionBDD();
            using (conn = new MySqlConnector.MySqlConnection(connString))
            {
                //booléen permettant de savoir si notre ping a répondu
                bool flagEaux = false;
                try
                {
                    conn.Open();
                    MySqlConnector.MySqlCommand commandeEaux = conn.CreateCommand();
                    commandeEaux.CommandText = "SELECT id, ip FROM Materiel_Reseau WHERE id_site = 12;";
                    MySqlConnector.MySqlDataReader readerEaux = commandeEaux.ExecuteReader();
                    ArrayList ip = new ArrayList();

                    // on dit de prendre toute les options à la disposition de la variable Ping options.
                    options.DontFragment = true;

                    // créer un buffer de 32 octets de données à transmettre.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;

                    //sert à prendre les ip qui sont dans la BDD afin de les placer dans une liste.
                    while (readerEaux.Read())
                    {
                        ip.Add(readerEaux["ip"]);
                    }

                    //sert à ping les @ip qui seront dans la liste des @ip
                    foreach (string add_ip in ip)
                    {
                        pingReply = pingSender.Send($"{add_ip}", timeout, buffer, options);
                        //sert à savoir si le ping a obtenu une réponse positive ou négative et modifie le flag en conséquence.
                        if (pingReply.Status == IPStatus.Success)
                        {
                            flagEaux = true;
                        }
                        else
                        {
                            flagEaux = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return flagEaux;

            }
        }
        public bool PingAbattoirs()
        {
            connexionBDD();
            using (conn = new MySqlConnector.MySqlConnection(connString))
            {
                //booléen permettant de savoir si notre ping a répondu
                bool flagAbttoirs = false;
                try
                {
                    conn.Open();
                    MySqlConnector.MySqlCommand commandeAbattoirs = conn.CreateCommand();
                    commandeAbattoirs.CommandText = "SELECT id, ip FROM Materiel_Reseau WHERE id_site = 13;";
                    MySqlConnector.MySqlDataReader readerAbattoirs = commandeAbattoirs.ExecuteReader();
                    ArrayList ip = new ArrayList();

                    // on dit de prendre toute les options à la disposition de la variable Ping options.
                    options.DontFragment = true;

                    // créer un buffer de 32 octets de données à transmettre.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;

                    //sert à prendre les ip qui sont dans la BDD afin de les placer dans une liste.
                    while (readerAbattoirs.Read())
                    {
                        ip.Add(readerAbattoirs["ip"]);
                    }

                    //sert à ping les @ip qui seront dans la liste des @ip
                    foreach (string add_ip in ip)
                    {
                        pingReply = pingSender.Send($"{add_ip}", timeout, buffer, options);
                        //sert à savoir si le ping a obtenu une réponse positive ou négative et modifie le flag en conséquence.
                        if (pingReply.Status == IPStatus.Success)
                        {
                            flagAbttoirs = true;
                        }
                        else
                        {
                            flagAbttoirs = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return flagAbttoirs;

            }
        }
        public bool PingSTEP()
        {
            connexionBDD();
            using (conn = new MySqlConnector.MySqlConnection(connString))
            {
                //booléen permettant de savoir si notre ping a répondu
                bool flagSTEP = false;
                try
                {
                    conn.Open();
                    MySqlConnector.MySqlCommand commandeSTEP = conn.CreateCommand();
                    commandeSTEP.CommandText = "SELECT id, ip FROM Materiel_Reseau WHERE id_site = 14;";
                    MySqlConnector.MySqlDataReader readerSTEP = commandeSTEP.ExecuteReader();
                    ArrayList ip = new ArrayList();

                    // on dit de prendre toute les options à la disposition de la variable Ping options.
                    options.DontFragment = true;

                    // créer un buffer de 32 octets de données à transmettre.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;

                    //sert à prendre les ip qui sont dans la BDD afin de les placer dans une liste.
                    while (readerSTEP.Read())
                    {
                        ip.Add(readerSTEP["ip"]);
                    }

                    //sert à ping les @ip qui seront dans la liste des @ip
                    foreach (string add_ip in ip)
                    {
                        pingReply = pingSender.Send($"{add_ip}", timeout, buffer, options);
                        //sert à savoir si le ping a obtenu une réponse positive ou négative et modifie le flag en conséquence.
                        if (pingReply.Status == IPStatus.Success)
                        {
                            flagSTEP = true;
                        }
                        else
                        {
                            flagSTEP = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return flagSTEP;

            }
        }
        public bool PingChateau()
        {
            connexionBDD();
            using (conn = new MySqlConnector.MySqlConnection(connString))
            {
                //booléen permettant de savoir si notre ping a répondu
                bool flagChateau = false;
                try
                {
                    conn.Open();
                    MySqlConnector.MySqlCommand commandeChateau = conn.CreateCommand();
                    commandeChateau.CommandText = "SELECT id, ip FROM Materiel_Reseau WHERE id_site = 25;";
                    MySqlConnector.MySqlDataReader readerChateau = commandeChateau.ExecuteReader();
                    ArrayList ip = new ArrayList();

                    // on dit de prendre toute les options à la disposition de la variable Ping options.
                    options.DontFragment = true;

                    // créer un buffer de 32 octets de données à transmettre.
                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;

                    //sert à prendre les ip qui sont dans la BDD afin de les placer dans une liste.
                    while (readerChateau.Read())
                    {
                        ip.Add(readerChateau["ip"]);
                    }

                    //sert à ping les @ip qui seront dans la liste des @ip
                    foreach (string add_ip in ip)
                    {
                        pingReply = pingSender.Send($"{add_ip}", timeout, buffer, options);
                        //sert à savoir si le ping a obtenu une réponse positive ou négative et modifie le flag en conséquence.
                        if (pingReply.Status == IPStatus.Success)
                        {
                            flagChateau = true;
                        }
                        else
                        {
                            flagChateau = false;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return flagChateau;

            }
        }


    }
}
