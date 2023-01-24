using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Fornecedor
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("NomeFornecedor")]
        [Required(ErrorMessage = "Campo de nome não preenchido")]
        [MaxLength(50)]
        public string NomeFornecedor { get; set; }

        [Column("NomeFantasia")]
        [Required(ErrorMessage = "Campo de nome fantasia não preenchido")]
        [MaxLength(50)]
        public string NomeFantasia { get; set; }

        [Column("Cnpj")]
        [Required(ErrorMessage = "Campo de cnpj não preenchido")]
        [MaxLength(14)]
        public string Cnpj { get; set; }

        [Column("Cpf")]
        [Required(ErrorMessage = "Campo de cpf não preenchido")]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Column("InscricaoEstadual")]
        [Required(ErrorMessage = "Campo de inscricao estadual não preenchido")]
        [MaxLength(20)]
        public string InscricaoEstadual { get; set; }

        [Column("Cep")]
        [MaxLength(8)]
        public string Cep { get; set; }

        [Column("Endereco")]
        [MaxLength(50)]
        public string Endereco { get; set; }

        [Column("NumeroEndereco")]
        [MaxLength(7)]
        public string NumeroEndereco { get; set; }

        [Column("Complemento")]
        [MaxLength(20)]
        public string Complemento { get; set; }

        [Column("BairroId")]
        public int? BairroId { get; set; }

        public Bairro Bairro { get; set; }

        [Column("CidadeId")]
        public int? CidadeId { get; set; }

        public Cidade Cidade { get; set; }

        [Column("EstadoId")]
        [Required(ErrorMessage = "Campo de estado não preenchido")]
        public int? EstadoId { get; set; } = 0;

        public Estado Estado { get; set; }

        [Column("Ddd")]
        [MaxLength(4)]
        public string Ddd { get; set; }

        [Column("Telefone")]
        [MaxLength(20)]
        public string Telefone { get; set; }

        [Column("Celular")]
        [MaxLength(20)]
        public string Celular { get; set; }

        [Column("Email")]
        [MaxLength(60)]
        public string Email { get; set; }

        [Column("HomePage")]
        [MaxLength(60)]
        public string HomePage { get; set; }

        [Column("Contato")]
        [MaxLength(50)]
        public string Contato { get; set; }

        [Column("TelefoneContato")]
        [MaxLength(20)]
        public string TelefoneContato { get; set; }

        [Column("BancoId")]
        public int? BancoId { get; set; }

        public Banco Banco { get; set; }

        [Column("Agencia")]
        [MaxLength(6)]
        public string Agencia { get; set; }

        [Column("ContaCorrenteFornecedor")]
        [MaxLength(15)]
        public string ContaCorrenteFornecedor { get; set; }

        [Column("ResponsavelTecnico")]
        [MaxLength(50)]
        public string ResponsavelTecnico { get; set; }

        [Column("AlvaraSanitario")]
        [MaxLength(10)]
        public string AlvaraSanitario { get; set; }

        [Column("AutorizacaoFuncionamento")]
        [MaxLength(10)]
        public string AutorizacaoFuncionamento { get; set; }

        [Column("AutorizacaoEspecial")]
        [MaxLength(10)]
        public string AutorizacaoEspecial { get; set; }

        [Column("LicencaMapa")]
        [MaxLength(50)]
        public string LicencaMapa { get; set; }

        [Column("CadastroFarmacia")]
        [MaxLength(10)]
        public string CadastroFarmacia { get; set; }

        [Column("PlanoDeContaId")]
        public int? PlanoDeContaId { get; set; }

        public PlanoDeContas PlanoDeConta { get; set; }

        [Column("ValorMinimoPedido")]
        public decimal? ValorMinimoPedido { get; set; }

        [Column("FormaPagamento")]
        [MaxLength(100)]
        public string FormaPagamento { get; set; }

        [Column("PrevisaoEntrega")]
        public int? PrevisaoEntrega { get; set; }

        [Column("Frete")]
        [MaxLength(100)]
        public string Frete { get; set; }

        [Column("Observacoes")]
        [MaxLength(100)]
        public string Observacoes { get; set; }

        [Column("UsuarioFornecedor")]
        [MaxLength(15)]
        public string UsuarioFornecedor { get; set; }

        [Column("SenhaFornecedor")]
        [MaxLength(15)]
        public string SenhaFornecedor { get; set; }

        [Column("HostFornecedor")]
        [MaxLength(50)]
        public string HostFornecedor { get; set; }
    }
}
