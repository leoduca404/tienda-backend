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
    public class ProductoConfiguration:IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {      
            builder.ToTable("Producto");
            builder.HasKey(p => p.ProductoId);
            builder.Property(p => p.ProductoId).ValueGeneratedOnAdd();
            builder.Property(p => p.Precio)
                   .HasColumnType("decimal(15,2)");
            builder.Property(p => p.Marca)
                   .HasMaxLength(25);
            builder.Property(p => p.Codigo)
                   .HasMaxLength(25);
        }

    }
}
