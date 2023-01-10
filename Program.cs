using System;

namespace DominandoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Collations();
        }

        static void Collations()
        {
            using var db = new Curso.Data.ApplicationContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
