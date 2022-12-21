using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class FidelidadeFormaPagamento
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("CodigoFidelidade")]
        [Required(ErrorMessage = "Codigo de fifelidade não informado")]
        public int CodigoFidelidade { get; set; }

        [Column("CodigoFormaPagamento")]
        [Required(ErrorMessage = "Codigo de forma de pagamento não informado")]
        public int CodigoFormaPagamento { get; set; }

        [Column("Valor")]
        [Required(ErrorMessage = "Campo de valor não preenchido")]
        public double Valor { get; set; }

        [Column("Pontos")]
        [Required(ErrorMessage = "Campo de pontos não preenchido")]
        public int Pontos { get; set; }
    }
}
