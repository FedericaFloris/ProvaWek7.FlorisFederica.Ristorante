using Microsoft.EntityFrameworkCore;
using ProvaWek7.FlorisFederica.Ristorante.Core.Entities;
using ProvaWek7.FlorisFederica.Ristorante.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWek7.FlorisFederica.Ristorante.RepositoryEF
{
    public class RepositoryMenuEF : IRepositoryMenu
    {
        public Menu Add(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Menu.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Menu.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Menu> GetAll()
        {

            using (var ctx = new MasterContext())
            {
                return ctx.Menu.Include(p => p.Piatti).ToList();

            }
        }

        public Menu GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Menu.Include(m => m.Piatti).FirstOrDefault(m => m.Id == id);
            }
        }

        public Menu Update(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Menu.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
