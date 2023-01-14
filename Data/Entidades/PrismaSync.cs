using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entidades
{
    public class PrismaSync
    {
        [Column("Id")]
        public int Id { get; set; }

        public string IntervaloOrcamentoDias { get; set; }
    }
}
