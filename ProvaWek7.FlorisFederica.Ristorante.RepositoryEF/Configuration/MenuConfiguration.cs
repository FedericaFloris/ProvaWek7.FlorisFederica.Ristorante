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
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired();

            //relazione con Piatto 1:N
            builder.HasMany(m => m.Piatti).WithOne(m => m.Menu).HasForeignKey(m => m.Id);
        }
    }
}
