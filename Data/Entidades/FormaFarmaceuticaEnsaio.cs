using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class FormaFarmaceuticaEnsaio
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo de descricao não preenchido")]
        public string Descricao { get; set; }

        [Column("FormaFarmaceuticaId")]
        [Required(ErrorMessage = "Campo de FormaFarmaceuticaId não preenchido")]
        public int FormaFarmaceuticaId { get; set; }
    }
}
