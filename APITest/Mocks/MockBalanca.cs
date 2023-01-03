using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockBalanca
    {
        public static Balanca MontaObjetoUnico()
        {
            return new Balanca
            {
                Id = 1,
                Modelo = "Teste Mock 1",
                PortaCom = "Teste 1",
                BitsPorSegundo = "dad",
                Dtr = "fafa",
                BitsDeDados = "fagag",
                Rts = "fafa",
                Paridade = "faf",
                XonXoff = "faga",
                Maquina = "faga",
                SeparadorDecimal = "agmaog",
                Opcoes = "agfaga",
                DescricaoModelo = "gagaga"
            };
        }

        public static Balanca MontaObjetoModeloVazio()
        {
            return new Balanca()
            {
                Id = 1,
                Modelo = null,
                PortaCom = "Teste 1",
                BitsPorSegundo = "dad",
                Dtr = "fafa",
                BitsDeDados = "fagag",
                Rts = "fafa",
                Paridade = "faf",
                XonXoff = "faga",
                Maquina = "faga",
                SeparadorDecimal = "agmaog",
                Opcoes = "agfaga",
                DescricaoModelo = "gagaga"
            };
        }

        public static Balanca MontaObjetoPortaComVazia()
        {
            return new Balanca()
            {
                Id = 1,
                Modelo = "Teste Mock 1",
                PortaCom = null,
                BitsPorSegundo = "dad",
                Dtr = "fafa",
                BitsDeDados = "fagag",
                Rts = "fafa",
                Paridade = "faf",
                XonXoff = "faga",
                Maquina = "faga",
                SeparadorDecimal = "agmaog",
                Opcoes = "agfaga",
                DescricaoModelo = "gagaga"
            };
        }

        public static List<Balanca> MontaListaItems()
        {
            return new List<Balanca>()
            {
                new Balanca ()
                {
                    Id = 1,
                    Modelo = "Teste Mock 1",
                    PortaCom = "Teste 1",
                    BitsPorSegundo = "dad",
                    Dtr = "fafa",
                    BitsDeDados = "fagag",
                    Rts = "fafa",
                    Paridade = "faf",
                    XonXoff = "faga",
                    Maquina = "faga",
                    SeparadorDecimal = "agmaog",
                    Opcoes = "agfaga",
                    DescricaoModelo = "gagaga"
                },
                new Balanca ()
                {
                    Id = 2,
                    Modelo = "Teste Mock 2",
                    PortaCom = "Teste 2",
                    BitsPorSegundo = "dad",
                    Dtr = "fafa",
                    BitsDeDados = "fagag",
                    Rts = "fafa",
                    Paridade = "faf",
                    XonXoff = "faga",
                    Maquina = "faga",
                    SeparadorDecimal = "agmaog",
                    Opcoes = "agfaga",
                    DescricaoModelo = "gagaga"
                },
                new Balanca ()
                {
                    Id = 3,
                    Modelo = "Teste Mock 3",
                    PortaCom = "Teste 3",
                    BitsPorSegundo = "dad",
                    Dtr = "fafa",
                    BitsDeDados = "fagag",
                    Rts = "fafa",
                    Paridade = "faf",
                    XonXoff = "faga",
                    Maquina = "faga",
                    SeparadorDecimal = "agmaog",
                    Opcoes = "agfaga",
                    DescricaoModelo = "gagaga"
                },
            };
        }
    }
}
