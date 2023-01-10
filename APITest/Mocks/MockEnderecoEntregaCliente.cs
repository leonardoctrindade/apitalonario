using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockEnderecoEntregaCliente
    {
        public static EnderecoEntregaCliente MontaObjetoUnico()
        {
            return new EnderecoEntregaCliente
            {
                Id = 1,
                Titulo = "Teste Mock 1",
                DataCadastro = DateTime.Now,
                Cep = "168164",
                Endereco = "Teste Mock 1",
                Numero = "Teste Mock 1",
                Complemento = "Teste Mock 1",
                Proximidade = "Teste Mock 1",
                BairroId = 1,
                RegiaoId = 1,
                CidadeId = 1,
                EstadoId = 1,
                DddTelefone = "047",
                Telefone = "33465410",
                ContatoTelefone = "Teste Mock 1",
                DddCelular = "047",
                Celular = "988498793",
                ContatoCelular = "Teste Mock 1",
                Email = "Teste Mock 1",
                Ativo = true,
                ClienteId = 1,
                Observacao = "Teste Mock 1"
            };
        }

        public static EnderecoEntregaCliente MontaObjetoTituloVazio()
        {
            return new EnderecoEntregaCliente
            {
                Id = 1,
                Titulo = null,
                DataCadastro = DateTime.Now,
                Cep = "168164",
                Endereco = "Teste Mock 1",
                Numero = "Teste Mock 1",
                Complemento = "Teste Mock 1",
                Proximidade = "Teste Mock 1",
                BairroId = 1,
                RegiaoId = 1,
                CidadeId = 1,
                EstadoId = 1,
                DddTelefone = "047",
                Telefone = "33465410",
                ContatoTelefone = "Teste Mock 1",
                DddCelular = "047",
                Celular = "988498793",
                ContatoCelular = "Teste Mock 1",
                Email = "Teste Mock 1",
                Ativo = true,
                ClienteId = 1,
                Observacao = "Teste Mock 1"
            };
        }

        public static EnderecoEntregaCliente MontaObjetoEnderecoVazio()
        {
            return new EnderecoEntregaCliente
            {
                Id = 1,
                Titulo = "Teste Mock 1",
                DataCadastro = DateTime.Now,
                Cep = "168164",
                Endereco = null,
                Numero = "Teste Mock 1",
                Complemento = "Teste Mock 1",
                Proximidade = "Teste Mock 1",
                BairroId = 1,
                RegiaoId = 1,
                CidadeId = 1,
                EstadoId = 1,
                DddTelefone = "047",
                Telefone = "33465410",
                ContatoTelefone = "Teste Mock 1",
                DddCelular = "047",
                Celular = "988498793",
                ContatoCelular = "Teste Mock 1",
                Email = "Teste Mock 1",
                Ativo = true,
                ClienteId = 1,
                Observacao = "Teste Mock 1"
            };
        }

        public static List<EnderecoEntregaCliente> MontaListaItems()
        {
            return new List<EnderecoEntregaCliente>()
            {
                new EnderecoEntregaCliente()
                {
                    Id = 1,
                    Titulo = "Teste Mock 1",
                    DataCadastro = DateTime.Now,
                    Cep = "168164",
                    Endereco = "Teste Mock 1",
                    Numero = "Teste Mock 1",
                    Complemento = "Teste Mock 1",
                    Proximidade = "Teste Mock 1",
                    BairroId = 1,
                    RegiaoId = 1,
                    CidadeId = 1,
                    EstadoId = 1,
                    DddTelefone = "047",
                    Telefone = "33465410",
                    ContatoTelefone = "Teste Mock 1",
                    DddCelular = "047",
                    Celular = "988498793",
                    ContatoCelular = "Teste Mock 1",
                    Email = "Teste Mock 1",
                    Ativo = true,
                    ClienteId = 1,
                    Observacao = "Teste Mock 1"
                },
                new EnderecoEntregaCliente()
                {
                    Id = 2,
                    Titulo = "Teste Mock 2",
                    DataCadastro = DateTime.Now,
                    Cep = "168164",
                    Endereco = "Teste Mock 2",
                    Numero = "Teste Mock 2",
                    Complemento = "Teste Mock 2",
                    Proximidade = "Teste Mock 2",
                    BairroId = 2,
                    RegiaoId = 2,
                    CidadeId = 2,
                    EstadoId = 2,
                    DddTelefone = "047",
                    Telefone = "33465410",
                    ContatoTelefone = "Teste Mock 2",
                    DddCelular = "047",
                    Celular = "988498793",
                    ContatoCelular = "Teste Mock 2",
                    Email = "Teste Mock 2",
                    Ativo = true,
                    ClienteId = 2,
                    Observacao = "Teste Mock 2"
                },
                new EnderecoEntregaCliente()
                {
                    Id = 3,
                    Titulo = "Teste Mock 3",
                    DataCadastro = DateTime.Now,
                    Cep = "168164",
                    Endereco = "Teste Mock 3",
                    Numero = "Teste Mock 3",
                    Complemento = "Teste Mock 3",
                    Proximidade = "Teste Mock 3",
                    BairroId = 3,
                    RegiaoId = 3,
                    CidadeId = 3,
                    EstadoId = 3,
                    DddTelefone = "047",
                    Telefone = "33465410",
                    ContatoTelefone = "Teste Mock 3",
                    DddCelular = "047",
                    Celular = "988498793",
                    ContatoCelular = "Teste Mock 3",
                    Email = "Teste Mock 3",
                    Ativo = true,
                    ClienteId = 3,
                    Observacao = "Teste Mock 3"
                },
            };
        }
    }
}
