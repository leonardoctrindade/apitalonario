using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class PlanoDeContas
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("NivelConta")]
        [Required]
        public int NivelConta { get; set; }
        [Column("NumeroConta")]
        [Required]
        public string NumeroConta { get; set; }
        [Column("NumeroContaPai")]
        [Required]
        public string NumeroContaPai { get; set; }
        [Column("Descricao")]
        [Required]
        public string Descricao { get; set; }
        [Column("Sequencia")]
        public double Sequencia { get; set; }
    }
}
