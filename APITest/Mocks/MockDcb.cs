using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public class MockDcb
    {
        public static Dcb MontaObjetoUnico()
        {
            return new Dcb { Id = 1, CodigoDcb = "123", Descricao = "Teste Dcb" };
        }
        public static Dcb MontaObjetoComDescricaoVazio()
        {
            return new Dcb { Id = 1, CodigoDcb = "123", Descricao = "" };
        }
        public static Dcb MontaObjetoComCodigoDcbVazio()
        {
            return new Dcb { Id = 1, CodigoDcb = "", Descricao = "Teste Dcb" };
        }
        public static List<Dcb> MontaListaItems()
        {
            return new List<Dcb>
            {
                new Dcb { Id = 1, CodigoDcb = "123",Descricao = "Teste Dcb 1" },
                new Dcb { Id = 2, CodigoDcb = "1234",Descricao = "Teste Dcb 2" },
                new Dcb { Id = 3, CodigoDcb = "12345",Descricao = "Teste Dcb 3" }
            };
        }
    }
}
