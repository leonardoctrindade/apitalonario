using Data.Entidades;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockTransportador
    {
        public static Transportador MontaObjetoUnico()
        {
            return new Transportador
            {
                Id = 1,
                Nome = "Teste Mock 1",
                CpfCnpj = "07072944958",
                Ie = "Teste Mock 1",
                Cep = "88308390",
                Endereco = "Rua José Simplicio de Oliveira",
                Numero = "127 Fundos",
                IdBairro = 1,
                IdCidade = 1,
                IdEstado = 1,
                DDD = "047",
                Telefone = "988498793",
                CodigoAntt = "AAA23t52",
                Placa = "MIA8565",
                IdEstadoPlaca = 2
            };
        }

        public static Transportador MontaObjetoNomeVazio()
        {
            return new Transportador
            {
                Id = 1,
                Nome = null,
                CpfCnpj = "07072944958",
                Ie = "Teste Mock 1",
                Cep = "88308390",
                Endereco = "Rua José Simplicio de Oliveira",
                Numero = "127 Fundos",
                IdBairro = 1,
                IdCidade = 1,
                IdEstado = 1,
                DDD = "047",
                Telefone = "988498793",
                CodigoAntt = "AAA23t52",
                Placa = "MIA8565",
                IdEstadoPlaca = 2
            };
        }

        public static Transportador MontaObjetoCpfOuCnpjVazio()
        {
            return new Transportador
            {
                Id = 1,
                Nome = "Teste Mock 1",
                CpfCnpj = null,
                Ie = "Teste Mock 1",
                Cep = "88308390",
                Endereco = "Rua José Simplicio de Oliveira",
                Numero = "127 Fundos",
                IdBairro = 1,
                IdCidade = 1,
                IdEstado = 1,
                DDD = "047",
                Telefone = "988498793",
                CodigoAntt = "AAA23t52",
                Placa = "MIA8565",
                IdEstadoPlaca = 2
            };
        }

        public static List<Transportador> MontaListaItems()
        {
            return new List<Transportador>()
            {
                new Transportador {
                    Id = 1,
                    Nome = "Teste Mock 1",
                    CpfCnpj = "Teste Mock 1",
                    Ie = "Teste Mock 1",
                    Cep = "Teste Mock 1",
                    Endereco = "Rua José Simplicio de Oliveira",
                    Numero = "127 Fundos",
                    IdBairro = 1,
                    IdCidade = 1,
                    IdEstado = 1,
                    DDD = "047",
                    Telefone = "988498793",
                    CodigoAntt = "AAA23t52",
                    Placa = "MIA8565",
                    IdEstadoPlaca = 1
                },
                new Transportador {
                    Id = 1,
                    Nome = "Teste Mock 2",
                    CpfCnpj = "Teste Mock 2",
                    Ie = "Teste Mock 2",
                    Cep = "Teste Mock 2",
                    Endereco = "Rua José Simplicio de Oliveira",
                    Numero = "127 Fundos",
                    IdBairro = 2,
                    IdCidade = 2,
                    IdEstado = 2,
                    DDD = "047",
                    Telefone = "988498793",
                    CodigoAntt = "AAA23t52",
                    Placa = "MIA8565",
                    IdEstadoPlaca = 2
                },
                new Transportador {
                    Id = 3,
                    Nome = "Teste Mock 3",
                    CpfCnpj = "Teste Mock 3",
                    Ie = "Teste Mock 3",
                    Cep = "Teste Mock 3",
                    Endereco = "Rua José Simplicio de Oliveira",
                    Numero = "127 Fundos",
                    IdBairro = 3,
                    IdCidade = 3,
                    IdEstado = 3,
                    DDD = "047",
                    Telefone = "988498793",
                    CodigoAntt = "AAA23t52",
                    Placa = "MIA8565",
                    IdEstadoPlaca = 3
                }
            };
        }
    }
}
