using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Configurations
{
    public class ClienteConfiguration: IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(e => e.ClienteId);
            builder.Property(t => t.ClienteId).ValueGeneratedOnAdd();
            builder.Property(p => p.Nombre)
                   .HasMaxLength(25);
            builder.Property(p => p.Apellido)
                   .HasMaxLength(25);
            builder.Property(p => p.DNI)
                   .HasMaxLength(10);
            builder.Property(p => p.Telefono)
                   .HasMaxLength(13);

            builder.HasData(
               new Cliente
               {
                   ClienteId = 1,
                   DNI = "32845146",
                   Nombre = "Leonardo",
                   Apellido = "Duca",
                   Direccion = "Lasrrea 2661",
                   Telefono = "111619987541"
               });
        }

    }
}
