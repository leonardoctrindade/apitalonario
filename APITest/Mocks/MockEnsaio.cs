using System;
using System.Text;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace APITest.Mocks
{
    public static class MockEnsaio
    {
        public static Ensaio MontaObjetoUnico()
        { 
            return new Ensaio { Id = 1, Nome = "Teste Mock 1", FarmacopeiaId = 1};
        }

        public static Ensaio MontaObjetoNomeVazio()
        {
            return new Ensaio { Id = 1, Nome = null, FarmacopeiaId = 1};
        }

        public static List<Ensaio> MontaListaItems()
        {
            return new List<Ensaio>()
            {
                new Ensaio { Id = 1, Nome = "Teste Mock 1", FarmacopeiaId = 1 },
                new Ensaio { Id = 2, Nome = "Teste Mock 2", FarmacopeiaId = 1 },
                new Ensaio { Id = 3, Nome = "Teste Mock 3", FarmacopeiaId = 1 }
            };
        }
    }
}
