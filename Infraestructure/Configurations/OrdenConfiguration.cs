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
    public class OrdenConfiguration:IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.ToTable("Orden");
            builder.HasKey(o => o.OrdenId);
            builder.Property(o => o.Total)
                    .HasColumnType("decimal(15,2)");
            builder.HasOne<Carrito>(o => o.Carrito)
                   .WithOne(ad => ad.Orden)
                   .HasForeignKey<Carrito>(ad => ad.CarritoId);

            //TODO VER RELACION uno a muchos con carritoProducto

        }

    }
}
