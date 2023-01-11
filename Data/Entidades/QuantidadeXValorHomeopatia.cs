using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class QuantidadeXValorHomeopatia
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("QuantidadeInicial")]
        [Required(ErrorMessage = "Campo de QuantidadeIncial não preenchido")]
        public int QuantidadeInicial { get; set; }

        [Column("QuantidadeFinal")]
        [Required(ErrorMessage = "Campo de QuantidadeFinal não preenchido")]
        public int QuantidadeFinal { get; set; }

        [Column("ValorVenda")]
        [Required(ErrorMessage = "Campo de ValorVenda não preenchido")]
        public double ValorVenda { get; set; }

        [Column("ValorAdicional")]
        [Required(ErrorMessage = "Campo de ValorAdicional não preenchido")]
        public double ValorAdicional { get; set; }

        [Column("IntervaloDinamizacaoId")]
        [Required(ErrorMessage = "Campo de IntervaloDinamizacaoId")]
        public int IntervaloDinamizacaoId { get; set; }
    }
}
