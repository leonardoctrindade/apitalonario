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
    public class FidelidadeFormaPagamentoTest
    {
        public Mock<IFidelidadeFormaPagamento> mock = new Mock<IFidelidadeFormaPagamento>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockFidelidadeFormaPagamento.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<FidelidadeFormaPagamento>())).Returns(Task.CompletedTask);

            var service = new FidelidadeFormaPagamentoApiController(mock.Object);
            await service.AdicionarFidelidadeFormaPagamento(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_CodigoFidelidade_Invalido()
        {
            var modelo = MockFidelidadeFormaPagamento.MontaObjetoCodigoFidelidadeInvalido();
            var apiController = new FidelidadeFormaPagamentoApiController(mock.Object);
            var result = await apiController.AdicionarFidelidadeFormaPagamento(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_CodigoFormaPagamento_Invalido()
        {
            var modelo = MockFidelidadeFormaPagamento.MontaObjetoCodigoFormaPagamentoInvalido();
            var apiController = new FidelidadeFormaPagamentoApiController(mock.Object);
            var result = await apiController.AdicionarFidelidadeFormaPagamento(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Pontos_Invalido()
        {
            var modelo = MockFidelidadeFormaPagamento.MontaObjetoPontosInvalido();
            var apiController = new FidelidadeFormaPagamentoApiController(mock.Object);
            var result = await apiController.AdicionarFidelidadeFormaPagamento(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Valor_Invalido()
        {
            var modelo = MockFidelidadeFormaPagamento.MontaObjetoValorInvalido();
            var apiController = new FidelidadeFormaPagamentoApiController(mock.Object);
            var result = await apiController.AdicionarFidelidadeFormaPagamento(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockFidelidadeFormaPagamento.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<FidelidadeFormaPagamento>())).Returns(Task.CompletedTask);

            var service = new FidelidadeFormaPagamentoApiController(mock.Object);
            await service.EditarFidelidadeFormaPagamento(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockFidelidadeFormaPagamento.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<FidelidadeFormaPagamento>())).Returns(Task.CompletedTask);

            var service = new FidelidadeFormaPagamentoApiController(mock.Object);
            await service.ExcluirFidelidadeFormaPagamento(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockFidelidadeFormaPagamento.MontaObjetoUnico().Id)).ReturnsAsync(MockFidelidadeFormaPagamento.MontaObjetoUnico());
            FidelidadeFormaPagamentoApiController ret = new FidelidadeFormaPagamentoApiController(mock.Object);
            var result = await ret.RetornaFidelidadeFormaPagamentoPorId(1);
            Assert.Equal(0 , ((Data.Entidades.FidelidadeFormaPagamento)result.Value).Pontos);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockFidelidadeFormaPagamento.MontaListaItems());
            var controller = new FidelidadeFormaPagamentoApiController(mock.Object);
            var result = await controller.ListaFidelidadeFormaPagamento();
            var viewResult = Assert.IsType<List<FidelidadeFormaPagamento>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
