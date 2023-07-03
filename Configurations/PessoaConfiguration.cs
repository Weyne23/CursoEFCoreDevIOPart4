
using Curso.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curso.Configurations
{
    public class PessoaConfiguration: IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder
                .ToTable("Pessoas")
                .HasDiscriminator<int>("TipoPessoa")
                .HasValue<Pessoa>(3)
                .HasValue<Instrutor>(6)
                .HasValue<Aluno>(99);
        }
    }
}