using Gestionnaire_de_l_Infrastructure_Reseaux.affichage;
using Gestionnaire_de_l_Infrastructure_Reseaux.métier;
using MySqlConnector;

namespace Gestionnaire_de_l_Infrastructure_Reseaux;

public partial class FenetrePrincipale : Form
{
    private Communication comm = new Communication();
    public Panel movablePanel;
    private bool isDragging = false;
    private Point startPoint = new Point(0, 0);

    //sert à ce connecter à la base de données et de modifier l'affichage des données.
    public FenetrePrincipale()
    {
        InitializeComponent();

        // Initialize the Panel
        movablePanel = new Panel
        {
            Size = new Size(200, 100),
            BackColor = Color.LightBlue,
            Location = new Point(50, 50)
        };

        // Add Mouse event handlers
        movablePanel.MouseDown += new MouseEventHandler(movablePanel_MouseDown);
        movablePanel.MouseMove += new MouseEventHandler(movablePanel_MouseMove);
        movablePanel.MouseUp += new MouseEventHandler(movablePanel_MouseUp);

        // Add the Panel to the Form
        Controls.Add(movablePanel);

        //fait un Ping initiale afin de savoir quel site est bon ou à un élément deffectueux
        Ping();
    }

    private void movablePanel_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = true;
            startPoint = e.Location;
        }
    }

    private void movablePanel_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            Point p = PointToClient(MousePosition);
            movablePanel.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
        }
    }

    private void movablePanel_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = false;
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

    private void boutonMairiePrincipale(object sender, EventArgs e)
    {
        FenetreMairiePrinicpale fenetreMairiePrincipale = new FenetreMairiePrinicpale();
        fenetreMairiePrincipale.ShowDialog();
    }

    private void boutonMairieAnnexe_Click(object sender, EventArgs e)
    {
        FenetreMairiePrinicpale fenetre = new FenetreMairiePrinicpale();
        fenetre.ShowDialog();
    }
    private void FenetrePrincipale_Load(object sender, EventArgs e)
    {

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
        if (flagLienhart)
        {
            LienhartTextBox.BackColor = Color.Green;
        }
        else
        {
            LienhartTextBox.BackColor = Color.Red;
        }
        if (flagEaux)
        {
            EauxAssainTextBox.BackColor = Color.Green;
        }
        else
        {
            EauxAssainTextBox.BackColor = Color.Red;
        }
        if (flagCTM)
        {
            CTMTextBox.BackColor = Color.Green;
        }
        else
        {
            CTMTextBox.BackColor = Color.Red;
        }
        if (flagAbattoirs)
        {
            AbattoirsTextBox.BackColor = Color.Green;
        }
        else
        {
            AbattoirsTextBox.BackColor = Color.Red;
        }
        if (flagSTEP)
        {
            STEPTextBox.BackColor = Color.Green;
        }
        else
        {
            STEPTextBox.BackColor = Color.Red;
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

    private void FenetrePrincipale_FormClosing(object sender, FormClosingEventArgs e)
    {
        comm.SavePanelPositions();
    }
}