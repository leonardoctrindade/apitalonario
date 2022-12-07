using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockAdministradoraCartao
    {
        public static AdministradoraCartao MontaObjetoUnico()
        {
            return new AdministradoraCartao { Id = 1, Nome = "Teste Mock 1", PrazoRecebimento = 5, Desconto = 2.1m, Gerenciador = 1, CieloPremia = 1, Modalidade = 1, Ativo = true, IdConta = 1, IdFornecedor = 1 };
        }

        public static AdministradoraCartao MontaObjetoNomeVazio()
        {
            return new AdministradoraCartao { Id = 1, Nome = null, PrazoRecebimento = 5, Desconto = 2.1m, Gerenciador = 1, CieloPremia = 1, Modalidade = 1, Ativo = true, IdConta = 1, IdFornecedor = 1 };
        }

        public static List<AdministradoraCartao> MontaListaItems()
        {
            return new List<AdministradoraCartao>()
            {
                new AdministradoraCartao() { Id = 1, Nome = "Teste Mock 1", PrazoRecebimento = 5, Desconto = 2.1m, Gerenciador = 1, CieloPremia = 1, Modalidade = 1, Ativo = true, IdConta = 1, IdFornecedor = 1 },
                new AdministradoraCartao() { Id = 2, Nome = "Teste Mock 2", PrazoRecebimento = 6, Desconto = 2.1m, Gerenciador = 1, CieloPremia = 1, Modalidade = 1, Ativo = true, IdConta = 2, IdFornecedor = 2 },
                new AdministradoraCartao() { Id = 3, Nome = "Teste Mock 3", PrazoRecebimento = 80, Desconto = 2, Gerenciador = 2, CieloPremia = 3, Modalidade = 2, Ativo = false, IdConta = 3, IdFornecedor = 3 }
            };
        }
    }
}
