using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public class MockNcm
    {
        public static Ncm MontaObjetoUnico()
        {
            return new Ncm
            {
                Id = 1,
                ProdutoServico = false,
                Descricao = "Teste 1",
                CodigoNcm = "Teste Mock 1",
                CodigoNcmEx = 1,
                PercentualMva = 1.1,
                AliquotaNacional = 1.1,
                AliquotaImportacao = 1.1,
                AliquotaCofins = 1.1,
                AliquotaIcmsProduto = 1.1,
                AliquotaPis = 1.1,
                TributoCstCofinsEntradaId = 1,
                TributoCstPisEntradaId = 1,
                TributoCstCofinsSaidaId = 1,
                TributoCstPisSaidaId = 1
            };
        }

        public static Ncm MontaObjetoDescricaoVazia()
        {
            return new Ncm
            {
                Id = 1,
                ProdutoServico = false,
                Descricao = null,
                CodigoNcm = "Teste Mock 1",
                CodigoNcmEx = 1,
                PercentualMva = 1.1,
                AliquotaNacional = 1.1,
                AliquotaImportacao = 1.1,
                AliquotaCofins = 1.1,
                AliquotaIcmsProduto = 1.1,
                AliquotaPis = 1.1,
                TributoCstCofinsEntradaId = 1,
                TributoCstPisEntradaId = 1,
                TributoCstCofinsSaidaId = 1,
                TributoCstPisSaidaId = 1
            };
        }

        public static Ncm MontaObjetoCodigoNcmVazio()
        {
            return new Ncm
            {
                Id = 1,
                ProdutoServico = false,
                Descricao = "Teste 1",
                CodigoNcm = null,
                CodigoNcmEx = 1,
                PercentualMva = 1.1,
                AliquotaNacional = 1.1,
                AliquotaImportacao = 1.1,
                AliquotaCofins = 1.1,
                AliquotaIcmsProduto = 1.1,
                AliquotaPis = 1.1,
                TributoCstCofinsEntradaId = 1,
                TributoCstPisEntradaId = 1,
                TributoCstCofinsSaidaId = 1,
                TributoCstPisSaidaId = 1
            };
        }

        public static List<Ncm> MontaListaItems()
        {
            return new List<Ncm>
            {
                MontaObjetoUnico(),
                new Ncm() {Id = 2,ProdutoServico = false,Descricao = "Teste 2",CodigoNcm = "Teste Mock 2",
                    CodigoNcmEx = 1,PercentualMva = 1.1,AliquotaNacional = 1.1,AliquotaImportacao = 1.1,
                    AliquotaCofins = 1.1,AliquotaIcmsProduto = 1.1,AliquotaPis = 1.1,TributoCstCofinsEntradaId = 1,
                    TributoCstPisEntradaId = 1,TributoCstCofinsSaidaId = 1,TributoCstPisSaidaId = 1 },
                new Ncm() {Id = 3,ProdutoServico = false,Descricao = "Teste 3",CodigoNcm = "Teste Mock 3",
                    CodigoNcmEx = 1,PercentualMva = 1.1,AliquotaNacional = 1.1,AliquotaImportacao = 1.1,
                    AliquotaCofins = 1.1,AliquotaIcmsProduto = 1.1,AliquotaPis = 1.1,TributoCstCofinsEntradaId = 1,
                    TributoCstPisEntradaId = 1,TributoCstCofinsSaidaId = 1,TributoCstPisSaidaId = 1 }
            };
        }
    }
}
