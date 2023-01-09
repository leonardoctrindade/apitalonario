using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit.Sdk;

namespace APITest.Mocks
{
    public static class MockPaciente
    {
        public static Paciente MontaObjetoUnico()
        {
            return new Paciente
            {
                Id = 1,
                Nome = "Teste Mock 1",
                DataNascimento = DateTime.Now,
                Genero = 1,
                CpfCnpj = "Teste Mock 1",
                Rg = "Teste Mock 1",
                OrgaoExpedidor = "Teste Mock 1",
                EstadoExpedidorId = 1,
                DataExpedicao = DateTime.Now,
                NomeRotulo = "Teste Mock 1",
                NaoAvisarUsoContinuo = true,
                Observacoes = "Teste Mock 1",
                PesoPaciente = 123,
                EspecieId = 1,
                ClienteId = 1,
                NumeroDocumento = "Teste Mock 1",
                Acao = 1
            };
        }

        public static Paciente MontaObjetoClienteIdInvalido()
        {
            return new Paciente
            {
                Id = 1,
                Nome = "Teste Mock 1",
                DataNascimento = DateTime.Now,
                Genero = 1,
                CpfCnpj = "Teste Mock 1",
                Rg = "Teste Mock 1",
                OrgaoExpedidor = "Teste Mock 1",
                EstadoExpedidorId = 1,
                DataExpedicao = DateTime.Now,
                NomeRotulo = "Teste Mock 1",
                NaoAvisarUsoContinuo = true,
                Observacoes = "Teste Mock 1",
                PesoPaciente = 123,
                EspecieId = 1,
                ClienteId = 0,
                NumeroDocumento = "Teste Mock 1",
                Acao = 1
            };
        }

        public static Paciente MontaObjetoNomeVazio()
        {
            return new Paciente
            {
                Id = 1,
                Nome = null,
                DataNascimento = DateTime.Now,
                Genero = 1,
                CpfCnpj = "Teste Mock 1",
                Rg = "Teste Mock 1",
                OrgaoExpedidor = "Teste Mock 1",
                EstadoExpedidorId = 1,
                DataExpedicao = DateTime.Now,
                NomeRotulo = "Teste Mock 1",
                NaoAvisarUsoContinuo = true,
                Observacoes = "Teste Mock 1",
                PesoPaciente = 123,
                EspecieId = 1,
                ClienteId = 1,
                NumeroDocumento = "Teste Mock 1",
                Acao = 1
            };
        }

        public static List<Paciente> MontaListaItems()
        {
            return new List<Paciente>()
            {
                new Paciente()
                {
                     Id = 1,
                    Nome = "Teste Mock 1",
                    DataNascimento = DateTime.Now,
                    Genero = 1,
                    CpfCnpj = "Teste Mock 1",
                    Rg = "Teste Mock 1",
                    OrgaoExpedidor = "Teste Mock 1",
                    EstadoExpedidorId = 1,
                    DataExpedicao = DateTime.Now,
                    NomeRotulo = "Teste Mock 1",
                    NaoAvisarUsoContinuo = true,
                    Observacoes = "Teste Mock 1",
                    PesoPaciente = 123,
                    EspecieId = 1,
                    ClienteId = 1,
                    NumeroDocumento = "Teste Mock 1",
                    Acao = 1
                },
                new Paciente()
                {
                     Id = 2,
                    Nome = "Teste Mock 2",
                    DataNascimento = DateTime.Now,
                    Genero = 2,
                    CpfCnpj = "Teste Mock 2",
                    Rg = "Teste Mock 2",
                    OrgaoExpedidor = "Teste Mock 2",
                    EstadoExpedidorId = 2,
                    DataExpedicao = DateTime.Now,
                    NomeRotulo = "Teste Mock 2",
                    NaoAvisarUsoContinuo = true,
                    Observacoes = "Teste Mock 2",
                    PesoPaciente = 123,
                    EspecieId = 2,
                    ClienteId = 2,
                    NumeroDocumento = "Teste Mock 2",
                    Acao = 2
                },
                new Paciente()
                {
                     Id = 3,
                    Nome = "Teste Mock 3",
                    DataNascimento = DateTime.Now,
                    Genero = 2,
                    CpfCnpj = "Teste Mock 3",
                    Rg = "Teste Mock 3",
                    OrgaoExpedidor = "Teste Mock 3",
                    EstadoExpedidorId = 3,
                    DataExpedicao = DateTime.Now,
                    NomeRotulo = "Teste Mock 3",
                    NaoAvisarUsoContinuo = true,
                    Observacoes = "Teste Mock 3",
                    PesoPaciente = 123,
                    EspecieId = 3,
                    ClienteId = 3,
                    NumeroDocumento = "Teste Mock 3",
                    Acao = 3
                },
            };
        }
    }
}
