using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace APITest.Mocks
{
    public static class MockTipoCapsula
    {
        public static TipoCapsula MontaObjetoUnico()
        {
            return new TipoCapsula
            {
                Id = 1,
                Descricao = "Teste Mock 1",
                Numero = "Teste 1",
                VolumeInterno = 123,
                VolumeTotal = 123,
                Peso = 113,
                CapsulaPadraoId = 1,
                Inativo = true,
                GrupoCapsulasId = 1
            };
        }

        public static TipoCapsula MontaObjetoDescricaoVazia()
        {
            return new TipoCapsula
            {
                Id = 1,
                Descricao = null,
                Numero = "Teste 1",
                VolumeInterno = 123,
                VolumeTotal = 123,
                Peso = 113,
                CapsulaPadraoId = 1,
                Inativo = true,
                GrupoCapsulasId = 1
            };
        }

        public static List<TipoCapsula> MontaListaItems()
        {
            return new List<TipoCapsula>()
            {
                new TipoCapsula()
                {
                    Id = 1,
                    Descricao = "Teste Mock 1",
                    Numero = "Teste 1",
                    VolumeInterno = 123,
                    VolumeTotal = 123,
                    Peso = 113,
                    CapsulaPadraoId = 1,
                    Inativo = true,
                    GrupoCapsulasId = 1
                },
                new TipoCapsula()
                {
                    Id = 2,
                    Descricao = "Teste Mock 2",
                    Numero = "Teste 2",
                    VolumeInterno = 123,
                    VolumeTotal = 123,
                    Peso = 113,
                    CapsulaPadraoId = 2,
                    Inativo = true,
                    GrupoCapsulasId = 2
                },
                new TipoCapsula()
                {
                    Id = 3,
                    Descricao = "Teste Mock 3",
                    Numero = "Teste 3",
                    VolumeInterno = 123,
                    VolumeTotal = 123,
                    Peso = 113,
                    CapsulaPadraoId = 3,
                    Inativo = true,
                    GrupoCapsulasId = 3
                }
            };
        }
    }
}
