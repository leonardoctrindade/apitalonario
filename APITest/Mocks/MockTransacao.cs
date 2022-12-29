using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockTransacao
    {
        public static Transacao MontaObjetoUnico()
        {
            return new Transacao { Id = 1, Codigo = 1, Tipo = 1, Descricao = "Teste Mock 1", Conciliar = true, FornecedorId = 1, PlanoDeContaId = 1, ClienteId = 1 };
        }

        public static Transacao MontaObjetoDescricaoVazia()
        {
            return new Transacao { Id = 1, Codigo = 1, Tipo = 1, Descricao = null, Conciliar = true, FornecedorId = 1, PlanoDeContaId = 1, ClienteId = 1 };
        }

        public static Transacao MontaObjetoTipoInvalido()
        {
            return new Transacao { Id = 1, Codigo = 1, Tipo = 0, Descricao = "Teste Mock 1", Conciliar = true, FornecedorId = 1, PlanoDeContaId = 1, ClienteId = 1 };
        }

        public static List<Transacao> MontaListaItems()
        {
            return new List<Transacao>()
            {
                new Transacao() { Id = 1, Codigo = 1, Tipo = 1, Descricao = "Teste Mock 1", Conciliar = true, FornecedorId = 1, PlanoDeContaId = 1, ClienteId = 1 },
                new Transacao() { Id = 2, Codigo = 2, Tipo = 2, Descricao = "Teste Mock 1", Conciliar = false, FornecedorId = 1, PlanoDeContaId = 1, ClienteId = 1 },
                new Transacao() { Id = 3, Codigo = 3, Tipo = 1, Descricao = "Teste Mock 1", Conciliar = true, FornecedorId = 1, PlanoDeContaId = 1, ClienteId = 1 }
            };
        }
    }
}
