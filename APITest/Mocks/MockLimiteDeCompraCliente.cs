using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockLimiteDeCompraCliente
    {
        public static LimiteDeCompraCliente MontaObjetoUnico()
        {
            return new LimiteDeCompraCliente { Id = 1, LimiteDeCompra = 123, BloqueioLimiteExcedido = true, FormaPagamento = 123, DiaPagamento = 123, PrazoDias = 123, ClienteId = 1 };
        }

        public static LimiteDeCompraCliente MontaObjetoClienteIdInvalido()
        {
            return new LimiteDeCompraCliente { Id = 1, LimiteDeCompra = 123, BloqueioLimiteExcedido = true, FormaPagamento = 123, DiaPagamento = 123, PrazoDias = 123, ClienteId = 0 };
        }

        public static List<LimiteDeCompraCliente> MontaListaItems()
        {
            return new List<LimiteDeCompraCliente>()
            {
                new LimiteDeCompraCliente() { Id = 1, LimiteDeCompra = 123, BloqueioLimiteExcedido = true, FormaPagamento = 123, DiaPagamento = 123, PrazoDias = 123, ClienteId = 1 },
                new LimiteDeCompraCliente() { Id = 2, LimiteDeCompra = 123, BloqueioLimiteExcedido = false, FormaPagamento = 123, DiaPagamento = 123, PrazoDias = 123, ClienteId = 2 },
                new LimiteDeCompraCliente() { Id = 3, LimiteDeCompra = 123, BloqueioLimiteExcedido = true, FormaPagamento = 123, DiaPagamento = 123, PrazoDias = 123, ClienteId = 3 }
            };
        }
    }
}
