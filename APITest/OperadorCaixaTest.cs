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
    public class OperadorCaixaTest
    {
        public Mock<IOperadorCaixa> mock = new();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockOperadorCaixa.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<OperadorCaixa>())).Returns(Task.CompletedTask);

            var service = new OperadorCaixaApiController(mock.Object);
            await service.AdicionarOperadorCaixa(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockOperadorCaixa.MontaObjetoNomeVazio();
            var apiController = new OperadorCaixaApiController(mock.Object);
            var result = await apiController.AdicionarOperadorCaixa(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockOperadorCaixa.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<OperadorCaixa>())).Returns(Task.CompletedTask);

            var service = new OperadorCaixaApiController(mock.Object);
            await service.EditarOperadorCaixa(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockOperadorCaixa.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<OperadorCaixa>())).Returns(Task.CompletedTask);

            var service = new OperadorCaixaApiController(mock.Object);
            await service.ExcluirOperadorCaixa(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockOperadorCaixa.MontaObjetoUnico().Id)).ReturnsAsync(MockOperadorCaixa.MontaObjetoUnico());
            OperadorCaixaApiController ret = new OperadorCaixaApiController(mock.Object);
            var result = await ret.RetornaOperadorCaixaPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.OperadorCaixa)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockOperadorCaixa.MontaListaItems());
            var controller = new OperadorCaixaApiController(mock.Object);
            var result = await controller.ListaOperadorCaixa();
            var viewResult = Assert.IsType<List<OperadorCaixa>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
