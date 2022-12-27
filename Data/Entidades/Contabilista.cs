using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Contabilista
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("BairroId")]
        public int BairroId { get; set; }

        [Column("CidadeId")]
        public int CidadeId { get; set; }

        [Column("EstadoId")]
        public int EstadoId { get; set; }

        [Column("Nome")]
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Column("Cnpj")]
        [Required]
        [MaxLength(14)]
        public string Cnpj { get; set; }

        [Column("Cpf")]
        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Column("Crc")]
        [Required]
        [MaxLength(15)]
        public string Crc { get; set; }

        [Column("Endereco")]
        public string Endereco { get; set; }

        [Column("Numero")]
        public string Numero { get; set; }

        [Column("Complemento")]
        public string Complemento { get; set; }

        [Column("Cep")]
        public string Cep { get; set; }

        [Column("Telefone")]
        public string Telefone { get; set; }

        [Column("Fax")]
        public string Fax { get; set; }

        [Column("Email")]
        public string Email { get; set; }
    }
}
