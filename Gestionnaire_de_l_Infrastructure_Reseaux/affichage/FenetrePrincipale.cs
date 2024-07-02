using Gestionnaire_de_l_Infrastructure_Reseaux.affichage;
using Gestionnaire_de_l_Infrastructure_Reseaux.métier;
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



    //méthode créer par le designer et modifié par le développeur

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
    //sert à lancer les pings vers les infrastructure toute les 10 minutes
    private void timer_Tick(object sender, EventArgs e)
    {
        Ping();
    }
    //sert à forcer le lancement de la méthode EnvoiePing().
    private void forcerUnPingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Ping();
    }
    private void FenetrePrincipale_FormClosing(object sender, FormClosingEventArgs e)
    {
        SaveButtonPositionsInDatabase();
    }

    //méthode permettant d'aciver ou non le déplacement des éléments d'affichage
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

    //méthode permettant de charger tout les site de la BDD 
    private void loadLaBddToolStripMenuItem_Click(object sender, EventArgs e)
    {
        LoadButtonsFromDatabase();
        Ping();
    }



    // méthode créer par le développeur
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
                    Enabled = true,
                    Visible = true,
                    Text = name,
                    AllowDrop = true,

                };

                bouton.DoubleClick += Button_DoubleClick;

                Lbouton.Add(bouton); // ajoute les boutons à la liste 


                panelPrinicpale.Controls.Add(bouton);

                // Debugging output
                Console.WriteLine($"Panel created: {bouton.Name} at {bouton.Location}");
            }

            reader.Close();

            buttons = Lbouton.ToArray();
        }
    }
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
    private void Button_DoubleClick(object? sender, EventArgs e)
    {
        FenetreMairiePrinicpale fenetreMairiePrinicpale = new FenetreMairiePrinicpale();
        fenetreMairiePrinicpale.ShowDialog();
    }
    private void AttachMouseHandlers()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].MouseDown += Button_MouseDown;
            buttons[i].MouseMove += Button_MouseMove;
            buttons[i].MouseUp += Button_MouseUp;
        }
    }
    private void DetachMouseHandlers()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].MouseDown -= Button_MouseDown;
            buttons[i].MouseMove -= Button_MouseMove;
            buttons[i].MouseUp -= Button_MouseUp;
        }
    }
    public void Ping()
    {
        // initialise la liste des id de tout les sites de la BDD
        List<int> siteIds = comm.RemplirListSite();

        // vient tester sur tout les sites si leurs éléments sont pingable et change l'affichage celon le résultat sortie
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