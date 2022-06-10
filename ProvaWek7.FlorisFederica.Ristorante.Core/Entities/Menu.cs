using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWek7.FlorisFederica.Ristorante.Core.Entities
{
    public class Menu
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public ICollection<Piatto> Piatti { get; set; }
    }
}
