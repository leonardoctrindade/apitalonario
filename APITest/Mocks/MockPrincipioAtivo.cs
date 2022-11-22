using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public class MockPrincipioAtivo
    {
        public static PrincipioAtivo MontaObjetoUnico()
        {
            return new PrincipioAtivo { Id = 1, Descricao = "Teste Mock 1"};
        }
        public static PrincipioAtivo MontaObjetoDescricaoVazio()
        {
            return new PrincipioAtivo { Id = 1, Descricao = ""};
        }
        public static List<PrincipioAtivo> MontaListaItens()
        {
            return new List<PrincipioAtivo>()
            {
                new PrincipioAtivo { Id = 1,Descricao = "Teste Mock 1" },
                new PrincipioAtivo { Id = 2,Descricao = "Teste Mock 2" },
                new PrincipioAtivo { Id = 3,Descricao = "Teste Mock 3" }
            };
        }
    }
}
