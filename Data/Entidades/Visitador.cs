using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Visitador
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [MaxLength(100)]
        [Required]
        public string Nome { get; set; }

        [Column("Cep")]
        [MaxLength(14)]
        public string Cep { get; set; }

        [Column("Endereco")]
        [MaxLength(60)]
        public string Endereco { get; set; }

        [Column("Numero")]
        [MaxLength(10)] 
        public string Numero { get; set; }

        [Column("Complemento")]
        [MaxLength(100)]
        public string Complemento { get; set; }

        [Column("BairroId")]
        public int? BairroId { get; set; }

        public Bairro Bairro { get; set; }

        [Column("CidadeId")]
        public int? CidadeId { get; set; }

        public Cidade Cidade { get; set; }

        [Column("EstadoId")]
        public int? EstadoId { get; set; }

        public Estado Estado { get; set; }

        [Column("DDD")]
        [MaxLength(2)]
        public string DDD { get; set; }

        [Column("Telefone")]
        [MaxLength(10)]
        public string Telefone { get; set; }

        [Column("Celular")]
        [MaxLength(10)]
        public string Celular { get; set; }

        [Column("Comissao")]
        public double? Comissao { get; set; }
    }
}
