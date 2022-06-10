using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaWek7.FlorisFederica.Ristorante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWek7.FlorisFederica.Ristorante.RepositoryEF.Configuration
{
    public class PiattoConfiguration : IEntityTypeConfiguration<Piatto>
    {
        public void Configure(EntityTypeBuilder<Piatto> builder)
        {
            builder.ToTable("Piatto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Descrizione).IsRequired();
            builder.Property(p => p.Tipologia).IsRequired();
            builder.Property(p => p.Prezzo).IsRequired();

            //relazione con Menu 1:N
            builder.HasOne(p =>p.Menu).WithMany(p => p.Piatti).HasForeignKey(p => p.MenuId);
           

            

            
        }
    }
}
