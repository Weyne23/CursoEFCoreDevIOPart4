using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }  
        public string Telefone { get; set; } 

        public Endereco Endereco { get; set; }
    }
}