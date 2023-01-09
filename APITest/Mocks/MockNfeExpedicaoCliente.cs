using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockNfeExpedicaoCliente
    {
        public static NfeExpedicaoCliente MontaObjetoUnico()
        {
            return new NfeExpedicaoCliente { Id = 1, EstadoEmbarqueId = 1, LocalEmbarque = "Teste Mock 1", RegimeTributacao = TipoRegimeTributacao.SimplesNacional, ClienteId = 1 };
        }

        public static NfeExpedicaoCliente MontaObjetoClienteIdInvalido()
        {
            return new NfeExpedicaoCliente { Id = 1, EstadoEmbarqueId = 1, LocalEmbarque = "Teste Mock 1", RegimeTributacao = TipoRegimeTributacao.SimplesNacional, ClienteId = 0 };
        }

        public static List<NfeExpedicaoCliente> MontaListaItems()
        {
            return new List<NfeExpedicaoCliente>()
            {
                new NfeExpedicaoCliente() { Id = 1, EstadoEmbarqueId = 1, LocalEmbarque = "Teste Mock 1", RegimeTributacao = TipoRegimeTributacao.SimplesNacional, ClienteId = 1 },
                new NfeExpedicaoCliente() { Id = 2, EstadoEmbarqueId = 2, LocalEmbarque = "Teste Mock 2", RegimeTributacao = TipoRegimeTributacao.SimplesNacionalSubLimite, ClienteId = 2 },
                new NfeExpedicaoCliente() { Id = 3, EstadoEmbarqueId = 3, LocalEmbarque = "Teste Mock 3", RegimeTributacao = TipoRegimeTributacao.RegimeNormal, ClienteId = 3 }
            };
        }
    }
}
