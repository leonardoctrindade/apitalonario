using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class EntregadorRegiao
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("EntregadorId")]
        [Required(ErrorMessage = "Campo de EntregadorId não preenchido")]
        public int EntregadorId { get; set; }

        [Column("RegiaoId")]
        [Required(ErrorMessage = "Campo de RegiaoId não preenchido")]
        public int RegiaoId { get; set; }

        public Entregador Entregador { get; set; }

        public Regiao Regiao { get; set; }
    }
}
