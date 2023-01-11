using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class IntervaloDinamizacaoHomeopatia
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Inicial")]
        [Required(ErrorMessage = "Campo de dinamização inicial não preenchido")]
        public int Inicial { get; set; }

        [Column("Final")]
        [Required(ErrorMessage = "Campo de dinamização final não preenchido")]
        public int Final { get; set; }

        [Column("TabelaHomeopatiaId")]
        [Required(ErrorMessage = "Campo de TabelaHomeopatiaId não preenchido")]
        public int TabelaHomeopatiaId { get; set; }
    }
}
