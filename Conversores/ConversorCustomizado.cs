using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Domain;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Curso.Conversores
{
    public class ConversorCustomizado : ValueConverter<Status, string>
    {
        public ConversorCustomizado() : base(
            p => ConverterParaOBancoDeDados(p), //Converte Status (Enum) para dado de banco de dado(string)  
            value => ConverterParaAplicacao(value), //Converte o dado de banco de dado(string) para Status (Enum)
            new ConverterMappingHints(1)//Define o size do campo
        )
        {
            
        }

        static string ConverterParaOBancoDeDados(Status status)
        {
            return status.ToString()[0..1];
        }

        static Status ConverterParaAplicacao(string value)
        {
            var status = Enum
                .GetValues<Status>()
                .FirstOrDefault(x => x.ToString()[0..1] == value);

            return status;
        }
    }
}