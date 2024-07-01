using Gestionnaire_de_l_Infrastructure_Reseaux.affichage;
using Gestionnaire_de_l_Infrastructure_Reseaux.métier;
using MySql.Data.MySqlClient;
using MySqlConnector;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.DirectoryServices.ActiveDirectory;

namespace Gestionnaire_de_l_Infrastructure_Reseaux;

public partial class FenetrePrincipale : Form
{
    private Communication comm = new Communication();
    private bool isDragging = false;
    private bool isMoveModeEnabled = false;
    private Point startPoint = new Point(0, 0);

    private Panel[]? panels; // tableau qui va contenir tout les paneaux



    //méthode créer par le designer et modifié par le développeur

    //sert à ce connecter à la base de données et de modifier l'affichage des données.
    public FenetrePrincipale()
    {
        InitializeComponent();

        if (this.InvokeRequired)
        {
            this.Invoke(new Action(LoadPanelsFromDatabase));
        }
        else
        {
            LoadPanelsFromDatabase();
        }
        this.Load += new EventHandler(FenetrePrincipale_Load);

        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].BringToFront();
        }


        //fait un Ping initiale afin de savoir quel site est bon ou à un élément deffectueux
        Ping();
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
        // comm.SavePanelPositions();
    }
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


    //méthode créer par le développeur
    private void FenetrePrincipale_Load(object? sender, EventArgs e)
    {
        LoadPanelsFromDatabase();
    }
    private void LoadPanelsFromDatabase()
    {

        string query = "SELECT Id, Nom, XPosition, YPosition FROM Site ";

        using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
        {
            MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(query, connection);
            connection.Open();
            MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

            List<Panel> Lpanel = new List<Panel>();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int xPosition = reader.GetInt32(2);
                int yPosition = reader.GetInt32(3);

                Panel panel = new Panel
                {
                    Size = new Size(156, 97),
                    Location = new Point(xPosition, yPosition),
                    BackColor = Color.Gray,
                    Name = "panel" + id,
                    Enabled = true,
                    Visible = true,
                };

                Label label = new Label
                {
                    Text = name,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                panel.Controls.Add(label);

                Lpanel.Add(panel); // ajoute les panels à la liste 


                this.Controls.Add(panel);

                // Debugging output
                Console.WriteLine($"Panel created: {panel.Name} at {panel.Location}");
            }

            reader.Close();

            panels = Lpanel.ToArray();
        }
    }
    private void Panel_MouseDown(object? sender, MouseEventArgs e)
    {
        if (isMoveModeEnabled )
        {
            isDragging = true;
            startPoint = e.Location;
            Console.WriteLine("MouseDown triggered");
        }
    }
    private void Panel_MouseMove(object? sender, MouseEventArgs e)
    {
        if (isDragging && isMoveModeEnabled && sender is Panel panel)
        {
            panel.Left = e.X + panel.Left - startPoint.X;
            panel.Top = e.Y + panel.Top - startPoint.Y;
            Console.WriteLine($"MouseMove triggered for {panel.Name}");
        }
    }
    private void Panel_MouseUp(object? sender, MouseEventArgs e)
    {
        if (isMoveModeEnabled)
        {
            isDragging = false;
            Console.WriteLine("MouseUp triggered");
        }
    }
    private void AttachMouseHandlers()
    {
        foreach (Panel panel in panels)
        {
            panel.MouseDown += new MouseEventHandler(Panel_MouseDown);
            panel.MouseMove += new MouseEventHandler(Panel_MouseMove);
            panel.MouseUp += new MouseEventHandler(Panel_MouseUp);
        }
    }
    private void DetachMouseHandlers()
    {
        foreach (Panel panel in panels)
        {
            panel.MouseDown -= new MouseEventHandler(Panel_MouseDown);
            panel.MouseMove -= new MouseEventHandler(Panel_MouseMove);
            panel.MouseUp -= new MouseEventHandler(Panel_MouseUp);
        }
    }
    public void Ping()
    {
        // initialise chaque flag afin de savoir si les pings des sites sont bon ou pas 
        bool flagMairiePrincipale = comm.PingGeneral(1);
        bool flagMairieAnnexe = comm.PingGeneral(3);
        bool flagAgora = comm.PingGeneral(5);
        bool flagCentreLeBournot = comm.PingGeneral(6);
        bool flagPM = comm.PingGeneral(7);
        bool flag18A = comm.PingGeneral(8);
        bool flagCTM = comm.PingGeneral(10);
        bool flagLienhart = comm.PingGeneral(11);
        bool flagEaux = comm.PingGeneral(12);
        bool flagAbattoirs = comm.PingGeneral(13);
        bool flagSTEP = comm.PingGeneral(14);
        bool flagChateau = comm.PingGeneral(25);

        // ce sert des différents flags pour changer la couleur pour savoir si les pings sont bon ou pas

    }

    //public void SavePanelPositions()
    //{
        
    //    using (var connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
    //    {

    //        connection.Open();

    //        // Insert new position
    //        string insertQuery = "INSERT INTO PanelPosition (X, Y) VALUES (@x, @y)";
    //        using (var command = new MySqlConnector.MySqlCommand(insertQuery, connection))
    //        {
    //            command.Parameters.AddWithValue("@x", FenetrePrincipale.panels[].Location.X);
    //            command.Parameters.AddWithValue("@y", FenetrePrincipale.movablePanel.Location.Y);
    //            command.ExecuteNonQuery();
    //        }
    //    }
    //}
}