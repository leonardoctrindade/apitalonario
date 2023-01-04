using Npgsql.Internal.TypeHandlers.NumericHandlers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Grupo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [Required(ErrorMessage = "Campo de descrição não preenchido")]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [Column("Comissao")]
        [Required(ErrorMessage = "Campo de comissão não preenchido")]
        public double Comissao { get; set; } = 0.00000;

        [Column("PercentualDesconto")]
        [Required(ErrorMessage = "Campo percentual de desconto não preenchido")]
        public double PercentualDesconto { get; set; }

        [Column("Tipo")]
        [Required(ErrorMessage = "Campo de tipo não preenchido")]
        public TipoGrupo Tipo { get; set; }

        [Column("AtivaPesagemGrupo")]
        public bool AtivaPesagemGrupo { get; set; }

        [Column("DescontoMaximo")]
        public double? DescontoMaximo { get; set; }

        [Column("AtivaControleDeLotesAcabados")]
        public bool AtivaControleDeLotesAcabados { get; set; }

        [Column("FatorReferenciaGrupo")]
        public double? FatorReferenciaGrupo { get; set; }

        [Column("AtivaControleLotesDrogaria")]
        public bool AtivaControleLotesDrogaria { get; set; }

        [Column("CodigoGrupoLp")]
        [MaxLength(2)]
        public string CodigoGrupoLp { get; set; }

        public List<GrupoEnsaio> GrupoEnsaios { get; set; }
    }

    public enum TipoGrupo
    {
        MateriaPrima,
        SemiAcabado,
        Acabado,
        Embalagem,
        Capsula,
        Homeopatia,
        Floral
    }
}
