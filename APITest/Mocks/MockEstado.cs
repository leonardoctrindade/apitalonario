using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockEstado
    {
        public static Estado MontaObjetoUnico()
        {
            var pais = new Pais() { Id = 1, Nome = "Brasil", CodigoIbge = 123, CodigoTelefonico = 123};
            var listaPais = new List<Pais>();
            listaPais.Add(pais);
            return new Estado { Id = 1, Nome = "Teste Mock 1", Sigla = "SC", IdPais = pais.Id, ChecagemContribuinteIsento = false, DifalComCalculoDeIsento = false, DifalComCalculoPorDentro = false, AliquotaFcpEstado = 17, AliquotaIcmsEstado = 0};
        }

        public static Estado MontaObjetoNomeVazio()
        {
            var pais = new Pais() { Id = 1, Nome = "Brasil", CodigoIbge = 123, CodigoTelefonico = 123 };
            return new Estado { Id = 1, Nome = null, Sigla = "SC", IdPais = pais.Id, ChecagemContribuinteIsento = false, DifalComCalculoDeIsento = false, DifalComCalculoPorDentro = false, AliquotaFcpEstado = 17, AliquotaIcmsEstado = 0 };
        }

        public static Estado MontaObjetoSiglaVazia()
        {
            return new Estado { Id = 1, Nome = "Teste Mock 1", IdPais = 1, ChecagemContribuinteIsento = false, DifalComCalculoDeIsento = false, DifalComCalculoPorDentro = false, AliquotaFcpEstado = 17, AliquotaIcmsEstado = 0 };
        }

        public static Estado MontaObjetoSiglaUmCaracter()
        {
            return new Estado { Id = 1, Nome = "Teste Mock 1", Sigla = "S" , IdPais = 1, ChecagemContribuinteIsento = false, DifalComCalculoDeIsento = false, DifalComCalculoPorDentro = false, AliquotaFcpEstado = 17, AliquotaIcmsEstado = 0 };
        }

        public static Estado MontaObjetoSiglaTresCaracter()
        {
            return new Estado { Id = 1, Nome = "Teste Mock 1", Sigla = "SCC", IdPais = 1, ChecagemContribuinteIsento = false, DifalComCalculoDeIsento = false, DifalComCalculoPorDentro = false, AliquotaFcpEstado = 17, AliquotaIcmsEstado = 0 };
        }

        public static List<Estado> MontaListaItems()
        {
            var pais = new Pais() { Id = 1, Nome = "Brasil", CodigoIbge = 123, CodigoTelefonico = 123 };
            return new List<Estado>()
            {
                new Estado(){Id = 1, Nome = "Teste Mock 1", Sigla = "SC", IdPais = pais.Id, ChecagemContribuinteIsento = false, DifalComCalculoDeIsento = false, DifalComCalculoPorDentro = false, AliquotaFcpEstado = 17, AliquotaIcmsEstado = 0},
                new Estado(){Id = 2, Nome = "Teste Mock 2", Sigla = "SC", IdPais = pais.Id, ChecagemContribuinteIsento = false, DifalComCalculoDeIsento = false, DifalComCalculoPorDentro = false, AliquotaFcpEstado = 17, AliquotaIcmsEstado = 0},
                new Estado(){Id = 3, Nome = "Teste Mock 3", Sigla = "SC", IdPais = pais.Id, ChecagemContribuinteIsento = false, DifalComCalculoDeIsento = false, DifalComCalculoPorDentro = false, AliquotaFcpEstado = 17, AliquotaIcmsEstado = 0}
            };
        }
    }
}
