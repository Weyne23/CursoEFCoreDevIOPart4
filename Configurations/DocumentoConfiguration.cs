using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.Configurations
{
    public class DocumentoConfiguration: IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
             builder
                .Property("_cpf")//Esta mapiando um campo privado da minha classe
                .HasColumnName("CPF")
                .HasMaxLength(11);
                //.HasField("_cpf");
        }
    }
}