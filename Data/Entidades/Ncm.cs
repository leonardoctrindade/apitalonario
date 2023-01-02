using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Ncm
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("ProdutoServico")]
        public bool ProdutoServico { get; set; }

        [Column("Descricao")]
        [Required(ErrorMessage = "Campo de descrição não preenchido")]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [Column("CodigoNcm")]
        [Required(ErrorMessage = "Campo de código de Ncm não preenchido")]
        [MaxLength(10)]
        public string CodigoNcm { get; set; }

        [Column("CodigoNcmEx")]
        public int? CodigoNcmEx { get; set; }

        [Column("PercentualMva")]
        public double? PercentualMva { get; set; }

        [Column("AliquotaNacional")]
        public double? AliquotaNacional { get; set; }

        [Column("AliquotaImportacao")]
        public double? AliquotaImportacao { get; set; }

        [Column("AliquotaCofins")]
        public double? AliquotaCofins { get; set; }

        [Column("AliquotaIcmsProduto")]
        public double? AliquotaIcmsProduto { get; set; }

        [Column("AliquotaPis")]
        public double? AliquotaPis { get; set; }

        [Column("TributoCstCofinsEntradaId")]
        public int? TributoCstCofinsEntradaId { get; set; }

        public Tributo TributoCstCofinsEntrada { get; set; }

        [Column("TributoCstCofinsSaidaId")]
        public int? TributoCstCofinsSaidaId { get; set; }

        public Tributo TributoCstCofinsSaida { get; set; }

        [Column("TributoCstPisEntradaId")]
        public int? TributoCstPisEntradaId { get; set; }

        public Tributo TributoCstPisEntrada { get; set; }

        [Column("TributoCstPisSaidaId")]
        public int? TributoCstPisSaidaId { get; set; }

        public Tributo TributoCstPisSaida { get; set; }

        public List<NcmEstado> NcmEstados { get; set; }
    }
}
