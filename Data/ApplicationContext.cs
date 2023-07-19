using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Curso.Configurations;
using Curso.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Curso.Data
{
    public class ApplicationContext : DbContext
    {
        // public DbSet<Departamento> Departamentos { get; set; }
        // public DbSet<Funcionario> Funcionarios { get; set; }
        // public DbSet<Estado> Estados { get; set; }
        // public DbSet<Conversor> Conversores { get; set; }
        // public DbSet<Cliente> Clientes { get; set; }
        // public DbSet<Governador> Governadores { get; set; }
        // public DbSet<Cidade> Cidades { get; set; }
        // public DbSet<Ator> Atores { get; set; }
        // public DbSet<Filme> Filmes { get; set; }
        // public DbSet<Documento> Documentos { get; set; }
        // public DbSet<Pessoa> Pessoas { get; set; }
        // public DbSet<Instrutor> Instrutores { get; set; }
        // public DbSet<Aluno> Alunos { get; set; }
        // public DbSet<Dictionary<string, object>> Configuracoes => Set<Dictionary<string, object>>("Configuracoes");
        // public DbSet<Atributo> Atributos { get; set; }
        //public DbSet<Aeroporto> Aeroportos { get; set; }
        public DbSet<Funcao> Funcaos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConection = "Data source=(localdb)\\mssqllocaldb;Initial Catalog=DevIO-02;Integrated Security=true;pooling=true";
            optionsBuilder.UseSqlServer(strConection)//Seria as tentativas de refazer a query apos o erro, 1 parametro: Numero de tentativas, 2 parametro: Tempo da retentativa, 3 parametro: Array de Erros, passar null par usr padroes
            .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AI");//Troca as regras de busca do banco de dados de forma global
            // //RAFAEL --> rafael -- Vai encontrar
            // //João --> Joao -- Vai encontrar
            
            // modelBuilder.Entity<Departamento>().Property(p => p.Descricao).UseCollation("SQL_Latin1_General_CP1_CS_AS");//Troca as regras de busca do banco de dados por entidade

            // modelBuilder.HasSequence<int>("MinhaSequencia", "sequencias")
            //     .StartsAt(1)
            //     .IncrementsBy(2)
            //     .HasMin(1)
            //     .HasMax(10)
            //     .IsCyclic();
            
            // modelBuilder.Entity<Departamento>().Property(p => p.Id).HasDefaultValueSql("NEXT VALUE FOR sequencias.MinhaSequencia");

            // modelBuilder
            //     .Entity<Departamento>()
            //     .HasIndex(p => new { p.Descricao, p.Ativo })//Indices Composto
            //     .HasDatabaseName("idx_meu_indice_composto")//Dar um nome ao indice
            //     .HasFilter("Descricao IS NOT NULL")//Filtrar os campos
            //     .HasFillFactor(80)
            //     .IsUnique();//Para criar ele unico

            // modelBuilder.Entity<Estado>()
            //     .HasData(new []
            //         {
            //             new Estado{Id = 1, Nome = "São Paulo"},
            //             new Estado{Id = 2, Nome = "Sergipe"}
            //         }
            //     );

            // modelBuilder.HasDefaultSchema("cadastros"); //Criacao de Schemas

            // modelBuilder.Entity<Estado>().ToTable("Estados", "SegundoEsquema");
            // var conversao = new ValueConverter<Versao, string>(p => p.ToString(), p => (Versao)Enum.Parse(typeof(Versao), p));
            
            // var conversao1 = new EnumToStringConverter<Versao>();

            // modelBuilder.Entity<Conversor>()
            // .Property(p => p.Versao)
            // .HasConversion(conversao1);
            // //.HasConversion(conversao);
            // //.HasConversion(p => p.ToString(), p => (Versao)Enum.Parse(typeof(Versao), p));
            // //.HasConversion<string>();

            // modelBuilder.Entity<Conversor>()
            // .Property(p => p.Status)
            // .HasConversion(new Curso.Conversores.ConversorCustomizado());
        
            // modelBuilder.Entity<Departamento>()
            //     .Property<DateTime>("UltimaAtualizacao"); //Criando propriedade de sombra

            // modelBuilder.Entity<Cliente>(p => 
            // {
            //     p.OwnsOne(x => x.Endereco, end => 
            //     {
            //         end.Property(p => p.Bairro).HasColumnName("Bairro");//Ser somente para criar a coluna com o nome que queremos

            //         end.ToTable("Endereco");//Aqui ele vai criar a tabela Endereço com as propriedades da classe endereco, sem essa linha ele cria todas as propriedades em cliente
            //     });//Ele pega a clase Endereço e cria ela dentro de cliente, sem precisar ter a tabela endereco em si
            //     // COMO FICOU A TABELA CLIENTE
            //     // [Id] int NOT NULL IDENTITY,
            //     // [Nome] nvarchar(max) NULL,
            //     // [Telefone] nvarchar(max) NULL,
            //     // [Endereco_Logradouro] nvarchar(max) NULL,
            //     // [Endereco_Bairro] nvarchar(max) NULL,
            //     // [Endereco_Cidade] nvarchar(max) NULL,
            //     // [Endereco_Estado] nvarchar(max) NULL,
            //     // CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
            // });

            //modelBuilder.ApplyConfiguration(new ClienteConfiguration()); // Uma das formas de aplicar o configuration
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            // modelBuilder.SharedTypeEntity<Dictionary<string, object>>("Configuracoes", b => 
            // {
            //     b.Property<int>("Id");

            //     b.Property<string>("Chave")
            //         .HasColumnType("VARCHAR(40)")
            //         .IsRequired();

            //     b.Property<string>("Valor")
            //         .HasColumnType("VARCHAR(255)")
            //         .IsRequired();
            // });
        }
    }
}