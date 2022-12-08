using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockMensagensPadrao
    {
        public static MensagensPadrao MontaObjetoUnico()
        {
            return new MensagensPadrao { Id = 1, StatusDescricao = "Teste Mock 1", Mensagem = "Teste Mock 1", DescricaoRotulo = true, EnviarAutomatico = true };
        }

        public static List<MensagensPadrao> MontaListaItems()
        {
            return new List<MensagensPadrao>()
            {
                new MensagensPadrao(){Id = 1, StatusDescricao = "Teste mock 1", Mensagem = "Teste Mock 1", DescricaoRotulo = true, EnviarAutomatico = true },
                new MensagensPadrao(){Id = 2, StatusDescricao = "Teste mock 2", Mensagem = "Teste Mock 2", DescricaoRotulo = false, EnviarAutomatico = true },
                new MensagensPadrao(){Id = 3, StatusDescricao = "Teste mock 3", Mensagem = "Teste Mock 3", DescricaoRotulo = true, EnviarAutomatico = false }
            };
        }
    }
}
