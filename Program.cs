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
            //TrabalhandoComPropriedadesDeSombra();
            //TiposDePropriedades();
            //Relacionamento1Para1();
            //Relacionamento1ParaMuitos();
            RelacionamentoMuitosParaMuitos();
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

        static void TiposDePropriedades()
        {
            using var db = new Curso.Data.ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var cliente = new Cliente
            {
                Nome = "Fulano de tal",
                Telefone = "(79) 98888-9999",
                Endereco = new Endereco { Bairro = "Centro", Cidade = "Sao Paulo" }
            };

            db.Clientes.Add(cliente);

            db.SaveChanges();

            var clientes = db.Clientes.AsNoTracking().ToList();

            var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };

            clientes.ForEach(cli =>
            {
                var json = System.Text.Json.JsonSerializer.Serialize(cli, options);

                Console.WriteLine(json);
            });
        }

        static void Relacionamento1Para1()
        {
            using var db = new Curso.Data.ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var estado = new Estado
            {
                Nome = "Sergipe",
                Governador = new Governador {Nome = "Rafael Almeida" }
            };

            db.Estados.Add(estado);

            db.SaveChanges();

            var estados = db.Estados.AsNoTracking().ToList();

            estados.ForEach(est =>
            {
                Console.WriteLine($"Estado: {est.Nome}, Governador: {est.Governador.Nome}");
            });
        }

        static void Relacionamento1ParaMuitos()
        {
            using (var db = new Curso.Data.ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var estado = new Estado
                {
                    Nome = "Sergipe",
                    Governador = new Governador {Nome = "Rafael Almeida" }
                };

                estado.Cidades.Add(new Cidade { Nome = "Itabaina" });
                db.Estados.Add(estado);

                db.SaveChanges();
            }
            
            using (var db = new Curso.Data.ApplicationContext())
            {
                var estados = db.Estados.ToList();

                estados[0].Cidades.Add(new Cidade { Nome = "Aracaju" });

                db.SaveChanges();

                foreach (var est in db.Estados.Include(p => p.Cidades).AsNoTracking())
                {
                    Console.WriteLine($"Estado: {est.Nome}, Governador: {est.Governador.Nome}");

                    foreach (var cidade in est.Cidades)
                    {
                        Console.WriteLine($"\t Cidade: {cidade.Nome}");
                    }
                }
            }
        }

        static void RelacionamentoMuitosParaMuitos()
        {
            using (var db = new Curso.Data.ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var ator1 = new Ator { Nome = "Rafael" };
                var ator2 = new Ator { Nome = "Pires" };
                var ator3 = new Ator { Nome = "Bruno" };

                var filme1 = new Filme { Descricao = "A volta dos que não foram" };
                var filme2 = new Filme { Descricao = "A volta para o futuro" };
                var filme3 = new Filme { Descricao = "Poeira em alto mar" };

                ator1.Filmes.Add(filme1);
                ator1.Filmes.Add(filme2);

                ator2.Filmes.Add(filme1);

                filme3.Atores.Add(ator1);
                filme3.Atores.Add(ator2);
                filme3.Atores.Add(ator3);

                db.AddRange(ator1, ator2, filme3);

                db.SaveChanges();

                foreach (var ator in db.Atores.Include(p => p.Filmes))
                {
                    Console.WriteLine($"Ator: {ator.Nome}");

                    foreach (var filme in ator.Filmes)
                    {
                        Console.WriteLine($"\tFilme: {filme.Descricao}");
                    }
                }
            }
        }
    }
}
