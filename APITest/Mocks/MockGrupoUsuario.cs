using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace APITest.Mocks
{
    public static class MockGrupoUsuario
    {
        public static GrupoUsuario MontaObjetoUnico()
        {
            return new GrupoUsuario { Id = 1, Descricao = "Teste Mock 1", NivelGrupo = 1};
        }

        public static GrupoUsuario MontaObjetoDescricaoVazia()
        {
            return new GrupoUsuario { Id = 1, Descricao = null, NivelGrupo = 1 };
        }

        public static List<GrupoUsuario> MontaListaItems()
        {
            return new List<GrupoUsuario>()
            {
                new GrupoUsuario() { Id = 1, Descricao = "Teste Mock 1", NivelGrupo = 1 },
                new GrupoUsuario() { Id = 2, Descricao = "Teste Mock 2", NivelGrupo = 2 },
                new GrupoUsuario() { Id = 3, Descricao = "Teste Mock 3", NivelGrupo = 3 }
            };
        }
    }
}
