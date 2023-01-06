using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockReacoesAdversas
    {
        public static ReacoesAdversas MontaObjetoUnico()
        {
            return new ReacoesAdversas { Id = 1, Data = DateTime.Now.Date, Medicamento = "Teste Mock 1", Dose = "Teste Mock 1", Reacao = "Teste Mock 1", ClienteId = 1 };
        }

        public static ReacoesAdversas MontaObjetoDataVazia()
        {
            return new ReacoesAdversas { Id = 1, Data = null, Medicamento = "Teste Mock 1", Dose = "Teste Mock 1", Reacao = "Teste Mock 1", ClienteId = 1 };
        }

        public static ReacoesAdversas MontaObjetoMedicamentoVazio()
        {
            return new ReacoesAdversas { Id = 1, Data = DateTime.Now.Date, Medicamento = null, Dose = "Teste Mock 1", Reacao = "Teste Mock 1", ClienteId = 1 };
        }

        public static ReacoesAdversas MontaObjetoDoseVazia()
        {
            return new ReacoesAdversas { Id = 1, Data = DateTime.Now.Date, Medicamento = "Teste Mock 1", Dose = null, Reacao = "Teste Mock 1", ClienteId = 1 };
        }

        public static ReacoesAdversas MontaObjetoClienteIdInvalido()
        {
            return new ReacoesAdversas { Id = 1, Data = DateTime.Now.Date, Medicamento = "Teste Mock 1", Dose = "Teste Mock 1", Reacao = "Teste Mock 1", ClienteId = 0 };
        }

        public static List<ReacoesAdversas> MontaListaItems()
        {
            return new List<ReacoesAdversas>()
            {
                new ReacoesAdversas() { Id = 1, Data = DateTime.Now.Date, Medicamento = "Teste Mock 1", Dose = "Teste Mock 1", Reacao = "Teste Mock 1", ClienteId = 1 },
                new ReacoesAdversas() { Id = 2, Data = DateTime.Now.Date, Medicamento = "Teste Mock 2", Dose = "Teste Mock 2", Reacao = "Teste Mock 2", ClienteId = 2 },
                new ReacoesAdversas() { Id = 3, Data = DateTime.Now.Date, Medicamento = "Teste Mock 3", Dose = "Teste Mock 3", Reacao = "Teste Mock 3", ClienteId = 3 },
            };
        }
    }
}
