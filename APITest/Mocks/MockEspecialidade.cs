using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockEspecialidade
    {
        public static Especialidade MontaObjetoUnico()
        {
            return new Especialidade { Id = 1, Descricao = "Teste Mock 1" };
        }
        public static Especialidade MontaObjetoDescricaoVazio()
        {
            return new Especialidade { Id = 1, Descricao = null };
        }

        public static List<Especialidade> MontaListaItems()
        {
            return new List<Especialidade>()
            {
                new Especialidade() {Id = 1, Descricao = "Teste Mock 1"},
                new Especialidade() {Id = 2, Descricao = "Teste Mock 2"},
                new Especialidade() {Id = 3, Descricao = "Teste Mock 3"}
            };
        }
    }
}
