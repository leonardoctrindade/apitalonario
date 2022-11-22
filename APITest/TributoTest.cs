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
   /*public class TributoTest
   {
        public Mock<ITributo> mock = new();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockTributo.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Tributo>())).Returns(Task.CompletedTask);

            var service = new TributoApiController(mock.Object);
            await service.AdicionarTributo(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task InsereTipoNaoPreenchido()
        {
            var modelo = MockTributo.MontaObjetoTipoVazio();
            var apiController = new TributoApiController(mock.Object);
            var result = await apiController.AdicionarTributo(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task InsereCodigoNaoPreenchido()
        {
            var modelo = MockTributo.MontaObjetoCodigoVazio();
            var apiController = new TributoApiController(mock.Object);
            var result = await apiController.AdicionarTributo(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task InsereDescricaoNaoPreenchido()
        {
            var modelo = MockTributo.MontaObjetoDescricaoVazio();
            var apiController = new TributoApiController(mock.Object);
            var result = await apiController.AdicionarTributo(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockTributo.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Tributo>())).Returns(Task.CompletedTask);

            var service = new TributoApiController(mock.Object);
            await service.EditarTributo(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockTributo.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Tributo>())).Returns(Task.CompletedTask);

            var service = new TributoApiController(mock.Object);
            await service.ExcluirTributo(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockTributo.MontaObjetoUnico().Id)).ReturnsAsync(MockTributo.MontaObjetoUnico());
            TributoApiController ret = new(mock.Object);
            var result = await ret.RetornaTributoPorId(1);
            Assert.Equal("Teste 1", ((Data.Entidades.Tributo)result.Value).Codigo);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockTributo.MontaListaItems());
            var controller = new TributoApiController(mock.Object);
            var result = await controller.ListaTributo();
            var viewResult = Assert.IsType<List<Tributo>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }*/
}
