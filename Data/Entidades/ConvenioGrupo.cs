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

        [Column("IdGrupo")]
        [Required(ErrorMessage = "Campo de grupo não preenchido")]
        public int IdGrupo { get; set; }

        [Column("Desconto")]
        [Required(ErrorMessage = "Campo de desconto não preenchido")]
        public double Desconto { get; set; }

        [Column("AplicaDescontoProduto")]
        public bool AplicaDescontoProduto { get; set; }

        [Column("AplicaCustoReferencia")]
        public bool AplicaCustoReferencia { get; set; }

        [Column("IdConvenio")]
        [Required(ErrorMessage = "Campo de IdConvenio não preenchido")]
        public int IdConvenio { get; set; }
    }
}
