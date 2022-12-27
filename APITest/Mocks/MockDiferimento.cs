using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockDiferimento
    {
        public static Diferimento MontaObjetoUnico()
        {
            return new Diferimento { Id = 1, Icms = 1, AliquotaDiferimento = 1, Cst = "cst", SiglaEstado = "SC", FilialId = 1 };
        }

        public static Diferimento MontaObjetoAliquotaDiferimentoInvalido()
        {
            return new Diferimento { Id = 1, Icms = 1, AliquotaDiferimento = 0, Cst = "cst", SiglaEstado = "SC", FilialId = 1 };
        }

        public static Diferimento MontaObjetoCstNaoPreenchido()
        {
            return new Diferimento { Id = 1, Icms = 1, AliquotaDiferimento = 1, Cst = null, SiglaEstado = "SC", FilialId = 1 };
        }

        public static Diferimento MontaObjetoSiglaEstadoNaoPreenchido()
        {
            return new Diferimento { Id = 1, Icms = 1, AliquotaDiferimento = 1, Cst = "cst", SiglaEstado = null, FilialId = 1 };
        }

        public static List<Diferimento> MontaListaItems()
        {
            return new List<Diferimento>()
            {
                new Diferimento() { Id = 1, Icms = 1, AliquotaDiferimento = 1, Cst = "cst", SiglaEstado = "SC", FilialId = 1},
                new Diferimento() { Id = 2, Icms = 1, AliquotaDiferimento = 2, Cst = "cst", SiglaEstado = "SC", FilialId = 1},
                new Diferimento() { Id = 3, Icms = 1, AliquotaDiferimento = 3, Cst = "cst", SiglaEstado = "SC", FilialId = 1}
            };
        }
    }
}
