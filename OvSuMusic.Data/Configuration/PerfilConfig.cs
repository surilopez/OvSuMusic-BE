using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OvSuMusic.Models;

namespace OvSuMusic.Data.Configuration
{
    public class PerfilConfig : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> entity)
        {
            entity.ToTable("Perfil", "tienda");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        }
    }
}
