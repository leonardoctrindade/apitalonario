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
    public class FormaPagamentoTest
    {
        public Mock<IFormaPagamento> mock = new Mock<IFormaPagamento>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockFormaPagamento.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<FormaPagamento>())).Returns(Task.CompletedTask);

            var service = new FormaPagamentoApiController(mock.Object);
            await service.AdicionarFormaPagamento(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var modelo = MockFormaPagamento.MontaObjetoDescricaoVazio();
            var apiController = new FormaPagamentoApiController(mock.Object);
            var result = await apiController.AdicionarFormaPagamento(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockFormaPagamento.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<FormaPagamento>())).Returns(Task.CompletedTask);

            var service = new FormaPagamentoApiController(mock.Object);
            await service.EditarFormaPagamento(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockFormaPagamento.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<FormaPagamento>())).Returns(Task.CompletedTask);

            var service = new FormaPagamentoApiController(mock.Object);
            await service.ExcluirFormaPagamento(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockFormaPagamento.MontaObjetoUnico().Id)).ReturnsAsync(MockFormaPagamento.MontaObjetoUnico());
            FormaPagamentoApiController ret = new FormaPagamentoApiController(mock.Object);
            var result = await ret.RetornaFormaPagamentoPorId(1);
            //Assert.Equal("Teste Mock 1", ((Data.Entidades.FormaPagamento)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockFormaPagamento.MontaListaItems());
            var controller = new FormaPagamentoApiController(mock.Object);
            var result = await controller.ListaFormaPagamento();
            var viewResult = Assert.IsType<List<FormaPagamento>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
