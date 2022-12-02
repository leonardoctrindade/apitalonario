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

        [Column("Nome")]
        [MaxLength(50)]
        [Required]
        public string Nome { get; set; }

        [Column("CpfOuCnpj")]
        [MaxLength(20)]
        [Required]
        public string CpfOuCnpj { get; set; }

        [Column("Ie")]
        [MaxLength(20)]
        public string Ie { get; set; }

        [Column("Cep")]
        [MaxLength(8)]
        public string Cep { get; set; }

        [Column("Endereco")]
        [MaxLength(50)]
        public string Endereco { get; set; }

        [Column("Numero")]
        [MaxLength(10)]
        public string Numero { get; set; }

        [Column("IdBairro")]
        public int IdBairro { get; set; }

        [Column("IdCidade")]
        public int IdCidade { get; set; }

        [Column("IdEstado")]
        public int IdEstado { get; set; }

        [Column("DddTelefone")]
        [MaxLength(5)]
        public string DddTelefone { get; set; }

        [Column("Telefone")]
        [MaxLength(10)]
        public string Telefone { get; set; }

        [Column("CodigoAntt")]
        [MaxLength(20)]
        public string CodigoAntt { get; set; }

        [Column("PlacaVeiculo")]
        [MaxLength(20)]
        public string PlacaVeiculo { get; set; }

        [Column("IdEstadoPlaca")]
        public int IdEstadoPlaca { get; set; }
    }
}
