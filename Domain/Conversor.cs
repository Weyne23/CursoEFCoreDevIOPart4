using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Curso.Domain
{
    public class Conversor
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }
        public Versao Versao { get; set; }
        public IPAddress EnderecoIP { get; set; }
        
    }

    public enum Versao
    {
        EFCore1,
        EFCore2,
        EFCore3,
        EFCore5,
    }
}