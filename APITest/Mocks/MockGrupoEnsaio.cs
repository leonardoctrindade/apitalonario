using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockGrupoEnsaio
    {
        public static GrupoEnsaio MontaObjetoUnico()
        {
            return new GrupoEnsaio { Id = 1, Descricao = "Teste Mock 1", EnsaioId = 1, GrupoId = 1 };
        }

        public static GrupoEnsaio MontaObjetoEnsaioIdInvalido()
        {
            return new GrupoEnsaio { Id = 1, Descricao = "Teste Mock 1", EnsaioId = -1, GrupoId = 1 };
        }

        public static GrupoEnsaio MontaObjetoGrupoIdInvalido()
        {
            return new GrupoEnsaio { Id = 1, Descricao = "Teste Mock 1", EnsaioId = 1, GrupoId = -1 };
        }

        public static List<GrupoEnsaio> MontaListaItems()
        {
            return new List<GrupoEnsaio>()
            {
                new GrupoEnsaio () { Id = 1, Descricao = "Teste Mock 1", EnsaioId = 1, GrupoId = 1 },
                new GrupoEnsaio () { Id = 2, Descricao = "Teste Mock 2", EnsaioId = 2, GrupoId = 2 },
                new GrupoEnsaio () { Id = 3, Descricao = "Teste Mock 3", EnsaioId = 3, GrupoId = 3 }
            };
        }
    }
}
