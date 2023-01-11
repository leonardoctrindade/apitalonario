using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Column("FormaFarmaceuticaId")]
        public int? FormaFarmaceuticaId { get; set; }
    }
}
