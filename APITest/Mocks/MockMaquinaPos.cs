using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockMaquinaPos
    {
        public static MaquinaPos MontaObjetoUnico()
        {
            return new MaquinaPos { Id = 1, Descricao = "Teste Mock 1", SerialPos = "Teste 1", IdAdquirentePos = 1};
        }

        public static MaquinaPos MontaObjetoSerialPosVazio()
        {
            return new MaquinaPos { Id = 1, Descricao = "Teste Mock 1", SerialPos = null, IdAdquirentePos = 1 };
        }

        public static List<MaquinaPos> MontaListaItems()
        {
            return new List<MaquinaPos>()
            {
                new MaquinaPos() { Id = 1, Descricao = "Teste Mock 1", SerialPos = "Teste 1", IdAdquirentePos = 1 },
                new MaquinaPos() { Id = 2, Descricao = "Teste Mock 2", SerialPos = "Teste 2", IdAdquirentePos = 2 },
                new MaquinaPos() { Id = 3, Descricao = "Teste Mock 3", SerialPos = "Teste 3", IdAdquirentePos = 3 }
            };
        }
    }
}
