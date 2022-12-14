using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class VendedorComissao
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("IdVendedor")]
        public int IdVendedor { get; set; }

        [Column("IdGrupo")]
        public int CodigoGrupo { get; set; }

        [Column("Comissao")]
        public double Comissao { get; set; }
    }
}
