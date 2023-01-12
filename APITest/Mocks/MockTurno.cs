using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace APITest.Mocks
{
    public static class MockTurno
    {
        public static Turno MontaObjetoUnico()
        {
            return new Turno { Id = 1, HoraInicial = DateTime.Now, HoraFinal = DateTime.Now, FilialId = 1 };
        }

        public static Turno MontaObjetoHoraInicialVazio()
        {
            return new Turno { Id = 1, HoraFinal = DateTime.Now, FilialId = 1 };
        }

        public static Turno MontaObjetoHoraFinalVazio()
        {
            return new Turno { Id = 1, HoraInicial = DateTime.Now, FilialId = 1 };
        }

        public static Turno MontaObjetoHoraInicialMaiorQueHoraFInal()
        {
            return new Turno { Id = 1, HoraInicial = DateTime.Now.AddHours(1), HoraFinal = DateTime.Now, FilialId = 1 };
        }

        public static List<Turno> MontaListaItems()
        {
            return new List<Turno>()
            {
                new Turno() { Id = 1, HoraInicial = DateTime.Now, HoraFinal = DateTime.Now, FilialId = 1 },
                new Turno() { Id = 2, HoraInicial = DateTime.Now, HoraFinal = DateTime.Now, FilialId = 2 },
                new Turno() { Id = 3, HoraInicial = DateTime.Now, HoraFinal = DateTime.Now, FilialId = 3 }
            };
        }
    }
}
