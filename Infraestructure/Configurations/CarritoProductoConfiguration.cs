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
    public class CarritoProductoConfiguration : IEntityTypeConfiguration<CarritoProducto>
    {
        public void Configure(EntityTypeBuilder<CarritoProducto> builder)
        {
            builder.ToTable("CarritoProducto");
            builder.HasKey(e => new { e.ProductoId, e.CarritoId });

            builder.HasOne<Carrito>(c=> c.Carrito)
                   .WithMany(p => p.CarritoProductos)
                   .HasForeignKey(c => c.CarritoId);

            builder.HasOne<Producto>(c => c.Producto)
                .WithMany(p => p.CarritoProductos)
                .HasForeignKey(c => c.ProductoId);

        }

    }
}
