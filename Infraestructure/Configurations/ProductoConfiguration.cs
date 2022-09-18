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

            builder.HasData(
                new Producto { ProductoId = 1, Nombre = "Yerba Mate", Descripcion = "Yerba sin palos", Marca = "Amanda", Codigo = "cod001", Precio = 150, Image = "" },
                new Producto { ProductoId = 2, Nombre = "Cafe Molido", Descripcion = "Cafe en granos", Marca = "La virginia", Codigo = "cod002", Precio = 100, Image = "" },
                new Producto { ProductoId = 3, Nombre = "Cafe Molido", Descripcion = "Cafe en granos", Marca = "La virginia", Codigo = "cod002", Precio = 100, Image = "" },
                new Producto { ProductoId = 4, Nombre = "Cafe Molido", Descripcion = "Cafe en granos", Marca = "La virginia", Codigo = "cod002", Precio = 100, Image = "" },
                new Producto { ProductoId = 5, Nombre = "Cafe Molido", Descripcion = "Cafe en granos", Marca = "La virginia", Codigo = "cod002", Precio = 100, Image = "" },
                new Producto { ProductoId = 6, Nombre = "Cafe Molido", Descripcion = "Cafe en granos", Marca = "La virginia", Codigo = "cod002", Precio = 100, Image = "" },
                new Producto { ProductoId = 7, Nombre = "Cafe Molido", Descripcion = "Cafe en granos", Marca = "La virginia", Codigo = "cod002", Precio = 100, Image = "" },
                new Producto { ProductoId = 8, Nombre = "Cafe Molido", Descripcion = "Cafe en granos", Marca = "La virginia", Codigo = "cod002", Precio = 100, Image = "" },
                new Producto { ProductoId = 9, Nombre = "Cafe Molido", Descripcion = "Cafe en granos", Marca = "La virginia", Codigo = "cod002", Precio = 100, Image = "" },
                new Producto { ProductoId = 10, Nombre = "Cafe Molido", Descripcion = "Cafe en granos", Marca = "La virginia", Codigo = "cod002", Precio = 100, Image = "" }
                );
        }

    }
}
