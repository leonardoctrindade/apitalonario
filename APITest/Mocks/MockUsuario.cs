using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockUsuario
    {
        public static Usuario MontaObjetoUnico()
        {
            return new Usuario
            {
                Id = 1,
                NomeAbreviado = "Teste Mock 1",
                GrupoUsuarioId = 1,
                Nome = "Teste Mock 1",
                Senha = "prixpto",
                Nivel = 1,
                Logon = true,
                Email = "teste@prismafive.com.br",
                Ativo = true,
                LidoNovidade = true,
                HoraUltimoAcesso = DateTime.Now,
                DataUltimoAcesso = DateTime.Now,
                DataTrocaSenha = DateTime.Now,
                FilialUsuarioId = 1,
                FilialProducaoId = 1
            };
        }

        public static Usuario MontaObjetoNomeAbreviadoVazio()
        {
            return new Usuario
            {
                Id = 1,
                NomeAbreviado = null,
                GrupoUsuarioId = 1,
                Nome = "Teste Mock 1",
                Senha = "prixpto",
                Nivel = 1,
                Logon = true,
                Email = "teste@prismafive.com.br",
                Ativo = true,
                LidoNovidade = true,
                HoraUltimoAcesso = DateTime.Now,
                DataUltimoAcesso = DateTime.Now,
                DataTrocaSenha = DateTime.Now,
                FilialUsuarioId = 1,
                FilialProducaoId = 1
            };
        }

        public static Usuario MontaObjetoNomeVazio()
        {
            return new Usuario
            {
                Id = 1,
                NomeAbreviado = "Teste Mock 1",
                GrupoUsuarioId = 1,
                Nome = null,
                Senha = "prixpto",
                Nivel = 1,
                Logon = true,
                Email = "teste@prismafive.com.br",
                Ativo = true,
                LidoNovidade = true,
                HoraUltimoAcesso = DateTime.Now,
                DataUltimoAcesso = DateTime.Now,
                DataTrocaSenha = DateTime.Now,
                FilialUsuarioId = 1,
                FilialProducaoId = 1
            };
        }

        public static Usuario MontaObjetoSenhaVazia()
        {
            return new Usuario
            {
                Id = 1,
                NomeAbreviado = "Teste Mock 1",
                GrupoUsuarioId = 1,
                Nome = "Teste Mock 1",
                Senha = null,
                Nivel = 1,
                Logon = true,
                Email = "teste@prismafive.com.br",
                Ativo = true,
                LidoNovidade = true,
                HoraUltimoAcesso = DateTime.Now,
                DataUltimoAcesso = DateTime.Now,
                DataTrocaSenha = DateTime.Now,
                FilialUsuarioId = 1,
                FilialProducaoId = 1
            };
        }

        public static Usuario MontaObjetoIdGrupoUsuarioInvalido()
        {
            return new Usuario
            {
                Id = 1,
                NomeAbreviado = "Teste Mock 1",
                GrupoUsuarioId = 0,
                Nome = "Teste Mock 1",
                Senha = "prixpto",
                Nivel = 1,
                Logon = true,
                Email = "teste@prismafive.com.br",
                Ativo = true,
                LidoNovidade = true,
                HoraUltimoAcesso = DateTime.Now,
                DataUltimoAcesso = DateTime.Now,
                DataTrocaSenha = DateTime.Now,
                FilialUsuarioId = 1,
                FilialProducaoId = 1
            };
        }

        public static List<Usuario> MontaListaItems()
        {
            return new List<Usuario>()
            {
                new Usuario ()
                {
                    Id = 1,
                    NomeAbreviado = "Teste Mock 1",
                    GrupoUsuarioId = 1,
                    Nome = "Teste Mock 1",
                    Senha = "prixpto",
                    Nivel = 1,
                    Logon = true,
                    Email = "teste@prismafive.com.br",
                    Ativo = true,
                    LidoNovidade = true,
                    HoraUltimoAcesso = DateTime.Now,
                    DataUltimoAcesso = DateTime.Now,
                    DataTrocaSenha = DateTime.Now,
                    FilialUsuarioId = 1,
                    FilialProducaoId = 1
                },
                new Usuario ()
                {
                    Id = 2,
                    NomeAbreviado = "Teste Mock 2",
                    GrupoUsuarioId = 2,
                    Nome = "Teste Mock 2",
                    Senha = "prixpto",
                    Nivel = 2,
                    Logon = true,
                    Email = "teste@prismafive.com.br",
                    Ativo = true,
                    LidoNovidade = true,
                    HoraUltimoAcesso = DateTime.Now,
                    DataUltimoAcesso = DateTime.Now,
                    DataTrocaSenha = DateTime.Now,
                    FilialUsuarioId = 2,
                    FilialProducaoId = 2
                },
                new Usuario ()
                {
                    Id = 3,
                    NomeAbreviado = "Teste Mock 3",
                    GrupoUsuarioId = 3,
                    Nome = "Teste Mock 3",
                    Senha = "prixpto",
                    Nivel = 3,
                    Logon = true,
                    Email = "teste@prismafive.com.br",
                    Ativo = true,
                    LidoNovidade = true,
                    HoraUltimoAcesso = DateTime.Now,
                    DataUltimoAcesso = DateTime.Now,
                    DataTrocaSenha = DateTime.Now,
                    FilialUsuarioId = 3,
                    FilialProducaoId = 3
                }
            };
        }
    }
}
