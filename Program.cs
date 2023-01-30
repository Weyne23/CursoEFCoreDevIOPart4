using System;
using System.Linq;
using Curso.Domain;
using Microsoft.EntityFrameworkCore;

namespace DominandoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Collations(); 
            //PropagarDados();
            //Esquema();
            //ConversorDeValores();
            //ConversorCustomizado();
            //PropriedadesDeSombra();
            TrabalhandoComPropriedadesDeSombra();
        }

        static void Collations()
        {
            using var db = new Curso.Data.ApplicationContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        static void Esquema()
        {
            using var db = new Curso.Data.ApplicationContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var script = db.Database.GenerateCreateScript();
            Console.WriteLine(script);
        }

        static void ConversorCustomizado()
        {
            using var db = new Curso.Data.ApplicationContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            db.Conversores.Add(
                new Conversor
                {
                    Status = Status.Devolvido,
                }
            );

            db.SaveChanges();

            var conversorEmAnalise = db.Conversores.AsNoTracking().FirstOrDefault(p => p.Status == Status.Analise);
            var conversorDevolvido = db.Conversores.AsNoTracking().FirstOrDefault(p => p.Status == Status.Devolvido);
        }


        static void PropagarDados()
        {
            using var db = new Curso.Data.ApplicationContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var script = db.Database.GenerateCreateScript();
            Console.WriteLine(script);
        }

        static void ConversorDeValores() => Esquema();

        static void PropriedadesDeSombra()
        {
            using var db = new Curso.Data.ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        static void TrabalhandoComPropriedadesDeSombra()
        {
            using var db = new Curso.Data.ApplicationContext();
            /*db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var departamento = new Departamento
            {
                Descricao = "Departamento propriedade de sombra"
            };
            
            db.Departamentos.Add(departamento);

            db.Entry(departamento).Property("UltimaAtualizacao").CurrentValue = DateTime.Now;

            db.SaveChanges();*/ //Inserindo valor na propriedade de sombra
        
            var departamento = db.Departamentos.Where(p => EF.Property<DateTime>(p, "UltimaAtualizacao") < DateTime.Now).ToArray();
        }
    }
}
