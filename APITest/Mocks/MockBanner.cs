using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace APITest.Mocks
{
    public static class MockBanner
    {
        public static Banner MontaObjetoUnico()
        {
            return new Banner { Id = 1, Descricao = "Teste Mock 1", Link = "adagagaga/agag", AcaoLink = 1, Posicao = 324, DataInicio = DateTime.Now, DataFim = DateTime.Now, Ativo = true };
        }

        public static Banner MontaObjetoPosicaoInvalida()
        {
            return new Banner { Id = 1, Descricao = "Teste Mock 1", Link = "adagagaga/agag", AcaoLink = 1, Posicao = -1, DataInicio = DateTime.Now, DataFim = DateTime.Now, Ativo = true };
        }

        public static Banner MontaObjetoDescricaoVazia()
        {
            return new Banner { Id = 1, Descricao = null, Link = "adagagaga/agag", AcaoLink = 1, Posicao = 1, DataInicio = DateTime.Now, DataFim = DateTime.Now, Ativo = true };
        }

        public static Banner MontaObjetoLinkVazio()
        {
            return new Banner { Id = 1, Descricao = "Teste Mock 1", Link = null, AcaoLink = 1, Posicao = 1, DataInicio = DateTime.Now, DataFim = DateTime.Now, Ativo = true };
        }

        public static Banner MontaObjetoAcaoLinkInvalida()
        {
            return new Banner { Id = 1, Descricao = "Teste Mock 1", Link = "adagagaga/agag", AcaoLink = -1, Posicao =-1, DataInicio = DateTime.Now, DataFim = DateTime.Now, Ativo = true };
        }

        public static Banner MontaObjetoDataInicioVazia()
        {
            return new Banner { Id = 1, Descricao = "Teste Mock 1", Link = "adagagaga/agag", AcaoLink = 1, Posicao = 1, DataInicio = null , DataFim = DateTime.Now, Ativo = true };
        }

        public static Banner MontaObjetoDataFimVazia()
        {
            return new Banner { Id = 1, Descricao = "Teste Mock 1", Link = "adagagaga/agag", AcaoLink = 1, Posicao = 1, DataInicio = DateTime.Now, DataFim = null, Ativo = true };
        }

        public static List<Banner> MontaListaItems()
        {
            return new List<Banner>()
            {
                new Banner { Id = 1, Descricao = "Teste Mock 1", Link = "adagagaga/agag", AcaoLink = 1, Posicao = 1, DataInicio = DateTime.Now, DataFim = DateTime.Now, Ativo = true },
                new Banner { Id = 2, Descricao = "Teste Mock 2", Link = "adagagaga/agag", AcaoLink = 2, Posicao = 2, DataInicio = DateTime.Now, DataFim = DateTime.Now, Ativo = true },
                new Banner { Id = 3, Descricao = "Teste Mock 3", Link = "adagagaga/agag", AcaoLink = 3, Posicao = 3, DataInicio = DateTime.Now, DataFim = DateTime.Now, Ativo = true }
            };
        }
    }
}
