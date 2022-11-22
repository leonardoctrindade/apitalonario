using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public class MockMoeda
    {
        public static Moeda MontaObjetoUnico()
        {
            return new Moeda { Id = 1, Nome = "Dólar" };
        }
        public static Moeda MontaObjetoNomeVazio()
        {
            return new Moeda { Id = 1, Nome = "" };
        }
        public static List<Moeda> MontaListaItens()
        {
            return new List<Moeda>
            {
                new Moeda{ Id = 1, Nome = "Real"},
                new Moeda{ Id = 2, Nome = "Dolar"},
                new Moeda{ Id = 3, Nome = "Euro"}
            };
        }
    }
}
