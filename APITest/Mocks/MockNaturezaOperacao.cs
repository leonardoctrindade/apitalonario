﻿using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockNaturezaOperacao
    {
        public static NaturezaOperacao MontaObjetoUnico()
        {
            return new NaturezaOperacao { Id = 1, Codigo = 565, Descricao = "Teste Mock 1", Tipo = 1, ExportarSintegra = true, Observacao = "Teste Mock 1", ExibeDocumentoReferenciado = true, ConsiderarCfopCreditoIcms = true, NaoInsidePis = true, NaoInsideCofins = true, NaoInsideIcms = true, CfopDevolucao = true, CfopSubstituicaoTributaria = true, PlanoDeContaId = 1, CstId = 1, CsosnId = 1};
        }

        public static NaturezaOperacao MontaObjetoDescricaoVazia()
        {
            return new NaturezaOperacao { Id = 1, Codigo = 565, Descricao = null, Tipo = 1, ExportarSintegra = true, Observacao = "Teste Mock 1", ExibeDocumentoReferenciado = true, ConsiderarCfopCreditoIcms = true, NaoInsidePis = true, NaoInsideCofins = true, NaoInsideIcms = true, CfopDevolucao = true, CfopSubstituicaoTributaria = true, PlanoDeContaId = 1, CstId = 1, CsosnId = 1 };
        }

        public static NaturezaOperacao MontaObjetoTipoInvalido()
        {
            return new NaturezaOperacao { Id = 1, Codigo = 565, Descricao = "Teste Mock 1", Tipo = 0, ExportarSintegra = true, Observacao = "Teste Mock 1", ExibeDocumentoReferenciado = true, ConsiderarCfopCreditoIcms = true, NaoInsidePis = true, NaoInsideCofins = true, NaoInsideIcms = true, CfopDevolucao = true, CfopSubstituicaoTributaria = true, PlanoDeContaId = 1, CstId = 1, CsosnId = 1 };
        }

        public static List<NaturezaOperacao> MontaListaItems()
        {
            return new List<NaturezaOperacao>()
            {
                new NaturezaOperacao() { Id = 1, Codigo = 565, Descricao = "Teste Mock 1", Tipo = 1, ExportarSintegra = true, Observacao = "Teste Mock 1", ExibeDocumentoReferenciado = true, ConsiderarCfopCreditoIcms = true, NaoInsidePis = true, NaoInsideCofins = true, NaoInsideIcms = true, CfopDevolucao = true, CfopSubstituicaoTributaria = true, PlanoDeContaId = 1, CstId = 1, CsosnId = 1 },
                new NaturezaOperacao() { Id = 2, Codigo = 565, Descricao = "Teste Mock 2", Tipo = 2, ExportarSintegra = true, Observacao = "Teste Mock 2", ExibeDocumentoReferenciado = true, ConsiderarCfopCreditoIcms = true, NaoInsidePis = true, NaoInsideCofins = true, NaoInsideIcms = true, CfopDevolucao = true, CfopSubstituicaoTributaria = true, PlanoDeContaId = 2, CstId = 2, CsosnId = 2 },
                new NaturezaOperacao() { Id = 3, Codigo = 565, Descricao = "Teste Mock 3", Tipo = 1, ExportarSintegra = true, Observacao = "Teste Mock 3", ExibeDocumentoReferenciado = true, ConsiderarCfopCreditoIcms = true, NaoInsidePis = true, NaoInsideCofins = true, NaoInsideIcms = true, CfopDevolucao = true, CfopSubstituicaoTributaria = true, PlanoDeContaId = 3, CstId = 3, CsosnId = 3 }
            };
        }
    }
}
