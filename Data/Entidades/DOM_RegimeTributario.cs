using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
