using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Convenio
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo de nome não preenchido")]
        public string Nome { get; set; }

        [Column("Desconto")]
        public double Desconto { get; set; }

        [Column("Acrescimo")]
        public double Acrescimo { get; set; }

        [Column("Manifesto")]
        public double Manifesto { get; set; }

        [Column("DiaRecebimento")]
        public int DiaRecebimento { get; set; }

        [Column("Endereco")]
        [MaxLength(50)]
        public string Endereco { get; set; }

        [Column("Cep")]
        [MaxLength(8)]
        public string Cep { get; set; }

        [Column("Complemento")]
        [MaxLength(20)]
        public string Complemento { get; set; }

        [Column("NumeroEndereco")]
        [MaxLength(7)]
        public string NumeroEndereco { get; set; }

        [Column("BairroId")]
        public int BairroId { get; set; }

        [Column("CidadeId")]
        public int CidadeId { get; set; }

        [Column("EstadoId")]
        public int EstadoId { get; set; }

        [Column("IdentificaodrConvenio")]
        public IdentificadorConvenio IdentificadorConvenio { get; set; }

        [Column("Ddd")]
        [MaxLength(4)]
        public string Ddd { get; set; }

        [Column("Telefone")]
        [MaxLength(20)]
        public string Telefone { get; set; }

        [Column("CadastroFarmacia")]
        [MaxLength(20)]
        public string CadastroFarmacia { get; set; }

        [Column("CodigoPerdigao")]
        [MaxLength(6)]
        public string CodigoPerdigao { get; set; }

        [Column("Cnpj")]
        [MaxLength(14)]
        public string Cnpj { get; set; }

        [Column("DiasPrimeiroVencimento")]
        public int DiasPrimeiroVencimento { get; set; } = 30;

        [Column("Ie")]
        [MaxLength(20)]
        public string Ie { get; set; }

        [Column("Bloqueado")]
        public bool Bloqueado { get; set; }

        [Column("PermitirParcelamento")]
        public bool PermitirParcelamento { get; set; }

        [Column("EnviarEcommerce")]
        public bool EnviarEcommerce { get; set; }

        [Column("PermitirRateio")]
        public bool PermitirRateio { get; set; }

        [Column("VisitadorId")]
        public int VisitadorId { get; set; }

        [Column("EtiquetaId")]
        public int EtiquetaId { get; set; }

        [Column("EnderecoComprovanteVenda")]
        public bool EnderecoComprovanteVenda { get; set; }
    }

    public enum IdentificadorConvenio
    {
        Outros,
        Pertech,
        Tekla,
        Celos,
        Perdigao,
        Brandili
    }
}
