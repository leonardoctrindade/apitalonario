using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockGrupo
    {
        public static Grupo MontaObjetoUnico()
        {
            return new Grupo() 
            { 
                Id = 1,
                Descricao = "Teste Mock 1",
                Comissao = 55,
                DescontoMaximo = 55,
                PercentualDesconto = 55,
                Tipo = TipoGrupo.Floral,
                AtivaControleDeLotesAcabados = true,
                AtivaControleLotesDrogaria = true,
                AtivaPesagemGrupo = true,
                CodigoGrupoLp = "12",
                FatorReferenciaGrupo = 123
            };
        }

        public static Grupo MontaObjetoDescricaoVazia()
        {
            return new Grupo()
            {
                Id = 1,
                Descricao = null,
                Comissao = 55,
                DescontoMaximo = 55,
                PercentualDesconto = 55,
                Tipo = TipoGrupo.Floral,
                AtivaControleDeLotesAcabados = true,
                AtivaControleLotesDrogaria = true,
                AtivaPesagemGrupo = true,
                CodigoGrupoLp = "12",
                FatorReferenciaGrupo = 123
            };
        }

        public static Grupo MontaObjetoPercentualDescontoInvalido()
        {
            return new Grupo()
            {
                Id = 1,
                Descricao = "Teste Mock 1",
                Comissao = 55,
                DescontoMaximo = 55,
                PercentualDesconto = 0,
                Tipo = TipoGrupo.Floral,
                AtivaControleDeLotesAcabados = true,
                AtivaControleLotesDrogaria = true,
                AtivaPesagemGrupo = true,
                CodigoGrupoLp = "12",
                FatorReferenciaGrupo = 123
            };
        }

        public static List<Grupo> MontaListaItems()
        {
            return new List<Grupo>()
            {
                new Grupo()
                {
                    Id = 1,
                    Descricao = "Teste Mock 1",
                    Comissao = 55,
                    DescontoMaximo = 55,
                    PercentualDesconto = 55,
                    Tipo = TipoGrupo.Floral,
                    AtivaControleDeLotesAcabados = true,
                    AtivaControleLotesDrogaria = true,
                    AtivaPesagemGrupo = true,
                    CodigoGrupoLp = "12",
                    FatorReferenciaGrupo = 123
                },
                new Grupo()
                {
                    Id = 2,
                    Descricao = "Teste Mock 2",
                    Comissao = 55,
                    DescontoMaximo = 55,
                    PercentualDesconto = 55,
                    Tipo = TipoGrupo.Floral,
                    AtivaControleDeLotesAcabados = true,
                    AtivaControleLotesDrogaria = true,
                    AtivaPesagemGrupo = true,
                    CodigoGrupoLp = "12",
                    FatorReferenciaGrupo = 123
                },
                new Grupo()
                {
                    Id = 3,
                    Descricao = "Teste Mock 3",
                    Comissao = 55,
                    DescontoMaximo = 55,
                    PercentualDesconto = 55,
                    Tipo = TipoGrupo.Floral,
                    AtivaControleDeLotesAcabados = true,
                    AtivaControleLotesDrogaria = true,
                    AtivaPesagemGrupo = true,
                    CodigoGrupoLp = "12",
                    FatorReferenciaGrupo = 123
                }
            };
        }
    }
}
