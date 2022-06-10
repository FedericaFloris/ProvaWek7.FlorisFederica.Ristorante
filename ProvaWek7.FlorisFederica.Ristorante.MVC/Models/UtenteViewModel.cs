using ProvaWek7.FlorisFederica.Ristorante.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProvaWek7.FlorisFederica.Ristorante.MVC.Models
{
    public class UtenteViewModel
    {
        public int id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)] 
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public Ruolo Ruolo { get; set; } = Ruolo.Cliente;
    }
}
