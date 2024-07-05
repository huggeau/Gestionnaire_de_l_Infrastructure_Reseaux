﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Collections;
using System.Security.Policy;
using Microsoft.VisualBasic.Devices;
using System.Threading;
using Google.Protobuf.Collections;
using System.ComponentModel;

namespace Gestionnaire_de_l_Infrastructure_Reseaux.métier
{
    internal class Communication
    {
        private Ping pingSender = new Ping();
        private PingReply? pingReply;
        private PingOptions options = new PingOptions();

        //variable de classe nécessaire à la connexion pour la base de données 
        private MySqlConnector.MySqlConnection? conn;
        private string? host;
        private string? database;
        private string? username;
        private string? password;
        private string? connString;

        public Communication()
        {
        }

        public string connexionBDD()
        {
            //variable permettant la connexion à la base de données 

            host = "192.168.10.145";
            database = "db_Reseau_Mairie";
            username = "administrateur";
            password = "Admin07200&";
            connString = $"SERVER={host}; DATABASE={database}; UID={username}; PASSWORD={password}";

            return connString;
        }

        //sert à envoyer les pings au différents site du réseaux de la mairie
        public bool PingGeneral(int id)
        {
            connexionBDD();
            int compteur = 0;
            using (conn = new MySqlConnector.MySqlConnection(connString))
            {
                //booléen permettant de savoir si notre ping a répondu
                bool flagPing = false;
                try
                {
                        conn.Open();
                        MySqlConnector.MySqlCommand commandePing = conn.CreateCommand();
                        commandePing.CommandText = $"SELECT ip FROM Materiel_Reseau WHERE id_site={id};";

                        // ici on créer un reader qui va lire le résultat de la commande 
                        MySqlConnector.MySqlDataReader readerPing = commandePing.ExecuteReader();
                        ArrayList ip = new ArrayList();

                        // on dit de prendre toute les options à la disposition de la variable Ping options.
                        options.DontFragment = true;

                        // créer un buffer de 32 octets de données à transmettre.
                        string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                        byte[] buffer = Encoding.ASCII.GetBytes(data);
                        int timeout = 120;

                        //le reader va lire les résultat et les mettres dans un tableau
                        while (readerPing.Read())
                        {
                            ip.Add(readerPing["ip"]);
                        }

                        //sert à ping les @ip qui seront dans la liste des @ip
                        foreach (string add_ip in ip)
                        {
                            pingReply = pingSender.Send($"{add_ip}", timeout, buffer, options);
                            //sert à savoir si le ping a obtenu une réponse positive ou négative et modifie le flag en conséquence.
                            if (pingReply.Status == IPStatus.Success)
                            {
                                flagPing = true;
                            }
                            else
                            {
                                compteur++;
                            }
                        }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                // on regarde avec un compteur si au minima 1 éléments du site est deffectuex et si oui alors on passe le flag en faux
                if (compteur > 0)
                {
                    flagPing = false;
                }
                return flagPing;

            }
        }

        //sert à envoyer un  ping sur 1 ip bien précise
        public bool PingSpecifique(string ip)
        {
            bool flagPing = false;

            options.DontFragment = true;

            // créer un buffer de 32 octets de données à transmettre.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;

            pingReply = pingSender.Send($"{ip}", timeout, buffer, options);
            //sert à savoir si le ping a obtenu une réponse positive ou négative et modifie le flag en conséquence.
            if (pingReply.Status == IPStatus.Success)
            {
                flagPing = true;
            }
            else
            {
                flagPing = false;
            }

            return flagPing;
        }

        //sert à remplir la liste de tout les sites depuis la BDD
        public List<int> RemplirListSite()
        {
            List<int> site = new List<int>();
            connexionBDD();
            // on ouvre la BDD puis on lui demande une requête
            using (conn = new MySqlConnector.MySqlConnection(connString))
            {
                conn.Open();
                MySqlConnector.MySqlCommand commandSite = conn.CreateCommand();
                commandSite.CommandText = "SELECT id FROM Site ";

                MySqlConnector.MySqlDataReader readerSite = commandSite.ExecuteReader();
                while (readerSite.Read())
                {
                    int id = readerSite.GetInt32(0);

                    site.Add(id);
                }
            }
            return site;
        }

        //sert à remplir la liste des ip depuis la bdd
        public List<string> RemplirListIps(int idSite)
        {
            List<string> listIps = new List<string>();
            using (MySqlConnector.MySqlConnection conn = new MySqlConnector.MySqlConnection(connexionBDD()))
            {
                try
                {
                    conn.Open();
                    string query = $"SELECT ip FROM Materiel_Reseau mr " +
                        $"INNER JOIN categorie_de_materiel cm ON mr.id_categorie_de_materiel = cm.id " +
                        $"INNER JOIN etage e ON mr.id_etage = e.id " +
                        $"WHERE id_site = {idSite} " +
                        $"ORDER BY id_etage, id_categorie_de_materiel ";
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
            return listIps;
        }
    }
}