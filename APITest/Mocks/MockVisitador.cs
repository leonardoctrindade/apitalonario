using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockVisitador
    {
        public static Visitador MontaObjetoUnico()
        {
            return new Visitador 
            { 
                Id = 1,
                Nome = "Teste Mock",
                Cep = "123456",
                Endereco = "Rua Teste",
                Numero = "789",
                Complemento = "Proximo ao Mercado",
                BairroId = 1,
                CidadeId = 1,
                EstadoId = 1,
                DDD = "47",
                Telefone = "32415588",
                Celular = "999984512",
                Comissao = 1.65
            };
        }
        public static Visitador MontaObjetoNomeVazio(string nome)
        {
            return new Visitador
            {
                Id = 1,
                Nome = nome,
                Cep = "123456",
                Endereco = "Rua Teste",
                Numero = "789",
                Complemento = "Proximo ao Mercado",
                BairroId = 1,
                CidadeId = 1,
                EstadoId = 1,
                DDD = "47",
                Telefone = "32415588",
                Celular = "999984512",
                Comissao = 1.65
            };
        }
        public static List<Visitador> MontaListaItens()
        {
            return new List<Visitador>
            {
                new Visitador
                {
                    Id = 1,
                    Nome = "Teste 1",
                    Cep = "123456",
                    Endereco = "Rua Teste",
                    Numero = "789",
                    Complemento = "Proximo ao Mercado",
                    BairroId = 1,
                    CidadeId = 1,
                    EstadoId = 1,
                    DDD = "47",
                    Telefone = "32415588",
                    Celular = "999984512",
                    Comissao = 1.65
                },
                new Visitador
                {
                    Id = 2,
                    Nome = "Teste 2",
                    Cep = "123456",
                    Endereco = "Rua Teste",
                    Numero = "789",
                    Complemento = "Proximo ao Mercado",
                    BairroId = 1,
                    CidadeId = 1,
                    EstadoId = 1,
                    DDD = "47",
                    Telefone = "32415588",
                    Celular = "999984512",
                    Comissao = 1.65
                },
                new Visitador
                {
                    Id = 3,
                    Nome = "Teste 3",
                    Cep = "123456",
                    Endereco = "Rua Teste",
                    Numero = "789",
                    Complemento = "Proximo ao Mercado",
                    BairroId = 1,
                    CidadeId = 1,
                    EstadoId = 1,
                    DDD = "47",
                    Telefone = "32415588",
                    Celular = "999984512",
                    Comissao = 1.65
                }
            };
        }
    }
}
