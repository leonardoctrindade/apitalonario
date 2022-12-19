using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public  class AliquotaEstado
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("IdEstadoOrigem")]
        public int IdEstadoOrigem { get; set; }

        [Column("IdEstadoDestino")]
        public int IdEstadoDestino { get; set; }

        [Column("AliquotaIcms")]
        public double AliquotaIcms { get; set; }
    }
}
