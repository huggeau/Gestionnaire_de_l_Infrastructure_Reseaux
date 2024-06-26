using Gestionnaire_de_l_Infrastructure_Reseaux.affichage;
using Gestionnaire_de_l_Infrastructure_Reseaux.métier;
using MySqlConnector;

namespace Gestionnaire_de_l_Infrastructure_Reseaux;

public partial class FenetrePrincipale : Form
{
    private Communication comm = new Communication();

    //sert à ce connecter à la base de données et de modifier l'affichage des données.
    public FenetrePrincipale()
    {
        InitializeComponent();
        if (comm.PingMairiePrincipale() == true)
        {
            MairiePrincipaleTextBlock.BackColor = Color.Green;
        }
        else
        {
            MairiePrincipaleTextBlock.BackColor = Color.Red;
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
        if (comm.PingMairiePrincipale() == true)
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
        // initialise chaque flag afin de savoir si les pings des sites sont bon ou pas 
        bool flagMairiePrincipale = comm.PingMairiePrincipale();
        bool flagMairieAnnexe = comm.PingMairieAnnexe();
        bool flagAgora = comm.PingAgora();
        bool flagCentreLeBournot = comm.PingCentreLeBournot();
        bool flagPM = comm.PingPoliceMunicipale();
        bool flag18A = comm.Ping18A();
        bool flagCTM = comm.PingCTM();
        bool flagLienhart = comm.PingLienhart();
        bool flagEaux = comm.PingEauxETAssainissement();
        bool flagAbattoirs = comm.PingAbattoirs();
        bool flagSTEP = comm.PingSTEP();
        bool flagChateau = comm.PingChateau();

        // ce sert des différents flags pour changer la couleur pour savoir si les pings sont bon ou pas
        if (flagMairiePrincipale || flagMairieAnnexe || flagAgora || flagCentreLeBournot
            || flagPM || flag18A || flagCTM || flagLienhart || flagEaux || flagAbattoirs
            || flagSTEP || flagChateau)
        {
            MairiePrincipaleTextBlock.BackColor = Color.Green;
            MairieAnnexeTextBox.BackColor = Color.Green;
            AgoraTextBox.BackColor = Color.Green;
            PMTextBox.BackColor = Color.Green;
            CTMTextBox.BackColor = Color.Green;
            EauxAssainTextBox.BackColor = Color.Green;
            STEPTextBox.BackColor = Color.Green;
            CentreBournotTextBox.BackColor = Color.Green;
            LienhartTextBox.BackColor = Color.Green;
            AbattoirsTextBox.BackColor = Color.Green;
        }
        else
        {
            MairiePrincipaleTextBlock.BackColor = Color.Red;
            MairieAnnexeTextBox.BackColor = Color.Red;
            AgoraTextBox.BackColor = Color.Red;
            PMTextBox.BackColor = Color.Red;
            CTMTextBox.BackColor = Color.Red;
            EauxAssainTextBox.BackColor = Color.Red;
            STEPTextBox.BackColor = Color.Red;
            CentreBournotTextBox.BackColor = Color.Red;
            LienhartTextBox.BackColor = Color.Red;
            AbattoirsTextBox.BackColor = Color.Red;
        }
    }

    private void boutonMairiePrincipale(object sender, EventArgs e)
    {
        FenetreMairiePrinicpale fenetreMairiePrincipale = new FenetreMairiePrinicpale();
        fenetreMairiePrincipale.ShowDialog();
    }

    private void boutonMairieAnnexe_Click(object sender, EventArgs e)
    {

    }
}
