using Gestionnaire_de_l_Infrastructure_Reseaux.affichage;
using Gestionnaire_de_l_Infrastructure_Reseaux.m�tier;
using MySql.Data.MySqlClient;
using MySqlConnector;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.DirectoryServices.ActiveDirectory;
using System.Collections;
using System.Security.Policy;

namespace Gestionnaire_de_l_Infrastructure_Reseaux;

public partial class FenetrePrincipale : Form
{
    private Communication comm = new Communication();
    private bool isDragging = false;
    private bool isMoveModeEnabled = false;
    private Point startPoint = new Point(0, 0);

    private Button[]? buttons; // tableau qui va contenir tout les paneaux



    //m�thode cr�er par le designer et modifi� par le d�veloppeur

    public FenetrePrincipale()
    {
        InitializeComponent();
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

    //sert � lancer les pings vers les infrastructure toute les 10 minutes
    private void timer_Tick(object sender, EventArgs e)
    {
        Ping();
    }

    //sert � forcer le lancement de la m�thode EnvoiePing().
    private void forcerUnPingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Ping();
    }
   
    //sauvegarde la position des sites juste avant la fermetrure de la fenetre
    private void FenetrePrincipale_FormClosing(object sender, FormClosingEventArgs e)
    {
        SaveButtonPositionsInDatabase();
    }

    //m�thode permettant d'aciver ou non le d�placement des �l�ments d'affichage
    private void activerLeDeplacementDesPanelsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        isMoveModeEnabled = !isMoveModeEnabled;

        if (isMoveModeEnabled)
        {
            AttachMouseHandlers();
            activerLeDeplacementDesPanelsToolStripMenuItem.BackColor = Color.Green;
        }
        else
        {
            DetachMouseHandlers();
            activerLeDeplacementDesPanelsToolStripMenuItem.BackColor = Color.Silver;
        }
    }

    //m�thode permettant de charger tout les site de la BDD 
    private void loadLaBddToolStripMenuItem_Click(object sender, EventArgs e)
    {
        LoadButtonsFromDatabase();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].Click += Button_Click;
        }
        Ping();
    }



    // m�thode cr�er par le d�veloppeur

    //methode permettant de cr�er x boutons ( x �tant l jombre de site qu'il y aura dans la bdd )
    private void LoadButtonsFromDatabase()
    {

        string query = "SELECT id, nom, XPosition, YPosition FROM Site ";

        using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
        {
            MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(query, connection);
            connection.Open();
            MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

            List<Button> Lbouton = new List<Button>();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int xPosition = reader.GetInt32(2);
                int yPosition = reader.GetInt32(3);

                Button bouton = new Button
                {
                    Size = new Size(156, 97),
                    Location = new Point(xPosition, yPosition),
                    BackColor = Color.Gray,
                    Name = "bouton" + id,
                    Tag = id,
                    Enabled = true,
                    Visible = true,
                    Text = name,
                    AllowDrop = true,

                };

                

                Lbouton.Add(bouton); // ajoute les boutons � la liste 


                panelPrinicpale.Controls.Add(bouton);

                // Debugging output
                Console.WriteLine($"Panel created: {bouton.Name} at {bouton.Location}");
            }

            reader.Close();

            buttons = Lbouton.ToArray();
        }
    }

    //les m�thodes suivantes vont servir � pouvoir bouger nos sites afin de les d�placer ou l'on veut sur la fenetre
    private void Button_MouseDown(object? sender, MouseEventArgs e)
    {
        if (isMoveModeEnabled)
        {
            isDragging = true;
            startPoint = e.Location;
            Console.WriteLine("MouseDown triggered");
        }
    }
    private void Button_MouseMove(object? sender, MouseEventArgs e)
    {
        if (isDragging && isMoveModeEnabled && sender is Button button)
        {
            button.Left = e.X + button.Left - startPoint.X;
            button.Top = e.Y + button.Top - startPoint.Y;
            Console.WriteLine($"MouseMove triggered for {button.Name}");
        }
    }
    private void Button_MouseUp(object? sender, MouseEventArgs e)
    {
        if (isMoveModeEnabled)
        {
            isDragging = false;
            Console.WriteLine("MouseUp triggered");
        }
    }

    // m�thode qui  quand on clique sur un site ouvre la fenetre d'administration du site
    private void Button_Click(object? sender, EventArgs e)
    {
        Button bouton = (Button)sender;
        int id = (int)bouton.Tag;
        FenetreAdministrationSite fenetreMairiePrinicpale = new FenetreAdministrationSite(id);
        fenetreMairiePrinicpale.ShowDialog();
    }

    //les m�thodes suivantes sont reli� a un bouton et servent a activer/ desactiver
    //les m�thodes de d�placement et de clique des sites
    private void AttachMouseHandlers()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].MouseDown += Button_MouseDown;
            buttons[i].MouseMove += Button_MouseMove;
            buttons[i].MouseUp += Button_MouseUp;
            buttons[i].Click -= Button_Click;
        }
    }
    private void DetachMouseHandlers()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].MouseDown -= Button_MouseDown;
            buttons[i].MouseMove -= Button_MouseMove;
            buttons[i].MouseUp -= Button_MouseUp;
            buttons[i].Click += Button_Click;
        }
    }

    //sert a chang� la couleur des sites selon leur r�sultat des pings
    public void Ping()
    {
        // initialise la liste des id de tout les sites de la BDD
        List<int> siteIds = comm.RemplirListSite();

        // vient tester sur tout les sites si leurs �l�ments sont pingable et change l'affichage celon le r�sultat sortie
        for (int i = 0; i < siteIds.Count; i++)
        {
            int siteId = siteIds[i];
            if (comm.PingGeneral(siteId))
            {
                buttons[i].BackColor = Color.Green;
            }
            else
            {
                buttons[i].BackColor = Color.Red;
            }
        }
    }

    //sert a enregistrer la position des sites sur la fenetre dans la bdd
    public void SaveButtonPositionsInDatabase()
    {
        using (var connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
        {
            connection.Open();
            List<int> siteIds = comm.RemplirListSite();
            // Insert new position
            for(int i=0; i < siteIds.Count; i++)
            {
                int siteId = siteIds[i];
                string updateQuery = "UPDATE Site SET XPosition = @x, YPosition = @y WHERE id = @id";

                using (var command = new MySqlConnector.MySqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@x", buttons[i].Location.X);
                    command.Parameters.AddWithValue("@y", buttons[i].Location.Y);
                    command.Parameters.AddWithValue("@id", siteId);
                    command.ExecuteNonQuery();
                }
            }
            
        }
    }
}