using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Mocks
{
    public static class MockNbm
    {
        public static Nbm MontaObjetoUnico()
        {
            return new Nbm { Id = 1, CodigoNbm = "123", Descricao = "Teste Mock 1"
            , VlrAgregadoEst = 1.32, VlrComplementarEst = 2.51, VlrAgregadoInt = 5.45, VlrComplementarInt = 6.32};
        }
        public static Nbm MontaObjetoCodigoNbmVazio()
        {
            return new Nbm { Id = 1, CodigoNbm = "", Descricao = "Teste Mock 1" };
        }
        public static Nbm MontaObjetoDescricaoVazio()
        {
            return new Nbm { Id = 1, CodigoNbm = "123", Descricao = "" };
        }
        public static List<Nbm> MontaListaItens()
        {
            return new List<Nbm>(){
                new Nbm {Id = 1, CodigoNbm = "123", Descricao = "Teste Mock 1" },
                new Nbm {Id = 2, CodigoNbm = "1234", Descricao = "Teste Mock 2" },
                new Nbm {Id = 3, CodigoNbm = "12345", Descricao = "Teste Mock 3" }
            };
                
        }
    }
}
