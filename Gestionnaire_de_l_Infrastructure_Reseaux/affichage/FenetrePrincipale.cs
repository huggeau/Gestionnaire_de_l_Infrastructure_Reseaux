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
        if (comm.EnvoieEtReceptionPing("SELECT id, ip FROM Materiel_Reseau") == true)
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
        if (comm.EnvoieEtReceptionPing("SELECT id, ip FROM Materiel_Reseau") == true)
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
