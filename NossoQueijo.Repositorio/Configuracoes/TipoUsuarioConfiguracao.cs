﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using NossoQueijo.Dominio.Entidades;

namespace NossoQueijo.Repositorio.Configuracoes
{
    class TipoUsuarioConfiguracao : IEntityTypeConfiguration<TipoUsuario>
    {
        public void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            builder.ToTable("TipoUsuario", "dbo");
            builder.HasKey("idTipoUsuario");
            builder.Property(i => i.Descricao)
                .HasMaxLength(150)
                .HasColumnName("Descricao");
        }
    }
}
