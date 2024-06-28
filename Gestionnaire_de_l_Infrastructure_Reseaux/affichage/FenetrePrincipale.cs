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
    private string? connString;
    private bool isDragging = false;
    private bool isMoveModeEnabled = false;
    private Point startPoint = new Point(0, 0);



    //méthode créer par le designer et modifié par le développeur

    //sert à ce connecter à la base de données et de modifier l'affichage des données.
    public FenetrePrincipale()
    {
        InitializeComponent();

        this.Load += new EventHandler(FenetrePrincipale_Load);

        // ajoute un bouton pour activer le déplacement des panels
        Button moveModeButton = new Button
        {
            Text = "Activer Deplacement Panel",
            ForeColor = Color.Black,
            Size = new Size(230,29),
            Location = new Point(0, 30)
        };
        moveModeButton.Click += new EventHandler(MoveModeButton_Click);
        this.Controls.Add(moveModeButton);

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


    //méthode créer par le développeur
    private void FenetrePrincipale_Load(object? sender, EventArgs e)
    {
        LoadPanelsFromDatabase();
    }
    private void LoadPanelsFromDatabase()
    {

        string query = "SELECT Id, Nom, XPosition, YPosition FROM Site LIMIT 1";

        using (MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(comm.connexionBDD()))
        {
            MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand(query, connection);
            connection.Open();
            MySqlConnector.MySqlDataReader reader = command.ExecuteReader();

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
                    Name = "panel_" + id,
                    Enabled = true
                };

                Label label = new Label
                {
                    Text = name,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                panel.Controls.Add(label);

                panel.MouseDown += new MouseEventHandler(Panel_MouseDown);
                panel.MouseMove += new MouseEventHandler(Panel_MouseMove);
                panel.MouseUp += new MouseEventHandler(Panel_MouseUp);
                panel.DoubleClick += new EventHandler(Panel_DoubleClick);

                this.Controls.Add(panel);
            }

            reader.Close();
        }
    }
    private void MoveModeButton_Click(object sender, EventArgs e)
    {
        isMoveModeEnabled = !isMoveModeEnabled;

        if (isMoveModeEnabled)
        {
            AttachMouseHandlers();
             
        }
        else
        {
            DetachMouseHandlers();
            Console.WriteLine("Move mode disabled");
        }
    }
    private void Panel_MouseDown(object? sender, MouseEventArgs e)
    {
        if (sender is Panel && e.Button == MouseButtons.Left)
        {
            isDragging = true;
            startPoint = e.Location;
        }
    }
    private void Panel_MouseMove(object? sender, MouseEventArgs e)
    {
        if (isDragging && sender is Panel panel)
        {
            panel.Left = e.X + panel.Left - startPoint.X;
            panel.Top = e.Y + panel.Top - startPoint.Y;
        }
    }
    private void Panel_MouseUp(object? sender, MouseEventArgs e)
    {
        isDragging = false;
    }
    private void Panel_DoubleClick(object? sender, EventArgs e)
    {
        FenetreMairiePrinicpale fenetreMairiePrinicpale = new FenetreMairiePrinicpale();
        fenetreMairiePrinicpale.ShowDialog();
    }
    private void AttachMouseHandlers()
    {
        foreach (Control control in this.Controls)
        {
            if (control is Panel panel)
            {
                panel.MouseDown += new MouseEventHandler(Panel_MouseDown);
                panel.MouseMove += new MouseEventHandler(Panel_MouseMove);
                panel.MouseUp += new MouseEventHandler(Panel_MouseUp);
            }
        }
    }
    private void DetachMouseHandlers()
    {
        foreach (Control control in this.Controls)
        {
            if (control is Panel panel)
            {
                panel.MouseDown -= new MouseEventHandler(Panel_MouseDown);
                panel.MouseMove -= new MouseEventHandler(Panel_MouseMove);
                panel.MouseUp -= new MouseEventHandler(Panel_MouseUp);
            }
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
        if (flagMairiePrincipale)
        {
            MairiePrincipaleTextBlock.BackColor = Color.Green;
        }
        else
        {
            MairiePrincipaleTextBlock.BackColor = Color.Red;
        }
        if (flagMairieAnnexe)
        {
            MairieAnnexeTextBox.BackColor = Color.Green;
        }
        else
        {
            MairieAnnexeTextBox.BackColor = Color.Red;
        }
        if (flagCentreLeBournot)
        {
            CentreBournotTextBox.BackColor = Color.Green;
        }
        else
        {
            CentreBournotTextBox.BackColor = Color.Red;
        }
        if (flagCTM)
        {
            CTMTextBox.BackColor = Color.Green;
        }
        else
        {
            CTMTextBox.BackColor = Color.Red;
        }
        if (flagAgora)
        {
            AgoraTextBox.BackColor = Color.Green;
        }
        else
        {
            AgoraTextBox.BackColor = Color.Red;
        }
        if (flagPM)
        {
            PMTextBox.BackColor = Color.Green;
        }
        else
        {
            PMTextBox.BackColor = Color.Red;
        }
    }
}