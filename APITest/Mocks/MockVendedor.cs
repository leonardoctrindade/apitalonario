using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockVendedor
    {
        public static Vendedor MontaObjetoUnico()
        {
            return new Vendedor
            {
                Id = 1,
                Nome = "Teste Mock 1",
                Genero = "M",
                Cep = "88308390",
                NumeroEndereco = "168486",
                Endereco = "Rua Alfredo Werner",
                Complemento = "Perto",
                IdBairro = 1,
                IdCidade = 1,
                IdEstado = 1,
                Ddd = "047",
                Telefone = "33465410",
                Celular = "988498793",
                Comissao = 123,
                CpfOuCnpj = "08082955958",
                DataNascimento = DateTime.Now,
                LimiteDesconto = 123,
                Email = "fragasandre@prismafive.com",
                IdUsuario = 1,
                Ativo = true,
                NomeAbreviado = "Teste 1",
                LoginVendedorFarmaciaPopular = "Fragax",
                SenhaVendedorFarmaciaPopular = "prixpto"
            };
        }

        public static Vendedor MontaObjetoNomeVazio()
        {

            return new Vendedor
            {
                Id = 1,
                Nome = null,
                Genero = "M",
                Cep = "88308390",
                NumeroEndereco = "168486",
                Endereco = "Rua Alfredo Werner",
                Complemento = "Perto",
                IdBairro = 1,
                IdCidade = 1,
                IdEstado = 1,
                Ddd = "047",
                Telefone = "33465410",
                Celular = "988498793",
                Comissao = 123,
                CpfOuCnpj = "08082955958",
                DataNascimento = DateTime.Now,
                LimiteDesconto = 123,
                Email = "fragasandre@prismafive.com",
                IdUsuario = 1,
                Ativo = true,
                NomeAbreviado = "Teste 1",
                LoginVendedorFarmaciaPopular = "Fragax",
                SenhaVendedorFarmaciaPopular = "prixpto"
            };
        }

        public static List<Vendedor> MontaListaItems()
        {
            return new List<Vendedor>()
            {
                new Vendedor() 
                { 
                    Id = 1,
                    Nome = "Teste Mock 1",
                    Genero = "M",
                    Cep = "88308390",
                    NumeroEndereco = "168486",
                    Endereco = "Rua Alfredo Werner",
                    Complemento = "Perto",
                    IdBairro = 1,
                    IdCidade = 1,
                    IdEstado = 1,
                    Ddd = "047",
                    Telefone = "33465410",
                    Celular = "988498793",
                    Comissao = 123,
                    CpfOuCnpj = "08082955958",
                    DataNascimento = DateTime.Now,
                    LimiteDesconto = 123,
                    Email = "fragasandre@prismafive.com",
                    IdUsuario = 1,
                    Ativo = true,
                    NomeAbreviado = "Teste 1",
                    LoginVendedorFarmaciaPopular = "Fragax",
                    SenhaVendedorFarmaciaPopular = "prixpto"
                },
                new Vendedor()
                {
                    Id = 2,
                    Nome = "Teste Mock 2",
                    Genero = "M",
                    Cep = "88308390",
                    NumeroEndereco = "168486",
                    Endereco = "Rua Alfredo Werner",
                    Complemento = "Perto",
                    IdBairro = 2,
                    IdCidade = 2,
                    IdEstado = 2,
                    Ddd = "047",
                    Telefone = "33465410",
                    Celular = "988498793",
                    Comissao = 123,
                    CpfOuCnpj = "08082955958",
                    DataNascimento = DateTime.Now,
                    LimiteDesconto = 123,
                    Email = "fragasandre@prismafive.com",
                    IdUsuario = 2,
                    Ativo = true,
                    NomeAbreviado = "Teste 2",
                    LoginVendedorFarmaciaPopular = "Fragax",
                    SenhaVendedorFarmaciaPopular = "prixpto"
                },
                new Vendedor()
                {
                    Id = 3,
                    Nome = "Teste Mock 3",
                    Genero = "M",
                    Cep = "88308390",
                    NumeroEndereco = "168486",
                    Endereco = "Rua Alfredo Werner",
                    Complemento = "Perto",
                    IdBairro = 3,
                    IdCidade = 3,
                    IdEstado = 3,
                    Ddd = "047",
                    Telefone = "33465410",
                    Celular = "988498793",
                    Comissao = 123,
                    CpfOuCnpj = "08082955958",
                    DataNascimento = DateTime.Now,
                    LimiteDesconto = 123,
                    Email = "fragasandre@prismafive.com",
                    IdUsuario = 3,
                    Ativo = true,
                    NomeAbreviado = "Teste 3",
                    LoginVendedorFarmaciaPopular = "Fragax",
                    SenhaVendedorFarmaciaPopular = "prixpto"
                }
            };
        }
    }
}
