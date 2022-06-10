using ProvaWek7.FlorisFederica.Ristorante.Core.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProvaWek7.FlorisFederica.Ristorante.MVC.Models
{
    public class PiattoViewModel
    {
        [DisplayName("Id Piatto")]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descrizione { get; set; }
        [Required]
        public Tipologia Tipologia { get; set; }
        [Required]
        public decimal Prezzo { get; set; }

        //FK
        public int? MenuId { get; set; }
        public MenuViewModel? Menu { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"{Id}\t {Nome} \t {Descrizione}\t {Tipologia}\t {Prezzo}";
        }
    }
}
