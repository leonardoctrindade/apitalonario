using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class OperadorCaixa
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo de nome não preenchido")]
        public string Nome { get; set; }

        [Column("NomeAbreviado")]
        [MaxLength(20)]
        public string NomeAbreviado { get; set; }

        [Column("FilialId")]
        public int? FilialId { get; set; }   
    }
}
