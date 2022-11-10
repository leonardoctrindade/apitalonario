using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    [Table("DOM_RegimeTributario")]
    public class DOM_RegimeTributario
    {
        [Column("idRegimeTributario")]
        public int Id { get; set; }

        [Column("RegimeTributario")]
        public string RegimeTributario { get; set; }
    }
}
