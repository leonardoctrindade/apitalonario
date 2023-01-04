using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Entidades
{
    public class SetorForma
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("SetorId")]
        [Required(ErrorMessage = "Campo de SetorId não preenchido")]
        public int SetorId { get; set; }

        [Column("FormaId")]
        public int? FormaId { get; set; }
    }
}
