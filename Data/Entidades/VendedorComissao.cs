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

        [Column("VendedorId")]
        public int? VendedorId { get; set; }

        public Vendedor Vendedor { get; set; }

        [Column("GrupoId")]
        public int? CodigoGrupo { get; set; }

        public Grupo Grupo { get; set; }

        [Column("Comissao")]
        public double? Comissao { get; set; }
    }
}
