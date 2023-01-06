using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class AcompanhamentoPessoal
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Data")]
        [Required(ErrorMessage = "Campo de data não preenchido")]
        public DateTime? Data { get; set; }

        [Column("Peso")]
        [MaxLength(20)]
        public double Peso { get; set; }

        [Column("PressaoArterial")]
        [MaxLength(20)]
        public double PressaoArterial { get; set; }

        [Column("OutrasInformacoes")]
        public string OutrasInformacoes { get; set; }

        [Column("TipoSanguineo")]
        [MaxLength(10)]
        public string TipoSanguineo { get; set; }

        [Column("InformacoesLaboratoriais")]
        public string InformacoesLaboratoriais { get; set; }

        [Column("ClienteId")]
        [Required(ErrorMessage = "Campo de ClienteId não preenchido")]
        public int ClienteId { get; set; }
    }
}
