using System;
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
            Esquema();
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

        static void PropagarDados()
        {
            using var db = new Curso.Data.ApplicationContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var script = db.Database.GenerateCreateScript();
            Console.WriteLine(script);
        }
    }
}
