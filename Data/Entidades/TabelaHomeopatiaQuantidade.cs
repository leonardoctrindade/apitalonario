using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class TabelaHomeopatiaQuantidade
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Metodo")]
        [MaxLength(12)]
        [Required(ErrorMessage = "Campo de metodo não preenchido")]
        public string Metodo { get; set; }

        [Column("FormaFarmaceuticaId")]
        public int? FormaFarmaceuticaId { get; set; }

        [Column("DinamizacaoInicial")]
        [Required(ErrorMessage = "Campo de dinamizacao inicial não preenchido")]
        public int DinamizacaoInicial { get; set; }

        [Column("DinamizacaoFinal")]
        [Required(ErrorMessage = "Campo de dinamizacao final não preenchido")]
        public int DinamizacaoFinal { get; set; }

        [Column("QuantidadeInicial")]
        [Required(ErrorMessage = "Campo de quantidade inicial não preenchido")]
        public int QuantidadeInicial { get; set; }

        [Column("QuantidadeFinal")]
        [Required(ErrorMessage = "Campo de quantidade final não preenchido")]
        public int QuantidadeFinal { get; set; }

        [Column("ValorVenda")]
        [Required(ErrorMessage = "Campo de valor de venda não preenchido")]
        public double ValorVenda { get; set; }

        [Column("ValorAdicional")]
        [Required(ErrorMessage = "Campo de valor adicional não preenchido")]
        public double ValorAdicional { get; set; }
    }
}
