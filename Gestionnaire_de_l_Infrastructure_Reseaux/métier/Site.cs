using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionnaire_de_l_Infrastructure_Reseaux.métier
{
    public class Site
    {
        private string Id {  get; set; }
        private string Nom { get; set; }
        public Site(string id, string nom) {
            Nom = nom;
            Id = id;
        }
    }
}
