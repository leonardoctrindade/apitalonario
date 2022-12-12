using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class TabelaFloral
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Volume")]
        [Required(ErrorMessage = "Campo de volume não preenchido")]
        public int Volume { get; set; }

        [Column("QuantidadeInicial")]
        [Required(ErrorMessage = "Campo de quantidade inicial não preenchido")]
        public int QuantidadeInicial { get; set; }

        [Column("QuantidadeFinal")]
        [Required(ErrorMessage = "Campo de quantidade final não preenchido")]
        public int QuantidadeFinal { get; set; }

        [Column("ValorVenda")]
        [Required(ErrorMessage = "Campo de valor venda não preenchido")]
        public double ValorVenda { get; set; }
    }
}
