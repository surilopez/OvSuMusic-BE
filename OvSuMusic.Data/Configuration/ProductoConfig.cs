using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OvSuMusic.Models;

namespace OvSuMusic.Data.Configuration
{
    public class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> entity)
        {
            entity.ToTable("Producto", "tienda");

            entity.Property(e => e.Nombre).HasMaxLength(256);

            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        }
    }
}
