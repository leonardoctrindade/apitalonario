using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockUnidade
    {
        public static Unidade MontaObjetoUnico()
        {
            return new Unidade { Id = 1, Sigla = "UN", Descricao = "Unidade",
                Tipo = Tipo.Massa, Fator = 1.25};
        }
        public static Unidade MontaObjetoSiglaVazio()
        {
            return new Unidade
            {
                Id = 1,
                Sigla = "",
                Descricao = "Unidade",
                Tipo = Tipo.Volume,
                Fator = 1.25
            };
        }
        public static Unidade MontaObjetoDescricaoVazio()
        {
            return new Unidade
            {
                Id = 1,
                Sigla = "Un",
                Descricao = "",
                Tipo = Tipo.Volume,
                Fator = 1.25
            };
        }
        public static List<Unidade> MontaListaItens()
        {
            return new List<Unidade> {
                new Unidade{ Id = 1, Sigla = "UN", Descricao = "Unidade"},
                new Unidade{ Id = 1, Sigla = "CX", Descricao = "Caixa"},
                new Unidade{ Id = 1, Sigla = "PC", Descricao = "Pacote"}
            };
        }
    }
}
