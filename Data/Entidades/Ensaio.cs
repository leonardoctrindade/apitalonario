using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Ensaio
    { 
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Required(ErrorMessage = "Campo de nome não preenchido")]
        public string Nome { get; set; }

        [Column("FarmacopeiaId")]
        public int? FarmacopeiaId { get; set; }

        public Farmacopeia Farmacopeia { get; set; }
    }
}
