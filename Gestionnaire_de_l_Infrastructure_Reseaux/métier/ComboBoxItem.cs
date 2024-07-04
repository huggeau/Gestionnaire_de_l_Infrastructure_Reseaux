using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionnaire_de_l_Infrastructure_Reseaux.métier
{
    internal class ComboBoxItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ComboBoxItem(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name; // Cela permettra d'afficher le nom dans la ComboBox
        }
    }
}
