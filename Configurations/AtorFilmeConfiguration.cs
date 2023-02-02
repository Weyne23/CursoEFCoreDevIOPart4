using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.Configurations
{
    public class AtorFilmeConfiguration : IEntityTypeConfiguration<Ator>
    {
        public void Configure(EntityTypeBuilder<Ator> builder) 
        {
            // builder
            //     .HasMany(g => g.Filmes)
            //     .WithMany(p => p.Atores)
            //     .UsingEntity(P => P.ToTable("AtoresFilmes"));

            builder
                .HasMany(g => g.Filmes)
                .WithMany(p => p.Atores)
                .UsingEntity<Dictionary<string, object>>(
                    "FilmesAtores",
                    p => p.HasOne<Filme>().WithMany().HasForeignKey("FilmeId"),
                    p => p.HasOne<Ator>().WithMany().HasForeignKey("AtorId"),
                    p => 
                    {
                        p.Property<DateTime>("CadastradoEm").HasDefaultValueSql("GETDATE()");
                    }
                );
        }
    }
}