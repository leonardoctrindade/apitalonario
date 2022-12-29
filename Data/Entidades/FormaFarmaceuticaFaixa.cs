using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class FormaFarmaceuticaFaixa
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("QuantidadeInicial")]
        public double QuantidadeInicial { get; set; }

        [Column("QuantidadeFinal")]
        public double QuantidadeFinal { get; set; }

        [Column("ValorMinimo")]
        public double ValorMinimo { get; set; }

        [Column("SiglaUnidadeFaixa")]
        public string SiglaUnidadeFaixa { get; set; }

        [Column("FormaFarmaceuticaId")]
        [Required(ErrorMessage = "Campo de FormaFarmaceuticaId não preenchido")]
        public int? FormaFarmaceuticaId { get; set; } = 0;

        public FormaFarmaceutica FormaFarmaceutica { get; set; }
    }
}
