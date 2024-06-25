using Gestionnaire_de_l_Infrastructure_Reseaux.métier;
using MySqlConnector;

namespace Gestionnaire_de_l_Infrastructure_Reseaux
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FenetrePrincipale());

            string host = "192.168.10.145";
            string database = "db_Reseau_Mairie";
            string username = "administrateur";
            string password = "Admin07200&";
            string connString = $"SERVER={host}; DATABASE={database}; UID={username}; PASSWORD={password}";

            using (MySqlConnection conn = new MySqlConnection(connString))
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
    }
}