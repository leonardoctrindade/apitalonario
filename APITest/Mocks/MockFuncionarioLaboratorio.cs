using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

namespace APITest.Mocks
{
    public static class MockFuncionarioLaboratorio
    {
        public static FuncionarioLaboratorio MontaObjetoUnico()
        {
            return new FuncionarioLaboratorio { Id = 1, Nome = "Teste Mock 1", Ativo = true };
        }

        public static FuncionarioLaboratorio MontaObjetoNomeVazio()
        {
            return new FuncionarioLaboratorio { Id = 1, Nome = null, Ativo = true };
        }

        public static List<FuncionarioLaboratorio> MontaListaItems()
        {
            return new List<FuncionarioLaboratorio>()
            {
                new FuncionarioLaboratorio() { Id = 1, Nome = "Teste Mock 1", Ativo = true },
                new FuncionarioLaboratorio() { Id = 2, Nome = "Teste Mock 2", Ativo = false },
                new FuncionarioLaboratorio() { Id = 3, Nome = "Teste Mock 3", Ativo = true }
            };
        }
    }
}
