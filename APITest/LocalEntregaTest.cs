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
    public class LocalEntregaTest
    {
        public Mock<ILocalEntrega> mock = new Mock<ILocalEntrega>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockLocalEntrega.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<LocalEntrega>())).Returns(Task.CompletedTask);

            var service = new LocalEntregaApiController(mock.Object);
            await service.AdicionarLocalEntrega(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var modelo = MockLocalEntrega.MontaObjetoDescricaoVazia();
            var apiController = new LocalEntregaApiController(mock.Object);
            var result = await apiController.AdicionarLocalEntrega(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_TaxaEntrega_Invalido()
        {
            var modelo = MockLocalEntrega.MontaObjetoTaxaEntregaInvalida();
            var apiController = new LocalEntregaApiController(mock.Object);
            var result = await apiController.AdicionarLocalEntrega(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockLocalEntrega.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<LocalEntrega>())).Returns(Task.CompletedTask);

            var service = new LocalEntregaApiController(mock.Object);
            await service.EditarLocalEntrega(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockLocalEntrega.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<LocalEntrega>())).Returns(Task.CompletedTask);

            var service = new LocalEntregaApiController(mock.Object);
            await service.ExcluirLocalEntrega(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockLocalEntrega.MontaObjetoUnico().Id)).ReturnsAsync(MockLocalEntrega.MontaObjetoUnico());
            LocalEntregaApiController ret = new LocalEntregaApiController(mock.Object);
            var result = await ret.RetornaLocalEntregaPorId(1);
            //Assert.Equal("Teste Mock 1", ((Data.Entidades.LocalEntrega)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockLocalEntrega.MontaListaItems());
            var controller = new LocalEntregaApiController(mock.Object);
            var result = await controller.ListaLocalEntrega();
            var viewResult = Assert.IsType<List<LocalEntrega>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
