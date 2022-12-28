using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Vendedor
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo de nome não preenchido")]
        public string Nome { get; set; }

        [Column("Genero")]
        [MaxLength(1)]
        public string Genero { get; set; }

        [Column("Cep")]
        [MaxLength(8)]
        public string Cep { get; set; }

        [Column("NumeroEndereco")]
        [MaxLength(7)]
        public string NumeroEndereco { get; set; }

        [Column("Endereco")]
        [MaxLength(50)]
        public string Endereco { get; set; }

        [Column("Complemento")]
        [MaxLength(20)]
        public string Complemento { get; set; }

        [Column("BairroId")]
        public int BairroId { get; set; }

        [Column("CidadeId")]
        public int CidadeId { get; set; }

        [Column("EstadoId")]
        public int EstadoId { get; set; }

        [Column("Ddd")]
        [MaxLength(4)]
        public string Ddd { get; set; }

        [Column("Telefone")]
        [MaxLength(20)]
        public string Telefone { get; set; }

        [Column("Celular")]
        [MaxLength(20)]
        public string Celular { get; set; }

        [Column("Comissao")]
        public double Comissao { get; set; }

        [Column("CpfOuCnpj")]
        [MaxLength(18)]
        public string CpfOuCnpj { get; set; }

        [Column("DataNascimento")]
        public DateTime DataNascimento { get; set; }

        [Column("LimiteDesconto")]
        public double LimiteDesconto { get; set; }

        [Column("Email")]
        [MaxLength(255)]
        public string Email { get; set; }

        [Column("UsuarioId")]
        [Required(ErrorMessage = "Campo de Usuario não preenchido")]
        public int UsuarioId { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("NomeAbreviado")]
        [MaxLength(20)]
        public string NomeAbreviado { get; set; }

        [Column("LoginVendedorFarmaciaPopular")]
        [MaxLength(15)]
        public string LoginVendedorFarmaciaPopular { get; set; }

        [Column("SenhaVendedorFarmaciaPopular")]
        [MaxLength(15)]
        public string SenhaVendedorFarmaciaPopular { get; set; }

        public Bairro Bairro { get; set; }
        public Cidade Cidade { get; set; }
        public Estado Estado { get; set; }
        public Usuario Usuario { get; set; }
    }
}
