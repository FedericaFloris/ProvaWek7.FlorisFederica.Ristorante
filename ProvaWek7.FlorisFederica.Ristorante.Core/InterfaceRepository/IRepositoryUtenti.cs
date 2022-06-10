using ProvaWek7.FlorisFederica.Ristorante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWek7.FlorisFederica.Ristorante.Core.InterfaceRepository
{
    public interface IRepositoryUtenti : IRepository<Utente>
    {
        Utente GetByUsername(string username);
    }
}
