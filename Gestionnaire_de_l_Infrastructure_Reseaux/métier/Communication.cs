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
        public Communication()  
        {
        }

        //sert à envoyer les pings 
        public bool EnvoiePing(MySqlConnector.MySqlCommand commande)
        {
            MySqlConnector.MySqlCommand ping = commande;
            MySqlConnector.MySqlDataReader reader = ping.ExecuteReader();
            ArrayList ip = new ArrayList();

            // on dit de prendre toute les options à la disposition de la variable Ping options.
            options.DontFragment = true;

            // créer un buffer de 32 octets de données à transmettre.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            
            //booléen permettant de savoir si notre ping a répondu.
            bool flag = false;


            //sert à prendre les ip qui sont dans la BDD afin de les placer dans une liste.
            while (reader.Read())
            {
                ip.Add(reader["ip"]);
            }

            //sert à ping les @ip qui seront dans la liste des @ip
            foreach(ArrayList array in ip)
            {
                pingReply = pingSender.Send($"{array}", timeout, buffer, options);
                //sert à savoir si le ping a obtenu une réponse positive ou négative et modifie le flag en conséquence.
                if (pingReply.Status == IPStatus.Success)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
                
            }
            return flag;
        }
    }
}
