using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class VolumeXValorHomeopatia
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Volume")]
        [Required(ErrorMessage = "Campo de volume não preenchido")]
        public int Volume { get; set; }

        [Column("ValorVenda")]
        [Required(ErrorMessage = "Campo de valor venda não preenchido")]
        public double ValorVenda { get; set; }

        [Column("ValorAdicional")]
        [Required(ErrorMessage = "Campo de valor adicional não preenchido")]
        public double ValorAdicional { get; set; }

        [Column("IntervaloDinamizacaoId")]
        [Required(ErrorMessage = "Campo de IntervaloDinamizacaoId não preenchido")]
        public int IntervaloDinamizacaoId { get; set; }
    }
}
