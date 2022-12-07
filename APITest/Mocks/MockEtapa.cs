using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockEtapa
    {
        public static Etapa MontaObjetoUnico()
        {
            var etapa = new Etapa
            {
                Id = 1,
                Descricao = "Teste Mock",
                Sequencia = 12,
                Obrigatoria = "Não",
                Processo = "Teste",
                TempoMaximo = TimeSpan.FromMinutes(1),
            };
            etapa.Tipo = "Teste Tipo";
            return etapa;
        }
        public static Etapa MontaObjetoDescricoVazio()
        {
            var etapa = new Etapa
            {
                Id = 1,
                Descricao = "",
                Sequencia = 12,
                Obrigatoria = "Não",
                Processo = "Teste",
                TempoMaximo = TimeSpan.FromMinutes(1),
            };
            etapa.Tipo = "Teste Tipo";
            return etapa;
        }
        public static Etapa MontaObjetoSequenciaZero()
        {
            var etapa = new Etapa
            {
                Id = 1,
                Descricao = "Teste Mock",
                Sequencia = 0,
                Obrigatoria = "Não",
                Processo = "Teste",
                TempoMaximo = TimeSpan.FromMinutes(1),
            };
            etapa.Tipo = "Teste Tipo";
            return etapa;
        }
        public static Etapa MontaObjetoTipoVazio()
        {
            var etapa = new Etapa
            {
                Id = 1,
                Descricao = "Teste Mock",
                Sequencia = 2,
                Obrigatoria = "Não",
                Processo = "Teste",
                TempoMaximo = TimeSpan.FromMinutes(1),
            };
            etapa.Tipo = "";
            return etapa;
        }
        public static List<Etapa> MontaListaItens()
        {
            return new List<Etapa>
            {
                new Etapa
                {
                    Id = 1,
                    Descricao = "Teste Mock",
                    Sequencia = 2,
                    Obrigatoria = "Não",
                    Processo = "Teste",
                    TempoMaximo = TimeSpan.FromMinutes(1),
                },
                new Etapa
                {
                    Id = 2,
                    Descricao = "Teste Mock2",
                    Sequencia = 2,
                    Obrigatoria = "Não",
                    Processo = "Teste",
                    TempoMaximo = TimeSpan.FromMinutes(2),
                },
                new Etapa
                {
                    Id = 3,
                    Descricao = "Teste Mock3",
                    Sequencia = 3,
                    Obrigatoria = "Não",
                    Processo = "Teste",
                    TempoMaximo = TimeSpan.FromMinutes(3),
                },
            };
        }
    }
}
