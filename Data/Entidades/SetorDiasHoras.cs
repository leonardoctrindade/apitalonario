using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class SetorDiasHoras
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("SetorId")]
        [Required(ErrorMessage = "Campo de SetorId não preenchido")]
        public int SetorId { get; set; }

        [Column("DiasHorasId")]
        [Required(ErrorMessage = "Campo de DiasHorasId não preenchido")]
        public int DiasHorasId { get; set; }
    }
}
