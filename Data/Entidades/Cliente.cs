using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Cliente
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("ContribuinteIcms")]
        public bool ContribuinteIcms { get; set; }

        [Column("DataNascimento")]
        public DateTime? DataNascimento { get; set; }

        [Column("Nome")]
        [Required(ErrorMessage = "Campo de nome não preenchido")]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Column("Genero")]
        public Genero Genero { get; set; }

        [Column("ReterIss")]
        public bool ReterIss { get; set; }

        [Column("InscricaoMunicipal")]
        [MaxLength(20)]
        public string InscricaoMunicipal { get; set; }

        [Column("NomeRotulo")]
        [MaxLength(30)]
        public string NomeRotulo { get; set; }

        [Column("CpfCnpj")]
        [MaxLength(18)]
        public string CpfCnpj { get; set; }

        [Column("ReterRps")]
        public bool ReterRps { get; set; }

        [Column("InscricaoEstadual")]
        [MaxLength(20)]
        public string InscricaoEstadual { get; set; }

        [Column("Email")]
        [MaxLength(60)]
        public string Email { get; set; }

        [Column("Rg")]
        [MaxLength(50)]
        public string Rg { get; set; }

        [Column("OrgaoExpedidor")]
        [MaxLength(20)]
        public string OrgaoExpedidor { get; set; }

        [Column("EstadoOrgaoExpedidorId")]
        public int? EstadoOrgaoExpedidorId { get; set; }

        [Column("DddTelefone")]
        [MaxLength(4)]
        public string DddTelefone { get; set; }

        [Column("Telefone")]
        [MaxLength(20)]
        public string Telefone { get; set; }

        [Column("DddCelular")]
        [MaxLength(4)]
        public string DddCelular { get; set; }

        [Column("Celular")]
        [MaxLength(20)]
        public string Celular { get; set; }

        [Column("Whats")]
        [MaxLength(20)]
        public string Whats { get; set; }

        [Column("ConfirmaCpfCupom")]
        public bool ConfirmaCpfCupom { get; set; }

        [Column("DataExpedicao")]
        public DateTime? DataExpedicao { get; set; }

        [Column("Cep")]
        [MaxLength(8)]
        public string Cep { get; set; }

        [Column("Endereco")]
        [MaxLength(100)]
        public string Endereco { get; set; }

        [Column("Numero")]
        [MaxLength(7)]
        public string Numero { get; set; }

        [Column("Complemento")]
        [MaxLength(30)]
        public string Complemento { get; set; }

        [Column("Proximidade")]
        [MaxLength(500)]
        public string Proximidade { get; set; }

        [Column("TipoContatoId")]
        public int? TipoContatoId { get; set; }

        [Column("BairroId")]
        public int? BairroId { get; set; }

        [Column("CidadeId")]
        public int? CidadeId { get; set; }

        [Column("EstadoId")]
        public int? EstadoId { get; set; }

        [Column("NaoUsoContinuo")]
        public bool NaoUsoContinuo { get; set; }

        [Column("FidelidadeId")]
        public int? FidelidadeId { get; set; }

        [Column("CartaoFidelidade")]
        [MaxLength(20)]
        public string CartaoFidelidade { get; set; }

        [Column("CartaoFidelidadeAtivo")]
        public bool CartaoFidelidadeAtivo { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("TelefoneCopia")]
        [MaxLength(20)]
        public string TelefoneCopia { get; set; }

        [Column("CelularCopia")]
        [MaxLength(20)]
        public string CelularCopia { get; set; }

        [Column("PafCpfCnpj")]
        [MaxLength(96)]
        public string PafCpfCnpj { get; set; }

        [Column("PafCliente")]
        [MaxLength(96)]
        public string PafCliente { get; set; }

        [Column("NumeroDocumento")]
        [MaxLength(20)]
        public string NumeroDocumento { get; set; }

        [Column("CelularCompletoCliente")]
        [MaxLength(30)]
        public string CelularCompletoCliente { get; set; }

        [Column("DocumentoExterior")]
        [MaxLength(15)]
        public string DocumentoExterior { get; set; }

        [Column("PedirSenhaVendaLimite")]
        public int? PedirSenhaVendaLimite { get; set; }

        [Column("IntegracaoId")]
        public int? IntegracaoId { get; set; }

        [Column("ClienteParcelamento")]
        public bool ClienteParcelamento { get; set; }

        [Column("NovaMsgWhats")]
        public bool NovaMsgWhats { get; set; }

        [Column("ContatoWhatsInativo")]
        public bool ContatoWhatsInativo { get; set; }

        [Column("SyncNumberConflit")]
        public int? SyncNumberConflit { get; set; }
    }
}
