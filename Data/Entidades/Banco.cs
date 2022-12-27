using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class Banco
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("NomeBanco")]
        [MaxLength(50)]
        [Required]
        public string Nome { get; set; }

        [Column("CodigoBanco")]
        [MaxLength(3)]
        [Required]
        public string CodigoBanco { get; set; }

        [Column("Carteira")]
        [MaxLength(10)]
        public string Carteira { get; set; }

        [Column("Modalidade")]
        [MaxLength(5)]
        public string Modalidade { get; set; }

        [Column("FormaCobranca")]
        [MaxLength(1)]
        public string FormaCobranca { get; set; }

        [Column("Layout")]
        [MaxLength(5)]
        public string Layout { get; set; }

        [Column("SequenciaRemessa")]
        public int? SequenciaRemessa { get; set; }

        [Column("NomeCedente")]
        [MaxLength(70)]
        public string NomeCedente { get; set; }

        [Column("CnpjCedente")]
        [MaxLength(14)]
        public string CnpjCedente { get; set; }

        [Column("CodigoCedente")]
        [MaxLength(20)]
        public string CodigoCedente { get; set; }

        [Column("CodigoTransmissao")]
        [MaxLength(20)]
        public string CodigoTransmissao { get; set; }

        [Column("ComplementoTransmissao")]
        [MaxLength(10)]
        public string ComplementoTransmissao { get; set; }

        [Column("Agencia")]
        [MaxLength(4)]
        public string Agencia { get; set; }

        [Column("AgenciaDigito")]
        [MaxLength(1)]
        public string AgenciaDigito { get; set; }

        [Column("DiasProtesto")]
        public int? DiasProtesto { get; set; }

        [Column("Juros")]
        public decimal Juros { get; set; }

        [Column("Multa")]
        public decimal Multa { get; set; }

        [Column("ContaCorrente")]
        [MaxLength(20)]
        public string ContaCorrente { get; set; }

        [Column("ContaCorrenteDigito")]
        [MaxLength(1)]
        public string ContaCorrenteDigito { get; set; }

        [Column("Convenio")]
        [MaxLength(10)]
        public string Convenio { get; set; }

        [Column("Producao")]
        public bool Producao { get; set; }

        [Column("LocalPagamento")]
        [MaxLength(70)]
        public string LocalPagamento { get; set; }

        [Column("MensagemInstrucao1")]
        [MaxLength(70)]
        public string MensagemInstrucao1 { get; set; }

        [Column("MensagemInstrucao2")]
        [MaxLength(70)]
        public string MensagemInstrucao2 { get; set; }

        [Column("MensagemInstrucao3")]
        [MaxLength(70)]
        public string MensagemInstrucao3 { get; set; }

        [Column("MensagemInstrucao4")]
        [MaxLength(70)]
        public string MensagemInstrucao4 { get; set; }

        [Column("MensagemInstrucao5")]
        [MaxLength(70)]
        public string MensagemInstrucao5 { get; set; }
    }
}
