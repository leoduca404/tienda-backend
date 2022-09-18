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
    public class CarritoConfiguration : IEntityTypeConfiguration<Carrito>
    {
        public void Configure(EntityTypeBuilder<Carrito> builder)
        {
            builder.ToTable("Carrito");
            builder.HasKey(e => e.CarritoId);
            builder.HasOne<Cliente>(carrito => carrito.Cliente)
               .WithMany(cliente => cliente.Carritos)
               .HasForeignKey(carrito => carrito.ClienteId);
        }

    }
}
