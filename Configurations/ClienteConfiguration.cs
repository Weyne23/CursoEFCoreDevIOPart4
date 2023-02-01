using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
             builder.OwnsOne(x => x.Endereco, end => 
                {
                    end.Property(p => p.Bairro).HasColumnName("Bairro");//Ser somente para criar a coluna com o nome que queremos

                    end.ToTable("Endereco");//Aqui ele vai criar a tabela Endereço com as propriedades da classe endereco, sem essa linha ele cria todas as propriedades em cliente
                });//Ele pega a clase Endereço e cria ela dentro de cliente, sem precisar ter a tabela endereco em si
                // COMO FICOU A TABELA CLIENTE
                // [Id] int NOT NULL IDENTITY,
                // [Nome] nvarchar(max) NULL,
                // [Telefone] nvarchar(max) NULL,
                // [Endereco_Logradouro] nvarchar(max) NULL,
                // [Endereco_Bairro] nvarchar(max) NULL,
                // [Endereco_Cidade] nvarchar(max) NULL,
                // [Endereco_Estado] nvarchar(max) NULL,
                // CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
        }
    }
}