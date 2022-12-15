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

        [Column("NumeroConta")]
        [Required(ErrorMessage = "Campo de número da conta não preenchido")]
        [MaxLength(15)]
        public string NumeroConta { get; set; }

        [Column("Nome")]
        [Required(ErrorMessage = "Campo de nome não preenchido")]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Column("Limite")]
        [MinLength(0)]
        public double Limite { get; set; }

        [Column("IdFilial")]
        public int IdFilial { get; set; }
    }
}
