using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Domain;
using Microsoft.EntityFrameworkCore;

namespace Curso.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConection = "Data source=(localdb)\\mssqllocaldb;Initial Catalog=DevIO-02;Integrated Security=true;pooling=true";
            optionsBuilder.UseSqlServer(strConection)//Seria as tentativas de refazer a query apos o erro, 1 parametro: Numero de tentativas, 2 parametro: Tempo da retentativa, 3 parametro: Array de Erros, passar null par usr padroes
            .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AI");//Troca as regras de busca do banco de dados de forma global
            //RAFAEL --> rafael -- Vai encontrar
            //João --> Joao -- Vai encontrar
            
            modelBuilder.Entity<Departamento>().Property(p => p.Descricao).UseCollation("SQL_Latin1_General_CP1_CS_AS");//Troca as regras de busca do banco de dados por entidade

            modelBuilder.HasSequence<int>("MinhaSequencia", "sequencias")
                .StartsAt(1)
                .IncrementsBy(2)
                .HasMin(1)
                .HasMax(10)
                .IsCyclic();
            
            modelBuilder.Entity<Departamento>().Property(p => p.Id).HasDefaultValueSql("NEXT VALUE FOR sequencias.MinhaSequencia");
        }
    }
}