using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockConvenioGrupo
    {
        public static ConvenioGrupo MontaObjetoUnico()
        {
            return new ConvenioGrupo { Id = 1, GrupoId = 1, Desconto = 24, AplicaCustoReferencia = true, AplicaDescontoProduto = true, ConvenioId = 1 };
        }

        public static ConvenioGrupo MontaObjetoIdGrupoInvalido()
        {
            return new ConvenioGrupo { Id = 1, GrupoId = 0, Desconto = 25, AplicaCustoReferencia = true, AplicaDescontoProduto = true, ConvenioId = 1 };
        }

        public static ConvenioGrupo MontaObjetoDescontoInvalido()
        {
            return new ConvenioGrupo { Id = 1, GrupoId = 1, Desconto = 0, AplicaCustoReferencia = true, AplicaDescontoProduto = true, ConvenioId = 1 };
        }

        public static ConvenioGrupo MontaObjetoIdConvenioInvalido()
        {
            return new ConvenioGrupo { Id = 1, GrupoId = 1, Desconto = 0, AplicaCustoReferencia = true, AplicaDescontoProduto = true, ConvenioId = 1 };

        }

        public static List<ConvenioGrupo> MontaListaItems()
        {
            return new List<ConvenioGrupo>()
            {
                new ConvenioGrupo() { Id = 1, GrupoId = 1, Desconto = 24, AplicaCustoReferencia = true, AplicaDescontoProduto = true, ConvenioId = 1 },
                new ConvenioGrupo() { Id = 2, GrupoId = 2, Desconto = 25, AplicaCustoReferencia = false, AplicaDescontoProduto = false, ConvenioId = 2 },
                new ConvenioGrupo() { Id = 3, GrupoId = 3, Desconto = 26, AplicaCustoReferencia = true, AplicaDescontoProduto = true, ConvenioId = 3 }
            };
        }
    }
}
