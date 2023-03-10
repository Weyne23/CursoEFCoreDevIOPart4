using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Domain
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Governador Governador { get; set; }
        public ICollection<Cidade> Cidades { get; } = new List<Cidade>();
    }
}