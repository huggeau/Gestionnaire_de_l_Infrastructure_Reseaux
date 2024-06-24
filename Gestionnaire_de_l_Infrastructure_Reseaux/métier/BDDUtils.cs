using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gestionnaire_de_l_Infrastructure_Reseaux.métier
{
    internal class BDDUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "192.168.10.145";
            int port = 3306;
            string database = "db23_glpi";
            string username = "root";
            string password = "Admin07200&";

            return BDDMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
