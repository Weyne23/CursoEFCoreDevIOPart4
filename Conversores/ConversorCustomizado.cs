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
        public ConversorCustomizado() : base(p => ConverterParaOBancoDeDados(p), value => ConverterParaAplicacao(value), new ConverterMappingHints(1))
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