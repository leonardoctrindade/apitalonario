using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public class MockClasse
    {
        public static Classe MontaObjetoUnico()
        {
            return new Classe { Id = 1, Descricao = "Teste Mock 1"};
        }
        public static Classe MontaObjetoDescricaoVazio()
        {
            return new Classe { Id = 1, Descricao = ""};
        }
        public static List<Classe> MontaListaItens()
        {
            return new List<Classe>()
            {
                new Classe{Id = 1, Descricao = "Teste Mock 1"},
                new Classe{Id = 2, Descricao = "Teste Mock 2"},
                new Classe{Id = 3, Descricao = "Teste Mock 3"}
            };
        }
    }
}
