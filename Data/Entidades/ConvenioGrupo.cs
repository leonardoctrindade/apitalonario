using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class ConvenioGrupo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("GrupoId")]
        [Required(ErrorMessage = "Campo de grupo não preenchido")]
        public int GrupoId { get; set; }

        [Column("Desconto")]
        [Required(ErrorMessage = "Campo de desconto não preenchido")]
        public double Desconto { get; set; }

        [Column("AplicaDescontoProduto")]
        public bool AplicaDescontoProduto { get; set; }

        [Column("AplicaCustoReferencia")]
        public bool AplicaCustoReferencia { get; set; }

        [Column("ConvenioId")]
        [Required(ErrorMessage = "Campo de IdConvenio não preenchido")]
        public int ConvenioId { get; set; }

        public Convenio Convenio { get; set; }
        public Grupo Grupo { get; set; }
    }
}
