using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Transportador
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("BairroId")]
        public int? BairroId { get; set; }

        [Column("CidadeId")]
        public int? CidadeId { get; set; }

        [Column("EstadoId")]
        public int? EstadoId { get; set; }

        [Column("EstadoPlacaId")]
        public int? EstadoPlacaId { get; set; }

        [Column("Nome")]
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Column("CpfCnpj")]
        [Required]
        public string CpfCnpj { get; set; }

        [Column("Ie")]
        public string Ie { get; set; }

        [Column("Cep")]
        public string Cep { get; set; }

        [Column("Endereco")]
        public string Endereco { get; set; }

        [Column("Numero")]
        public string Numero { get; set; }

        [Column("DDD")]
        public string DDD { get; set; }

        [Column("Telefone")]
        public string Telefone { get; set; }

        [Column("CodigoAntt")]
        public string CodigoAntt { get; set; }

        [Column("Placa")]
        public string Placa { get; set; }

        public Bairro Bairro { get; set; }
        public Cidade Cidade { get; set; }
        public Estado Estado { get; set; }
        public Estado EstadoPlaca { get; set; }
    }
}
