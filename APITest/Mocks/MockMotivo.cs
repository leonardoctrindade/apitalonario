using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockMotivo
    {
        public static Motivo MontaObjetoUnico()
        {
            return new Motivo { Id = 1, Descricao = "Motivo Mock" };
        }
        public static Motivo MontaObjetoDescricaoVazio()
        {
             return new Motivo { Id = 1, Descricao = "" };

        }
        public static List<Motivo> MontaListaItens()
        {
            return new List<Motivo>
            {
                new Motivo{ Id = 1, Descricao = "Motivo 1"},
                new Motivo{ Id = 2, Descricao = "Motivo 2"},
                new Motivo{ Id = 3, Descricao = "Motivo 3"}
            };
        }
    }
}
