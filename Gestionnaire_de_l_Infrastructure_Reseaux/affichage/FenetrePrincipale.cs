using Gestionnaire_de_l_Infrastructure_Reseaux.affichage;
using Gestionnaire_de_l_Infrastructure_Reseaux.métier;
using MySqlConnector;

namespace Gestionnaire_de_l_Infrastructure_Reseaux;

public partial class FenetrePrincipale : Form
{
    //variable de classe nécessaire à la connexion pour la base de données 
    private MySqlConnection conn;
    private string host;
    private string database;
    private string username;
    private string password;
    private string connString;
    private Communication comm = new Communication();

    //sert à ce connecter à la base de données et de modifier l'affichage des données.
    public FenetrePrincipale()
    {
        InitializeComponent();

        host = "192.168.10.145";
        database = "db_Reseau_Mairie";
        username = "administrateur";
        password = "Admin07200&";
        connString = $"SERVER={host}; DATABASE={database}; UID={username}; PASSWORD={password}";

        using (conn = new MySqlConnection(connString))
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
    private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FenetreAjout fenetreAjout = new FenetreAjout();
        fenetreAjout.ShowDialog();
    }

    private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FenetreSupprimer fenetreSupprimer = new FenetreSupprimer();
        fenetreSupprimer.ShowDialog();
    }

    private void rechercheToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FenetreRecherche fenetreRecherche = new FenetreRecherche();
        fenetreRecherche.ShowDialog();
    }

    //coupe la connexion à la base de donnée lorsque la page WinFom est fermé.
    private void FenetrePrincipale_FormClosing(object sender, FormClosingEventArgs e)
    {
        conn.Close();
    }

    //sert à lancer les pings vers les infrastructure toute les 10 minutes
    private void timer_Tick(object sender, EventArgs e)
    {
        MySqlCommand commande = conn.CreateCommand();
        commande.CommandText = "SELECT ip FROM Materiel_Reseau";
        if (comm.EnvoiePing(commande) == true)
        {
            MairiePrincipaleTextBlock.BackColor = Color.Green;
        }
        else
        {
            MairiePrincipaleTextBlock.BackColor = Color.Red;
        }
    }

    //sert à forcer le lancement de la méthode EnvoiePing().
    private void forcerUnPingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MySqlCommand commande = conn.CreateCommand();
        commande.CommandText = "SELECT id, ip FROM Materiel_Reseau";
        if (comm.EnvoiePing(commande) == true)
        {
            MairiePrincipaleTextBlock.BackColor = Color.Green;
        }
        else
        {
            MairiePrincipaleTextBlock.BackColor = Color.Red;
        }
    }

    private void boutonMairiePrincipale(object sender, EventArgs e)
    {
        FenetreDeGestion fenetreDeGestion = new FenetreDeGestion();
        fenetreDeGestion.ShowDialog();
    }
}
