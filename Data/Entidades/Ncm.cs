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
        public int CodigoNcmEx { get; set; }

        [Column("PercentualMva")]
        public double PercentualMva { get; set; }

        [Column("AliquotaNacional")]
        public double AliquotaNacional { get; set; }

        [Column("AliquotaImportacao")]
        public double AliquotaImportacao { get; set; }

        [Column("AliquotaCofins")]
        public double AliquotaCofins { get; set; }

        [Column("AliquotaIcmsProduto")]
        public double AliquotaIcmsProduto { get; set; }

        [Column("AliquotaPis")]
        public double AliquotaPis { get; set; }

        [Column("IdTributoCstCofinsEntrada")]
        public int IdTributoCstCofinsEntrada { get; set; }

        [Column("IdTributoCstCofinsSaida")]
        public int IdTributoCstCofinsSaida { get; set; }

        [Column("IdTributoCstPisEntrada")]
        public int IdTributoCstPisEntrada { get; set; }

        [Column("IdTributoCstPisSaida")]
        public int IdTributoCstPisSaida { get; set; }
    }
}
