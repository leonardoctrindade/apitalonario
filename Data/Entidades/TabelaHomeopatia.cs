using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Data.Entidades
{
    public class TabelaHomeopatia
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Metodo")]
        [MaxLength(12)]
        [Required(ErrorMessage = "Campo de metodo náo preenchido")]
        public string Metodo { get; set; }

        [Column("IdFormaFarmaceutica")]
        public int IdFormaFarmaceutica { get; set; }

        [Column("DinamizacaoInicial")]
        [Required(ErrorMessage = "Campo de dinamizacao inicial")]
        public int DinamizacaoInicial { get; set; }

        [Column("DinamizacaoFinal")]
        [Required(ErrorMessage = "Campo de dinamizacao final")]
        public int DinamizacaoFinal { get; set; }

        [Column("Volume")]
        [Required(ErrorMessage = "Campo de volume não preenchido")]
        public int Volume { get; set; }

        [Column("ValorVenda")]
        public double ValorVenda { get; set; }

        [Column("ValorAdicional")]
        public double ValorAdicional { get; set; }
    }
}
