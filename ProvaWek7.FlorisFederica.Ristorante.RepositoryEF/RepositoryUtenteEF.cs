using ProvaWek7.FlorisFederica.Ristorante.Core.Entities;
using ProvaWek7.FlorisFederica.Ristorante.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWek7.FlorisFederica.Ristorante.RepositoryEF
{
    public class RepositoryUtenteEF : IRepositoryUtenti
    {
        public Utente Add(Utente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Utenti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Utente item)
        {
            using(var ctx = new MasterContext())
            {
                ctx.Utenti.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Utente> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Utenti.ToList();

            }
        }

        public Utente GetByUsername(string username)
        {
            using (var ctx = new MasterContext())
            {
                if (string.IsNullOrEmpty(username))
                {
                    return null;
                }
                return ctx.Utenti.FirstOrDefault(u => u.Username == username);
            }
        }

        public Utente Update(Utente item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Utenti.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
