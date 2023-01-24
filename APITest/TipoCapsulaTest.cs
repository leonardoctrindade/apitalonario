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
    public class TipoCapsulaTest
    {
        public Mock<ITipoCapsula> mock = new Mock<ITipoCapsula>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockTipoCapsula.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<TipoCapsula>())).Returns(Task.CompletedTask);

            var service = new TipoCapsulaApiController(mock.Object);
            await service.AdicionarTipoCapsula(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Vazia()
        {
            var modelo = MockTipoCapsula.MontaObjetoDescricaoVazia();
            var apiController = new TipoCapsulaApiController(mock.Object);
            var result = await apiController.AdicionarTipoCapsula(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockTipoCapsula.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<TipoCapsula>())).Returns(Task.CompletedTask);

            var service = new TipoCapsulaApiController(mock.Object);
            await service.EditarTipoCapsula(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockTipoCapsula.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<TipoCapsula>())).Returns(Task.CompletedTask);

            var service = new TipoCapsulaApiController(mock.Object);
            await service.ExcluirTipoCapsula(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockTipoCapsula.MontaObjetoUnico().Id)).ReturnsAsync(MockTipoCapsula.MontaObjetoUnico());
            TipoCapsulaApiController ret = new TipoCapsulaApiController(mock.Object);
            var result = await ret.RetornaTipoCapsulaPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.TipoCapsula)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockTipoCapsula.MontaListaItems());
            var controller = new TipoCapsulaApiController(mock.Object);
            var result = await controller.ListaTipoCapsula();
            var viewResult = Assert.IsType<List<TipoCapsula>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
