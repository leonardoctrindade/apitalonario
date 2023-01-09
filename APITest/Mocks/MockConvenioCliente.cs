using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockConvenioCliente
    {
        public static ConvenioCliente MontaObjetoUnico()
        {
            return new ConvenioCliente { Id = 1, DataCadastro = DateTime.Now, ConvenioId = 1, Numero = "Teste Mock 1", EmUso = true, Ativo = false, ClienteId = 1 };
        }

        public static ConvenioCliente MontaObjetoClienteIdInvalido()
        {
            return new ConvenioCliente { Id = 1, DataCadastro = DateTime.Now, ConvenioId = 1, Numero = "Teste Mock 1", EmUso = true, Ativo = false, ClienteId = 0 };
        }

        public static ConvenioCliente MontaObjetoConvenioIdInvalido()
        {
            return new ConvenioCliente { Id = 1, DataCadastro = DateTime.Now, ConvenioId = 0, Numero = "Teste Mock 1", EmUso = true, Ativo = false, ClienteId = 1 };
        }

        public static List<ConvenioCliente> MontaListaItems()
        {
            return new List<ConvenioCliente>()
            {
                new ConvenioCliente(){ Id = 1, DataCadastro = DateTime.Now, ConvenioId = 1, Numero = "Teste Mock 1", EmUso = true, Ativo = false, ClienteId = 1 },
                new ConvenioCliente(){ Id = 2, DataCadastro = DateTime.Now, ConvenioId = 2, Numero = "Teste Mock 2", EmUso = true, Ativo = false, ClienteId = 2 },
                new ConvenioCliente(){ Id = 3, DataCadastro = DateTime.Now, ConvenioId = 3, Numero = "Teste Mock 3", EmUso = true, Ativo = false, ClienteId = 3 }
            };
        }
    }
}
