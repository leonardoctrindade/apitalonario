using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class FormaFarmaceuticaMargem
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("ValorInicial")]
        public double? ValorInicial { get; set; }

        [Column("ValorFinal")]
        public double? ValorFinal { get; set; }

        [Column("Margem")]
        [Required(ErrorMessage = "Campo de margem não preenchido")]
        public double Margem { get; set; }

        [Column("FormaFarmaceuticaId")]
        [Required(ErrorMessage = "Campo de FormaFarmaceuticaId não preenchido")]
        public int FormaFarmaceuticaId { get; set; } = 0;
    }
}
