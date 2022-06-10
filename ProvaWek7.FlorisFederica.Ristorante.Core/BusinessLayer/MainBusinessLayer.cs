using ProvaWek7.FlorisFederica.Ristorante.Core.Entities;
using ProvaWek7.FlorisFederica.Ristorante.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWek7.FlorisFederica.Ristorante.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryMenu menuRepo;
        private readonly IRepositoryPiatti piattiRepo;
        private readonly IRepositoryUtenti utentiRepo;

        public MainBusinessLayer(IRepositoryMenu menu, IRepositoryPiatti piatti, IRepositoryUtenti utente)
        {
            menuRepo = menu;
            piattiRepo = piatti;
            utentiRepo = utente;
        }

        public bool AggiungiMenu(Menu nuovoMenu)
        {
            Menu menuRecuperato = menuRepo.GetById(nuovoMenu.Id);
            if(menuRecuperato == null)
            {
                menuRepo.Add(nuovoMenu);
                return true;
            }
            return false;
        }

        public bool AggiungiPiatto(Piatto piatto)
        {
            Piatto piattoRecuperato = piattiRepo.GetById(piatto.Id);
            if(piattoRecuperato == null)
            {
                piattiRepo.Add(piatto);
                return true;
            }
            return false;

        }

        public bool EliminaPiatto(int idPiatto)
        {
            Piatto eliminaPiatto = piattiRepo.GetById(idPiatto);
            if(eliminaPiatto == null)
            { return false;}
            piattiRepo.Delete(eliminaPiatto);
            return true;
        }

        public List<Menu> GetAllMenu()
        {
            return menuRepo.GetAll();
        }

        public List<Piatto> GetAllPiatto()
        {
            return piattiRepo.GetAll();
        }

        public bool ModificaMenu(Menu menuDaModificare)
        {
            Menu menuRecuperato = menuRepo.GetById(menuDaModificare.Id);
            if (menuRecuperato == null)
            {
                return false;
            }
            menuRepo.Update(menuRecuperato);
            return true;
        }

        public bool ModificaPiatto(int idPiattoDaModificare, decimal nuovoPrezzo)
        {
            Piatto piattoRecuparato = piattiRepo.GetById(idPiattoDaModificare);
            if(piattoRecuparato == null)
                return false;
            piattoRecuparato.Prezzo = nuovoPrezzo;
            piattiRepo.Update(piattoRecuparato);
            return true;
        }

        public Utente GetAccount(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            return utentiRepo.GetByUsername(username);
        }
    }
}
