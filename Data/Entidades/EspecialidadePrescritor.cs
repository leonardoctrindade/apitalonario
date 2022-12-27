using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class EspecialidadePrescritor
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("PrescritorId")]
        public int? PrescritorId { get; set; }

        [Column("EspecialidadeId")]
        public int? EspecialidadeId { get; set; }

        public Prescritor Prescritor { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}
