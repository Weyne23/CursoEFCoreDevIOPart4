using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Domain
{
    public class Filme
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Ator> Atores { get; set; } = new List<Ator>();
    }
}