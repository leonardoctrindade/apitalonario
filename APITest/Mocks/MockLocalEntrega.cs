﻿using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockLocalEntrega
    {
        public static LocalEntrega MontaObjetoUnico()
        {
            return new LocalEntrega { Id = 1, Codigo = 1, Descricao = "Teste Mock 1", Ativo = true, TaxaEntrega = 123, NcmId = 1, AliquotaIss = 1414, CfopId = 1, EntregadorId = 1, CstId = 1, CsosnId = 1, CodigoBeneficioFiscalId = 1 };
        }

        public static LocalEntrega MontaObjetoDescricaoVazia()
        {
            return new LocalEntrega { Id = 1, Codigo = 1, Descricao = null, Ativo = true, TaxaEntrega = 123, NcmId = 1, AliquotaIss = 1414, CfopId = 1, EntregadorId = 1, CstId = 1, CsosnId = 1, CodigoBeneficioFiscalId = 1 };
        }

        public static LocalEntrega MontaObjetoTaxaEntregaInvalida()
        {
            return new LocalEntrega { Id = 1, Codigo = 1, Descricao = "Teste Mock 1", Ativo = true, TaxaEntrega = 0, NcmId = 1, AliquotaIss = 1414, CfopId = 1, EntregadorId = 1, CstId = 1, CsosnId = 1, CodigoBeneficioFiscalId = 1 };
        }

        public static List<LocalEntrega> MontaListaItems()
        {
            return new List<LocalEntrega>()
            {
                new LocalEntrega() { Id = 1, Codigo = 1, Descricao = "Teste Mock 1", Ativo = true, TaxaEntrega = 123, NcmId = 1, AliquotaIss = 1414, CfopId = 1, EntregadorId = 1, CstId = 1, CsosnId = 1, CodigoBeneficioFiscalId = 1 },
                new LocalEntrega() { Id = 2, Codigo = 2, Descricao = "Teste Mock 2", Ativo = false, TaxaEntrega = 123, NcmId = 1, AliquotaIss = 1414, CfopId = 1, EntregadorId = 1, CstId = 1, CsosnId = 1, CodigoBeneficioFiscalId = 1 },
                new LocalEntrega() { Id = 3, Codigo = 3, Descricao = "Teste Mock 3", Ativo = true, TaxaEntrega = 123, NcmId = 1, AliquotaIss = 1414, CfopId = 1, EntregadorId = 1, CstId = 1, CsosnId = 1, CodigoBeneficioFiscalId = 1 }
            };
        }
    }
}
