using ProvaWek7.FlorisFederica.Ristorante.Core.Entities;
using ProvaWek7.FlorisFederica.Ristorante.MVC.Models;

namespace ProvaWek7.FlorisFederica.Ristorante.MVC.NewFolder
{
    public static class Mapping
    {
        public static MenuViewModel ToMenuViewModel(this Menu menu)
        {
            
            List<PiattoViewModel> piattiViewModel = new List<PiattoViewModel>();

            foreach (var item in menu.Piatti)
            {
                piattiViewModel.Add(item?.ToPiattoViewModel()); 
            }
            return new MenuViewModel
            {
                Name = menu.Name,
            };
        }
        public static PiattoViewModel ToPiattoViewModel(this Piatto piatto)
        {
            return new PiattoViewModel()
            {
               Nome = piatto.Nome,
               Descrizione = piatto.Descrizione,
               Tipologia = piatto.Tipologia,
               Prezzo = piatto.Prezzo,
                MenuId = piatto.MenuId
            };
        }

        public static Menu ToMenu(this MenuViewModel menuViewModel)
        {
            List<Piatto> piatti = new List<Piatto>();
            foreach(var item in menuViewModel.Piatti)
            {
                piatti.Add(item?.ToPiatto());
            }
            return new Menu
            {
                Name = menuViewModel.Name
            };
        }

        public static Piatto ToPiatto(this PiattoViewModel piattoViewModel)
        {
            return new Piatto()
            {
                Nome = piattoViewModel.Nome,
                Descrizione = piattoViewModel.Descrizione,
                Tipologia = piattoViewModel.Tipologia,
                Prezzo = piattoViewModel.Prezzo,
                MenuId = piattoViewModel.MenuId
            };
        }

        
    }
}
