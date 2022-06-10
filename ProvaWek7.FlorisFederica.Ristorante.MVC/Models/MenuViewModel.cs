using ProvaWek7.FlorisFederica.Ristorante.Core.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProvaWek7.FlorisFederica.Ristorante.MVC.Models
{
    public class MenuViewModel
    {
        [DisplayName("Id Menu")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<PiattoViewModel> Piatti { get; set; } = new List<PiattoViewModel>();

        public override string ToString()
        {
            return $"{Id}\t{Name}";
        }
    }
}
