using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Entidades
{
    public class Farmacopeia
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Required]
        public string Nome { get; set; }

        [Column("Observação")]
        public string Observacao { get; set; }
    }
}
