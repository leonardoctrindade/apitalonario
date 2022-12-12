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
            return new Turno { Id = 1, HoraInicial = "08:00", HoraFinal = "18:00", IdFilial = 1 };
        }

        public static Turno MontaObjetoHoraInicialVazio()
        {
            return new Turno { Id = 1, HoraInicial = null, HoraFinal = "18:00", IdFilial = 1 };
        }

        public static Turno MontaObjetoHoraFinalVazio()
        {
            return new Turno { Id = 1, HoraInicial = "08:00", HoraFinal = null, IdFilial = 1 };
        }

        public static List<Turno> MontaListaItems()
        {
            return new List<Turno>()
            {
                new Turno() { Id = 1, HoraInicial = "08:00", HoraFinal = "18:00", IdFilial = 1 },
                new Turno() { Id = 2, HoraInicial = "09:00", HoraFinal = "19:00", IdFilial = 2 },
                new Turno() { Id = 3, HoraInicial = "10:00", HoraFinal = "20:00", IdFilial = 3 }
            };
        }
    }
}
