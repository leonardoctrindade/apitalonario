using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class MaquinaPos
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Column("SerialPos")]
        [MaxLength(50)]
        [Required]
        public string SerialPos { get; set; }

        [Column("AdquirentePosId")]
        public int AdquirentePosId { get; set; }

        public PosAdquirente AdquirentePos { get; set; }
    }
}
