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
        [Column("IdPrescritor")]
        public int IdPrescritor { get; set; }
        [Column("IdEspecialidade")]
        public int IdEspecialidade { get; set; }
    }
}
