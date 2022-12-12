using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class MensagensPadrao
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("StatusDescricao")]
        [MaxLength(30)]
        public string StatusDescricao { get; set; }

        [Column("Mensagem")]
        public string Mensagem { get; set; }

        [Column("EnviarAutomatico")]
        public bool EnviarAutomatico { get; set; }

        [Column("DescricaoRotulo")]
        public bool DescricaoRotulo { get; set; }
    }
}
