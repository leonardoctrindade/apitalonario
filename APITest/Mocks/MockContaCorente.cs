using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockContaCorente
    {
        public static ContaCorrente MontaObjetoUnico()
        {
            return new ContaCorrente { Id = 1,NumeroConta = "123",Nome = "Teste Conta Corrente",Limite = 1000.20};
        }
        public static ContaCorrente MontaObjetoNomeVazio()
        {
            return new ContaCorrente { Id = 1, NumeroConta = "123", Nome = "", Limite = 100.30 };
        }

        public static ContaCorrente MontaObjetoComNumeroContaInvalido()
        {
            return new ContaCorrente { Id = 1,NumeroConta = "",Nome = "Teste 1",Limite = 1100.10 };
        }
        public static List<ContaCorrente> MontaListaItems()
        {
            return new List<ContaCorrente>()
            {
                new ContaCorrente { Id = 1, NumeroConta = "123", Nome = "Teste 1"},
                new ContaCorrente { Id = 2, NumeroConta = "1234", Nome = "Teste 2"},
                new ContaCorrente { Id = 3, NumeroConta = "12345", Nome = "Teste 3"}
            };
        }
    }
}
