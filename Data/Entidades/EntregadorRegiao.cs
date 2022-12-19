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

        [Column("IdEntregador")]
        [Required(ErrorMessage = "Campo de IdEntregador não preenchido")]
        public int IdEntregador { get; set; }

        [Column("IdRegiao")]
        [Required(ErrorMessage = "Campo de IdRegiao não preenchido")]
        public int IdRegiao { get; set; }
    }
}
