using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace APITest.Mocks
{
    public static class MockDiasHoras
    {
        public static DiasHoras MontaObjetoUnico()
        {
            return new DiasHoras { Id = 1, DiaSemana = "Sexta", HoraInicial = DateTime.Now, HoraFinal = DateTime.Now, Hash = "damag", Quantidade = 1, CodigoDia = 1, Sequencia = 1 };
        }

        public static DiasHoras MontaObjetoCodigoDiaVazio()
        {
            return new DiasHoras { Id = 1, DiaSemana = "Sexta", HoraInicial = DateTime.Now, HoraFinal = DateTime.Now, Hash = "damag", Quantidade = 1, CodigoDia = -1, Sequencia = 1 };
        }

        public static DiasHoras MontaObjetoSequenciaVazio()
        {
            return new DiasHoras { Id = 1, DiaSemana = "Sexta", HoraInicial = DateTime.Now, HoraFinal = DateTime.Now, Hash = "damag", Quantidade = 1, CodigoDia = 1, Sequencia = -1 };
        }

        public static List<DiasHoras> MontaListaItems()
        {
            return new List<DiasHoras>
            {
                new DiasHoras() { Id = 1, DiaSemana = "Sexta", HoraInicial = DateTime.Now, HoraFinal = DateTime.Now, Hash = "damag", Quantidade = 1, CodigoDia = 1, Sequencia = 1 },
                new DiasHoras() { Id = 2, DiaSemana = "Sexta", HoraInicial = DateTime.Now, HoraFinal = DateTime.Now, Hash = "damag", Quantidade = 2, CodigoDia = 2, Sequencia = 2 },
                new DiasHoras() { Id = 3, DiaSemana = "Sexta", HoraInicial = DateTime.Now, HoraFinal = DateTime.Now, Hash = "damag", Quantidade = 3, CodigoDia = 3, Sequencia = 3 }
            };
        }
    }
}
