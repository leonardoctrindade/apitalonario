using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockConfiguracoesPrismafive
    {
        public static ConfiguracoesPrismafive MontaObjetoUnico()
        {
            return new ConfiguracoesPrismafive { Id = 1, Secao = "Teste 1", Chave = "Teste Mock 1", UserMac = "Teste Mock 1", ValorIni = "Teste Mock 1" };
        }

        public static ConfiguracoesPrismafive MontaObjetoSecaoVazia()
        {
            return new ConfiguracoesPrismafive { Id = 1, Secao = null, Chave = "Teste Mock 1", UserMac = "Teste Mock 1", ValorIni = "Teste Mock 1" };
        }

        public static ConfiguracoesPrismafive MontaObjetoChaveVazia()
        {
            return new ConfiguracoesPrismafive { Id = 1, Secao = "Teste 1", Chave = null, UserMac = "Teste Mock 1", ValorIni = "Teste Mock 1" };
        }

        public static ConfiguracoesPrismafive MontaObjetoUserMacVazio()
        {
            return new ConfiguracoesPrismafive { Id = 1, Secao = "Teste 1", Chave = "Teste Mock 1", UserMac = null, ValorIni = "Teste Mock 1" };
        }

        public static List<ConfiguracoesPrismafive> MontaListaItems()
        {
            return new List<ConfiguracoesPrismafive>()
            {
                new ConfiguracoesPrismafive() { Id = 1, Secao = "Teste 1", Chave = "Teste Mock 1", UserMac = "Teste Mock 1", ValorIni = "Teste Mock 1" },
                new ConfiguracoesPrismafive() { Id = 2, Secao = "Teste 2", Chave = "Teste Mock 2", UserMac = "Teste Mock 2", ValorIni = "Teste Mock 2" },
                new ConfiguracoesPrismafive() { Id = 3, Secao = "Teste 3", Chave = "Teste Mock 3", UserMac = "Teste Mock 3", ValorIni = "Teste Mock 3" }
            };
        }
    }
}
