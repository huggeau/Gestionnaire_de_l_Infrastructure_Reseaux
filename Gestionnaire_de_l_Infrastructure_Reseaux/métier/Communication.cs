using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Gestionnaire_de_l_Infrastructure_Reseaux.métier
{
    internal class Communication
    {
        private Ping ping = new Ping();
        private PingReply pingReply;
        public Communication()  
        {
        }

        //sert à envoyer les pings 
        public void EnvoiePing()
        {
            ping.Send("192.168.10.145");
        }

        //sert à récéptionner les pings
        public void ReceptionPing()
        {
            Console.WriteLine(pingReply);
        }
    }
}
