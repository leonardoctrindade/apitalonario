using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class PosAdquirente
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Column("ChaveRequisicao")]
        [Required(ErrorMessage = "Campo de Chave de Requisiçaõ não preenchido")]
        [MaxLength(100)]
        public string ChaveRequisicao { get; set; }
    }
}
