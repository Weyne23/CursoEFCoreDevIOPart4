using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.Configurations
{
    public class EstaodConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder
                .HasOne(g => g.Governador)
                .WithOne(p => p.Estado)
                .HasForeignKey<Governador>(p => p.EstadoReference);

            builder.Navigation(p => p.Governador).AutoInclude();//Faz o include automatico
        
            
            builder
                .HasMany(g => g.Cidades)
                .WithOne(e => e.Estado)
                .IsRequired(false);// Permite inserir Cidades sem precisar do estado
                //.OnDelete(DeleteBehavior.Restrict); // Troca a forma de exclusão
        }
    }
}