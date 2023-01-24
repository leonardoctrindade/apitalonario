using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Parametro
    {
        public Farmacia Farmacia { get; set; }
        public Impressao Impressao { get; set; }
    }
}
