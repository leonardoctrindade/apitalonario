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
    public class ListaControladoTest
    {
        public Mock<IListaControlado> mock = new Mock<IListaControlado>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockListaControlado.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<ListaControlado>())).Returns(Task.CompletedTask);

            var service = new ListaControladoApiController(mock.Object);
            await service.AdicionarListaControlado(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Codigo_Nao_Preenchido()
        {
            var modelo = MockListaControlado.MontaObjetoCodigoVazio();
            var apiController = new ListaControladoApiController(mock.Object);
            var result = await apiController.AdicionarListaControlado(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var modelo = MockListaControlado.MontaObjetoDescricaoVazia();
            var apiController = new ListaControladoApiController(mock.Object);
            var result = await apiController.AdicionarListaControlado(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockListaControlado.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<ListaControlado>())).Returns(Task.CompletedTask);

            var service = new ListaControladoApiController(mock.Object);
            await service.EditarListaControlado(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockListaControlado.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<ListaControlado>())).Returns(Task.CompletedTask);

            var service = new ListaControladoApiController(mock.Object);
            await service.ExcluirListaControlado(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockListaControlado.MontaObjetoUnico().Id)).ReturnsAsync(MockListaControlado.MontaObjetoUnico());
            ListaControladoApiController ret = new ListaControladoApiController(mock.Object);
            var result = await ret.RetornaListaControladoPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.ListaControlado)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockListaControlado.MontaListaItems());
            var controller = new ListaControladoApiController(mock.Object);
            var result = await controller.ListaListaControlado();
            var viewResult = Assert.IsType<List<ListaControlado>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
