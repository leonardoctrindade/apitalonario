using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockLaboratorio
    {
        public static Laboratorio MontaObjetoUnico()
        {
            return new Laboratorio { Id = 1 ,Descricao = "Teste Mock 1"};
        }
        public static Laboratorio MontaObjetoDescricaoVazio()
        {
            return new Laboratorio { Id = 1,Descricao = ""};
        }
        public static List<Laboratorio> MontaListaItens()
        {
            return new List<Laboratorio> 
            {
                new Laboratorio { Id = 1,Descricao = "Teste Mock 1" },
                new Laboratorio { Id = 2,Descricao = "Teste Mock 2" },
                new Laboratorio { Id = 3,Descricao = "Teste Mock 3" }
            };
        }
    }
}
