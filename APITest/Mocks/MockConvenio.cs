using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockConvenio
    {
        public static Convenio MontaObjetoUnico()
        {
            return new Convenio
            {
                Id = 1,
                Nome = "Teste Mock 1",
                Desconto = 20,
                Acrescimo = 20,
                Manifesto = 20,
                DiaRecebimento = 15,
                Endereco = "Teste Mock 1",
                Cep = "12345678",
                Complemento = "Teste Mock 1",
                NumeroEndereco = "NumeroEndereco",
                IdBairro = 1,
                IdCidade = 1,
                IdEstado = 1,
                IdentificadorConvenio = IdentificadorConvenio.Celos,
                Ddd = "047",
                Telefone = "047988498793",
                CadastroFarmacia = "Teste Mock 1",
                CodigoPerdigao = "Teste",
                Cnpj = "Teste Mock 1",
                DiasPrimeiroVencimento = 20,
                Ie = "Teste Mock 1",
                Bloqueado = true,
                PermitirParcelamento = true,
                EnviarEcommerce = true,
                PermitirRateio = true,
                IdVisitador = 1,
                IdEtiqueta = 1,
                EnderecoComprovanteVenda = true,
            };
        }

        public static Convenio MontaObjetoNomeVazio()
        {
            return new Convenio
            {
                Id = 1,
                Nome = null,
                Desconto = 20,
                Acrescimo = 20,
                Manifesto = 20,
                DiaRecebimento = 15,
                Endereco = "Teste Mock 1",
                Cep = "12345678",
                Complemento = "Teste Mock 1",
                NumeroEndereco = "NumeroEndereco",
                IdBairro = 1,
                IdCidade = 1,
                IdEstado = 1,
                IdentificadorConvenio = IdentificadorConvenio.Celos,
                Ddd = "047",
                Telefone = "047988498793",
                CadastroFarmacia = "Teste Mock 1",
                CodigoPerdigao = "Teste",
                Cnpj = "Teste Mock 1",
                DiasPrimeiroVencimento = 20,
                Ie = "Teste Mock 1",
                Bloqueado = true,
                PermitirParcelamento = true,
                EnviarEcommerce = true,
                PermitirRateio = true,
                IdVisitador = 1,
                IdEtiqueta = 1,
                EnderecoComprovanteVenda = true,
            };
        }

        public static List<Convenio> MontaListaItems()
        {
            return new List<Convenio>()
            {
                new Convenio()
                {
                    Id = 1,
                    Nome = "Teste Mock 1",
                    Desconto = 20,
                    Acrescimo = 20,
                    Manifesto = 20,
                    DiaRecebimento = 15,
                    Endereco = "Teste Mock 1",
                    Cep = "12345678",
                    Complemento = "Teste Mock 1",
                    NumeroEndereco = "NumeroEndereco",
                    IdBairro = 1,
                    IdCidade = 1,
                    IdEstado = 1,
                    IdentificadorConvenio = IdentificadorConvenio.Celos,
                    Ddd = "047",
                    Telefone = "047988498793",
                    CadastroFarmacia = "Teste Mock 1",
                    CodigoPerdigao = "Teste",
                    Cnpj = "Teste Mock 1",
                    DiasPrimeiroVencimento = 20,
                    Ie = "Teste Mock 1",
                    Bloqueado = true,
                    PermitirParcelamento = true,
                    EnviarEcommerce = true,
                    PermitirRateio = true,
                    IdVisitador = 1,
                    IdEtiqueta = 1,
                    EnderecoComprovanteVenda = true,
                },
                new Convenio()
                {
                    Id = 2,
                    Nome = "Teste Mock 2",
                    Desconto = 20,
                    Acrescimo = 20,
                    Manifesto = 20,
                    DiaRecebimento = 15,
                    Endereco = "Teste Mock 2",
                    Cep = "12345678",
                    Complemento = "Teste Mock 2",
                    NumeroEndereco = "NumeroEndereco",
                    IdBairro = 2,
                    IdCidade = 2,
                    IdEstado = 2,
                    IdentificadorConvenio = IdentificadorConvenio.Celos,
                    Ddd = "047",
                    Telefone = "047988498793",
                    CadastroFarmacia = "Teste Mock 2",
                    CodigoPerdigao = "Teste",
                    Cnpj = "Teste Mock 2",
                    DiasPrimeiroVencimento = 20,
                    Ie = "Teste Mock 2",
                    Bloqueado = true,
                    PermitirParcelamento = true,
                    EnviarEcommerce = true,
                    PermitirRateio = true,
                    IdVisitador = 2,
                    IdEtiqueta = 2,
                    EnderecoComprovanteVenda = true,
                },
                new Convenio()
                {
                    Id = 3,
                    Nome = "Teste Mock 3",
                    Desconto = 20,
                    Acrescimo = 20,
                    Manifesto = 20,
                    DiaRecebimento = 15,
                    Endereco = "Teste Mock 3",
                    Cep = "12345678",
                    Complemento = "Teste Mock 3",
                    NumeroEndereco = "NumeroEndereco",
                    IdBairro = 3,
                    IdCidade = 3,
                    IdEstado = 3,
                    IdentificadorConvenio = IdentificadorConvenio.Celos,
                    Ddd = "047",
                    Telefone = "047988498793",
                    CadastroFarmacia = "Teste Mock 3",
                    CodigoPerdigao = "Teste",
                    Cnpj = "Teste Mock 3",
                    DiasPrimeiroVencimento = 20,
                    Ie = "Teste Mock 3",
                    Bloqueado = true,
                    PermitirParcelamento = true,
                    EnviarEcommerce = true,
                    PermitirRateio = true,
                    IdVisitador = 3,
                    IdEtiqueta = 3,
                    EnderecoComprovanteVenda = true,
                }
            };
        }
    }
}
