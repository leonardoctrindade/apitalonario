using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockRegiao
    {
        public static Regiao MontaObjetoUnico()
        {
            return new Regiao { Id = 1, Descricao = "Teste Mock 1", Taxa = 25, HoraFinalSegunda = DateTime.Now, HoraInicialSegunda = DateTime.Now, IeSegunda = true };
        }

        public static Regiao MontaObjetoDescricaoVazia()
        {
            return new Regiao { Id = 1, Descricao = null, Taxa = 25, HoraFinalSegunda = DateTime.Now, HoraInicialSegunda = DateTime.Now, IeSegunda = true };
        }

        public static List<Regiao> MontaListaItems()
        {
            return new List<Regiao>()
            {
                new Regiao() { Id = 1, Descricao = "Teste Mock 1", Taxa = 25, HoraFinalSegunda = DateTime.Now, HoraInicialSegunda = DateTime.Now, IeSegunda = true },
                new Regiao() { Id = 2, Descricao = "Teste Mock 2", Taxa = 26, HoraFinalTerca = DateTime.Now, HoraInicialTerca = DateTime.Now, IeTerca = true },
                new Regiao() { Id = 3, Descricao = "Teste Mock 3", Taxa = 27, HoraFinalQuarta = DateTime.Now, HoraInicialQuarta = DateTime.Now, IeQuarta = true }
            };
        }
    }
}
