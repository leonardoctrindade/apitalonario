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
    public class BannerTest
    {
        public Mock<IBanner> mock = new Mock<IBanner>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockBanner.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Banner>())).Returns(Task.CompletedTask);

            var service = new BannerApiController(mock.Object);
            await service.AdicionarBanner(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Posicao_Invalida()
        {
            var modelo = MockBanner.MontaObjetoPosicaoInvalida();
            var apiController = new BannerApiController(mock.Object);
            var result = await apiController.AdicionarBanner(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Descrcao_Nao_Preenchido()
        {
            var modelo = MockBanner.MontaObjetoDescricaoVazia();
            var apiController = new BannerApiController(mock.Object);
            var result = await apiController.AdicionarBanner(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Link_Nao_Preenchido()
        {
            var modelo = MockBanner.MontaObjetoLinkVazio();
            var apiController = new BannerApiController(mock.Object);
            var result = await apiController.AdicionarBanner(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_AcaoLink_Invalida()
        {
            var modelo = MockBanner.MontaObjetoAcaoLinkInvalida();
            var apiController = new BannerApiController(mock.Object);
            var result = await apiController.AdicionarBanner(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_DataInicio_Nao_Preenchido()
        {
            var modelo = MockBanner.MontaObjetoDataInicioVazia();
            var apiController = new BannerApiController(mock.Object);
            var result = await apiController.AdicionarBanner(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_DataFim_Nao_Preenchido()
        {
            var modelo = MockBanner.MontaObjetoDataFimVazia();
            var apiController = new BannerApiController(mock.Object);
            var result = await apiController.AdicionarBanner(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockBanner.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Banner>())).Returns(Task.CompletedTask);

            var service = new BannerApiController(mock.Object);
            await service.EditarBanner(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockBanner.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Banner>())).Returns(Task.CompletedTask);

            var service = new BannerApiController(mock.Object);
            await service.ExcluirBanner(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockBanner.MontaObjetoUnico().Id)).ReturnsAsync(MockBanner.MontaObjetoUnico());
            BannerApiController ret = new BannerApiController(mock.Object);
            var result = await ret.RetornaBannerPorId(1);
            Assert.Equal(324 , ((Data.Entidades.Banner)result.Value).Posicao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockBanner.MontaListaItems());
            var controller = new BannerApiController(mock.Object);
            var result = await controller.ListaBanner();
            var viewResult = Assert.IsType<List<Banner>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
