using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockFidelidade
    {
        public static Fidelidade MontaObjetoUnico()
        {
            return new Fidelidade { Id = 1, Descricao = "Teste Mock 1", PontosIniciais = 4, ValidadePontos = 4, PontosPrimeiraCompra = 4, AvisoCliente = 4 };
        }

        public static Fidelidade MontaObjetoDescricaoVazia()
        {
            return new Fidelidade { Id = 1, Descricao = null, PontosIniciais = 4, ValidadePontos = 4, PontosPrimeiraCompra = 4, AvisoCliente = 4 };
        }

        public static List<Fidelidade> MontaListaItems()
        {
            return new List<Fidelidade>()
            {
                new Fidelidade() { Id = 1, Descricao = "Teste Mock 1", PontosIniciais = 4, ValidadePontos = 4, PontosPrimeiraCompra = 4, AvisoCliente = 4 },
                new Fidelidade() { Id = 2, Descricao = "Teste Mock 2", PontosIniciais = 4, ValidadePontos = 4, PontosPrimeiraCompra = 4, AvisoCliente = 4 },
                new Fidelidade() { Id = 3, Descricao = "Teste Mock 3", PontosIniciais = 4, ValidadePontos = 4, PontosPrimeiraCompra = 4, AvisoCliente = 4 }
            };
        }
    }
}
