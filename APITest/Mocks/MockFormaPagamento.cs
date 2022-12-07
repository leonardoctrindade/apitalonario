﻿using Data.Entidades;
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
            return new FormaPagamento { Id = 1, Descricao = "Teste Mock 1", TipoFormaPagamento = 1, AutorizarDescontos = 1, Conciliacao = true, IdConta = 1 };
        }

        public static FormaPagamento MontaObjetoDescricaoVazio()
        {
            return new FormaPagamento { Id = 1, Descricao = null, TipoFormaPagamento = 1, AutorizarDescontos = 1, Conciliacao = true, IdConta = 1 };
        }

        public static List<FormaPagamento> MontaListaItems()
        {
            return new List<FormaPagamento>()
            {
                new FormaPagamento() {Id = 1, Descricao = "Teste Mock 1", TipoFormaPagamento = 1, AutorizarDescontos = 1, Conciliacao = true, IdConta = 1 },
                new FormaPagamento() {Id = 2, Descricao = "Teste Mock 2", TipoFormaPagamento = 2, AutorizarDescontos = 2, Conciliacao = true, IdConta = 2 },
                new FormaPagamento() {Id = 3, Descricao = "Teste Mock 3", TipoFormaPagamento = 3, AutorizarDescontos = 3, Conciliacao = false, IdConta = 3 }
            };
        }
    }   
}