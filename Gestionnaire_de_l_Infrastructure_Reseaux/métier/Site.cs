using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionnaire_de_l_Infrastructure_Reseaux.métier
{
    public class Site
    {
        private int id;
        public int Id 
        { 
            get { return id; } 
            set { id = value; } 
        }
        private string nom; 
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public Site() { 
        }
    }
}
