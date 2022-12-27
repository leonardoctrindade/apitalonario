using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace APITest.Mocks
{
    public static class MockVendedorComissao
    {
        public static VendedorComissao MontaObjetoUnico()
        {
            return new VendedorComissao { Id = 1, CodigoGrupo = 1, Comissao = 55, VendedorId = 1 };
        }

        public static List<VendedorComissao> MontaListaItems()
        {
            return new List<VendedorComissao>()
            {
                new VendedorComissao() { Id = 1, CodigoGrupo = 1, Comissao = 55, VendedorId = 1 },
                new VendedorComissao() { Id = 2, CodigoGrupo = 2, Comissao = 55, VendedorId = 2 },
                new VendedorComissao() { Id = 3, CodigoGrupo = 3, Comissao = 55, VendedorId = 3 }
            };
        }
    }
}
