using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockOperadorCaixa
    {
        public static OperadorCaixa MontaObjetoUnico()
        {
            return new OperadorCaixa { Id = 1, Nome = "Teste Mock 1", NomeAbreviado = "Teste Mock 1", IdFilial = 1 };
        }

        public static OperadorCaixa MontaObjetoNomeVazio()
        {
            return new OperadorCaixa { Id = 1, Nome = null, NomeAbreviado = "Teste Mock 1" };
        }

        public static List<OperadorCaixa> MontaListaItems()
        {
            return new List<OperadorCaixa>()
            { 
                new OperadorCaixa() { Id = 1, Nome = "Teste Mock 1", NomeAbreviado = "Teste Mock 1", IdFilial = 1},
                new OperadorCaixa() { Id = 2, Nome = "Teste Mock 2", NomeAbreviado = "Teste Mock 2", IdFilial = 2},
                new OperadorCaixa() { Id = 3, Nome = "Teste Mock 3", NomeAbreviado = "Teste Mock 3", IdFilial = 3}
            };
        }
    }
}
