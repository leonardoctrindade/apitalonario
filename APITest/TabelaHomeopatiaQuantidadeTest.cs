using Moq;
using Xunit;
using System;
using System.Text;
using System.Linq;
using APITest.Mocks;
using Data.Entidades;
using Data.Interfaces;
using WebAPI.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APITest
{
    public class TabelaHomeopatiaQuantidadeTest
    {
        public Mock<ITabelaHomeopatiaQuantidade> mock = new Mock<ITabelaHomeopatiaQuantidade>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockTabelaHomeopatiaQuantidade.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<TabelaHomeopatiaQuantidade>())).Returns(Task.CompletedTask);

            var service = new TabelaHomeopatiaQuantidadeApiController(mock.Object);
            await service.AdicionarTabelaHomeopatiaQuantidade(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Metodo_Nao_Preenchido()
        {
            var modelo = MockTabelaHomeopatiaQuantidade.MontaObjetoMetodoVazio();
            var apiController = new TabelaHomeopatiaQuantidadeApiController(mock.Object);
            var result = await apiController.AdicionarTabelaHomeopatiaQuantidade(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_DinamizacaoInicial_Invalida()
        {
            var modelo = MockTabelaHomeopatiaQuantidade.MontaObjetoDinamizacaoInicialInvalida();
            var apiController = new TabelaHomeopatiaQuantidadeApiController(mock.Object);
            var result = await apiController.AdicionarTabelaHomeopatiaQuantidade(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_DinamizacaoFinal_Invalida()
        {
            var modelo = MockTabelaHomeopatiaQuantidade.MontaObjetoDinamizacaoFinalInvalida();
            var apiController = new TabelaHomeopatiaQuantidadeApiController(mock.Object);
            var result = await apiController.AdicionarTabelaHomeopatiaQuantidade(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_QuantidadeInicial_Invalida()
        {
            var modelo = MockTabelaHomeopatiaQuantidade.MontaObjetoQuantidadeInicialInvalida();
            var apiController = new TabelaHomeopatiaQuantidadeApiController(mock.Object);
            var result = await apiController.AdicionarTabelaHomeopatiaQuantidade(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_QuantidadeFinal_Invalida()
        {
            var modelo = MockTabelaHomeopatiaQuantidade.MontaObjetoQuantidadeFinalInvalida();
            var apiController = new TabelaHomeopatiaQuantidadeApiController(mock.Object);
            var result = await apiController.AdicionarTabelaHomeopatiaQuantidade(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_ValorVenda_Invalido()
        {
            var modelo = MockTabelaHomeopatiaQuantidade.MontaObjetoValorVendaInvalido();
            var apiController = new TabelaHomeopatiaQuantidadeApiController(mock.Object);
            var result = await apiController.AdicionarTabelaHomeopatiaQuantidade(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_ValorAdicional_Invalido()
        {
            var modelo = MockTabelaHomeopatiaQuantidade.MontaObjetoValorAdicionalInvalido();
            var apiController = new TabelaHomeopatiaQuantidadeApiController(mock.Object);
            var result = await apiController.AdicionarTabelaHomeopatiaQuantidade(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockTabelaHomeopatiaQuantidade.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<TabelaHomeopatiaQuantidade>())).Returns(Task.CompletedTask);

            var service = new TabelaHomeopatiaQuantidadeApiController(mock.Object);
            await service.EditarTabelaHomeopatiaQuantidade(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockTabelaHomeopatiaQuantidade.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<TabelaHomeopatiaQuantidade>())).Returns(Task.CompletedTask);

            var service = new TabelaHomeopatiaQuantidadeApiController(mock.Object);
            await service.ExcluirTabelaHomeopatiaQuantidade(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockTabelaHomeopatiaQuantidade.MontaObjetoUnico().Id)).ReturnsAsync(MockTabelaHomeopatiaQuantidade.MontaObjetoUnico());
            TabelaHomeopatiaQuantidadeApiController ret = new TabelaHomeopatiaQuantidadeApiController(mock.Object);
            var result = await ret.RetornaTabelaHomeopatiaQuantidadePorId(1);
            Assert.Equal("Teste 1", ((Data.Entidades.TabelaHomeopatiaQuantidade)result.Value).Metodo);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockTabelaHomeopatiaQuantidade.MontaListaItems());
            var controller = new TabelaHomeopatiaQuantidadeApiController(mock.Object);
            var result = await controller.ListaTabelaHomeopatiaQuantidade();
            var viewResult = Assert.IsType<List<TabelaHomeopatiaQuantidade>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
