using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Curso.Domain
{
    [Table("TabelaAtributos")]
    [Index(nameof(Descricao), nameof(Id), IsUnique = true)]
    [Comment("Meu comentario de minha tabela.")]
    public class Atributo
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Deixar que o banco de dados seja responsavel pela geração do valor
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]//Retira a geração automatica do valor, tendo que fazer de forma manual. (ps. Campo nao deixa de ser chave primaria)
        public int Id { get; set; }

        [Column("MinhaDescricao", TypeName = "VARCHAR(100)")]
        [Comment("Meu comentario para meu campo.")]
        public string Descricao { get; set; }

        //[Required]
        [MaxLength(255)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//Trasforma a propiedade em readonly
        public string Observacao { get; set; }
    }

    public class Aeroporto
    {
        public int Id { get; set; }
        public string Nome { get; set; } 
        [NotMapped]
        public string PropriedadeTeste { get; set; } 
        [InverseProperty("AeroportoPartida")]  
        public ICollection<Voo> VoosDePartida { get; set; }
        
        [InverseProperty("AeroportoChegada")]  
        public ICollection<Voo> VoosDeChegada { get; set; }
    }
    [NotMapped]
    public class Voo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Aeroporto AeroportoPartida { get; set; }
        public Aeroporto AeroportoChegada { get; set; }
    }
}