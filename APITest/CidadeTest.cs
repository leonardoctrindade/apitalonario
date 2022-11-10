using Moq;
using Xunit;
using System;
using System.Linq;
using System.Text;
using APITest.Mocks;
using Data.Entidades;
using Data.Interfaces;
using WebAPI.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APITest
{
    public class CidadeTest
    {
        public Mock<ICidade> mock = new Mock<ICidade>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockCidade.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Cidade>())).Returns(Task.CompletedTask);

            var service = new CidadeApiController(mock.Object);
            await service.AdicionarCidade(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockCidade.MontaObjetoNomeVazio();
            var apiController = new CidadeApiController(mock.Object);
            var result = await apiController.AdicionarCidade(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockCidade.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Cidade>())).Returns(Task.CompletedTask);

            var service = new CidadeApiController(mock.Object);
            await service.EditarCidade(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockCidade.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Cidade>())).Returns(Task.CompletedTask);

            var service = new CidadeApiController(mock.Object);
            await service.ExcluirCidade(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockCidade.MontaObjetoUnico().Id)).ReturnsAsync(MockCidade.MontaObjetoUnico());
            CidadeApiController ret = new CidadeApiController(mock.Object);
            var result = await ret.RetornaCidadePorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Cidade)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockCidade.MontaListaItems());
            var controller = new CidadeApiController(mock.Object);
            var result = await controller.ListaCidade();
            var viewResult = Assert.IsType<List<Cidade>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
