using ProvaWek7.FlorisFederica.Ristorante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWek7.FlorisFederica.Ristorante.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        List<Menu> GetAllMenu();

        bool AggiungiMenu(Menu nuovoMenu);
        bool ModificaMenu(Menu menuDaMedificare);

        List<Piatto> GetAllPiatto();
        bool AggiungiPiatto(Piatto piatto);
        bool ModificaPiatto(int idPiattoDaModificare, decimal nuovoPrezzo);
        bool EliminaPiatto(int idPiatto);
        public Utente GetAccount(string username);
    }
}
