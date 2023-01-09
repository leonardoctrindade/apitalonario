using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class NfeExpedicaoCliente
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("EstadoEmbarqueId")]
        public int EstadoEmbarqueId { get; set; }

        [Column("LocalEmbarque")]
        [MaxLength(50)]
        public string LocalEmbarque { get; set; }

        [Column("RegimeTributacao")]
        public TipoRegimeTributacao RegimeTributacao { get; set; }

        [Column("ClienteId")]
        [Required(ErrorMessage = "Campo de ClienteId não preenchido")]
        public int ClienteId { get; set; }
    }

    public enum TipoRegimeTributacao
    {
        SimplesNacional,
        SimplesNacionalSubLimite,
        RegimeNormal
    }
}
