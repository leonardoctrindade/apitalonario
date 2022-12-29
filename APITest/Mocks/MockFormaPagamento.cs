using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockFormaPagamento
    {
        public static FormaPagamento MontaObjetoUnico()
        {
            return new FormaPagamento { Id = 1, Descricao = "Teste Mock 1", TipoPagamento = TipoPagamento.Cartao, AutorizarDescontos = 1, Conciliacao = true, PlanoDeContaId = 1 };
        }

        public static FormaPagamento MontaObjetoDescricaoVazio()
        {
            return new FormaPagamento { Id = 1, Descricao = null, TipoPagamento = TipoPagamento.TransferenciaBancaria, AutorizarDescontos = 1, Conciliacao = true, PlanoDeContaId = 1 };
        }

        public static List<FormaPagamento> MontaListaItems()
        {
            return new List<FormaPagamento>()
            {
                new FormaPagamento() {Id = 1, Descricao = "Teste Mock 1", TipoPagamento = TipoPagamento.TransferenciaBancaria, AutorizarDescontos = 1, Conciliacao = true, PlanoDeContaId = 1 },
                new FormaPagamento() {Id = 2, Descricao = "Teste Mock 2", TipoPagamento = TipoPagamento.Boleto, AutorizarDescontos = 2, Conciliacao = true, PlanoDeContaId = 2 },
                new FormaPagamento() {Id = 3, Descricao = "Teste Mock 3", TipoPagamento = TipoPagamento.Deposito, AutorizarDescontos = 3, Conciliacao = false, PlanoDeContaId = 3 }
            };
        }
    }   
}
