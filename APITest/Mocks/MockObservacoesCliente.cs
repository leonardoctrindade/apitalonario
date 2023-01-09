using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockObservacoesCliente
    {
        public static ObservacoesCliente MontaObjetoUnico()
        {
            return new ObservacoesCliente { Id = 1, MensagemVenda = "Teste Mock 1", ObservacaoOp = "Teste Mock 1", ObservacaoGeral = "Teste Mock 1", ClienteId = 1 };
        }

        public static ObservacoesCliente MontaObjetoClienteIdInvalido()
        {
            return new ObservacoesCliente { Id = 1, MensagemVenda = "Teste Mock 1", ObservacaoOp = "Teste Mock 1", ObservacaoGeral = "Teste Mock 1", ClienteId = 0 };
        }

        public static List<ObservacoesCliente> MontaListaItems()
        {
            return new List<ObservacoesCliente>()
            {
                new ObservacoesCliente() { Id = 1, MensagemVenda = "Teste Mock 1", ObservacaoOp = "Teste Mock 1", ObservacaoGeral = "Teste Mock 1", ClienteId = 1 },
                new ObservacoesCliente() { Id = 2, MensagemVenda = "Teste Mock 2", ObservacaoOp = "Teste Mock 2", ObservacaoGeral = "Teste Mock 2", ClienteId = 2 },
                new ObservacoesCliente() { Id = 3, MensagemVenda = "Teste Mock 3", ObservacaoOp = "Teste Mock 3", ObservacaoGeral = "Teste Mock 3", ClienteId = 3 },
            };
        }
    }
}
