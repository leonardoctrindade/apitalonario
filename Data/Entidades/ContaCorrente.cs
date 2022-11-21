using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entidades
{
    public class ContaCorrente
    {
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [Column("NumeroConta")]
        [MaxLength(15)]
        public string NumeroConta { get; set; }
        [Required]
        [Column("Nome")]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Column("Limite")]
        [MinLength(0)]
        public double Limite { get; set; }
    }
}
