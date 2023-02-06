using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Domain
{
    public class Documento
    {
        private string _cpf;
        public int Id { get; set; }

        public void SetCPF(string cpf) 
        {
            if(string.IsNullOrWhiteSpace(cpf))
                throw new System.Exception("CPF Invalido");

            _cpf = cpf;
        }

        public string GetCPF() => _cpf;
    }
}