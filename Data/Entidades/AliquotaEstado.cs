﻿using System;
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

        [Column("EstadoOrigemId")]
        public int? EstadoOrigemId { get; set; }

        public Estado EstadoOrigem { get; set; }

        [Column("EstadoDestinoId")]
        public int? EstadoDestinoId { get; set; }

        public Estado EstadoDestino { get; set; }

        [Column("AliquotaIcms")]
        public double AliquotaIcms { get; set; }
    }
}
