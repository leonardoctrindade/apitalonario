using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockEntregadorRegiao
    {
        public static EntregadorRegiao MontaObjetoUnico()
        {
            return new EntregadorRegiao { Id = 1, IdEntregador = 1, IdRegiao = 1 };
        }

        public static EntregadorRegiao MontaObjetoIdEntregadorInvalido()
        {
            return new EntregadorRegiao { Id = 1, IdEntregador = 0, IdRegiao = 1 };
        }

        public static EntregadorRegiao MontaObjetoIdRegiaoInvalido()
        {
            return new EntregadorRegiao { Id = 1, IdEntregador = 1, IdRegiao = 0 };
        }

        public static List<EntregadorRegiao> MontaListaItems()
        {
            return new List<EntregadorRegiao>()
            {
                new EntregadorRegiao() { Id = 1, IdEntregador = 1, IdRegiao = 1 },
                new EntregadorRegiao() { Id = 2, IdEntregador = 2, IdRegiao = 2 },
                new EntregadorRegiao() { Id = 3, IdEntregador = 3, IdRegiao = 3 }
            };
        }
    }
}
