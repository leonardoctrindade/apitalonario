using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockEntregador
    {
        public static Entregador MontaObjetoUnico()
        {
            return new Entregador
            {
                Id = 1,
                Nome = "Teste Mock 1",
                Cpf = "123",
                Cnpj = "123",
                IeEntregador = "123",
                Ddd = "123",
                Telefone = "516816",
                Fax = "123",
                Contato = "Pedrin",
                TelefoneContato = "123",
                Email = "prismafive@gmail.com",
                EntregadorInativo = true,
                NomeUsuario = "PrismaFive",
                NomeUsuarioRec = "PrismaFive",
                DataAtualizacao = DateTime.Now,
                DataAtualizacaoRec = DateTime.Now
            };
        }

        public static Entregador MontaObjetoNomeVazio()
        {
            return new Entregador
            {
                Id = 1,
                Nome = null,
                Cpf = "123",
                Cnpj = "123",
                IeEntregador = "123",
                Ddd = "123",
                Telefone = "516816",
                Fax = "123",
                Contato = "Pedrin",
                TelefoneContato = "123",
                Email = "prismafive@gmail.com",
                EntregadorInativo = true,
                NomeUsuario = "PrismaFive",
                NomeUsuarioRec = "PrismaFive",
                DataAtualizacao = DateTime.Now,
                DataAtualizacaoRec = DateTime.Now
            };
        }

        public static Entregador MontaObjetoDddVazio()
        {
            return new Entregador
            {
                Id = 1,
                Nome = "Teste Mock 1",
                Cpf = "123",
                Cnpj = "123",
                IeEntregador = "123",
                Ddd = null,
                Telefone = "516816",
                Fax = "123",
                Contato = "Pedrin",
                TelefoneContato = "123",
                Email = "prismafive@gmail.com",
                EntregadorInativo = true,
                NomeUsuario = "PrismaFive",
                NomeUsuarioRec = "PrismaFive",
                DataAtualizacao = DateTime.Now,
                DataAtualizacaoRec = DateTime.Now
            };
        }

        public static Entregador MontaObjetoTelefoneVazio()
        {
            return new Entregador
            {
                Id = 1,
                Nome = "Teste Mock 1",
                Cpf = "123",
                Cnpj = "123",
                IeEntregador = "123",
                Ddd = "123",
                Telefone = null,
                Fax = "123",
                Contato = "Pedrin",
                TelefoneContato = "123",
                Email = "prismafive@gmail.com",
                EntregadorInativo = true,
                NomeUsuario = "PrismaFive",
                NomeUsuarioRec = "PrismaFive",
                DataAtualizacao = DateTime.Now,
                DataAtualizacaoRec = DateTime.Now
            };
        }

        public static List<Entregador> MontaListaItems()
        {
            return new List<Entregador>()
            {
                new Entregador
                {
                    Id = 1,
                    Nome = "Teste Mock 1",
                    Cpf = "123",
                    Cnpj = "123",
                    IeEntregador = "123",
                    Ddd = "123",
                    Telefone = "516816",
                    Fax = "123",
                    Contato = "Pedrin",
                    TelefoneContato = "123",
                    Email = "prismafive@gmail.com",
                    EntregadorInativo = true,
                    NomeUsuario = "PrismaFive",
                    NomeUsuarioRec = "PrismaFive",
                    DataAtualizacao = DateTime.Now,
                    DataAtualizacaoRec = DateTime.Now
                },
                new Entregador
                {
                    Id = 2,
                    Nome = "Teste Mock 2",
                    Cpf = "123",
                    Cnpj = "123",
                    IeEntregador = "123",
                    Ddd = "123",
                    Telefone = "516816",
                    Fax = "123",
                    Contato = "Pedrin",
                    TelefoneContato = "123",
                    Email = "prismafive@gmail.com",
                    EntregadorInativo = true,
                    NomeUsuario = "PrismaFive",
                    NomeUsuarioRec = "PrismaFive",
                    DataAtualizacao = DateTime.Now,
                    DataAtualizacaoRec = DateTime.Now
                },
                new Entregador
                {
                    Id = 3,
                    Nome = "Teste Mock 3",
                    Cpf = "123",
                    Cnpj = "123",
                    IeEntregador = "123",
                    Ddd = "123",
                    Telefone = "516816",
                    Fax = "123",
                    Contato = "Pedrin",
                    TelefoneContato = "123",
                    Email = "prismafive@gmail.com",
                    EntregadorInativo = true,
                    NomeUsuario = "PrismaFive",
                    NomeUsuarioRec = "PrismaFive",
                    DataAtualizacao = DateTime.Now,
                    DataAtualizacaoRec = DateTime.Now
                }
            };
        }
    }
}
