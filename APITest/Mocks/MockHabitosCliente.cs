using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockHabitosCliente
    {
        public static HabitosCliente MontaObjetoUnico()
        {
            return new HabitosCliente { Id = 1, TempoFumante = "Teste Mock 1", Fumante = true, BebidasAlcolicas = "Teste Mock 1", OutrosHabitos = "Teste Mock 1", ClienteId = 1 };
        }

        public static HabitosCliente MontaObjetoClienteIdInvalido()
        {
            return new HabitosCliente { Id = 1, TempoFumante = "Teste Mock 1", Fumante = true, BebidasAlcolicas = "Teste Mock 1", OutrosHabitos = "Teste Mock 1", ClienteId = 0 };
        }

        public static List<HabitosCliente> MontaListaItems()
        {
            return new List<HabitosCliente>()
            {
                new HabitosCliente() { Id = 1, TempoFumante = "Teste Mock 1", Fumante = true, BebidasAlcolicas = "Teste Mock 1", OutrosHabitos = "Teste Mock 1", ClienteId = 1 },
                new HabitosCliente() { Id = 2, TempoFumante = "Teste Mock 2", Fumante = false, BebidasAlcolicas = "Teste Mock 2", OutrosHabitos = "Teste Mock 2", ClienteId = 2 },
                new HabitosCliente() { Id = 3, TempoFumante = "Teste Mock 3", Fumante = true, BebidasAlcolicas = "Teste Mock 3", OutrosHabitos = "Teste Mock 3", ClienteId = 3 },
            };
        }
    }
}
