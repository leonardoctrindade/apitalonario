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
    public class EtiquetaTest
    {
        public Mock<IEtiqueta> mock = new Mock<IEtiqueta>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockEtiqueta.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Etiqueta>())).Returns(Task.CompletedTask);

            var service = new EtiquetaApiController(mock.Object);
            await service.AdicionarEtiqueta(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockEtiqueta.MontaObjetoDescricaoVazia();
            var apiController = new EtiquetaApiController(mock.Object);
            var result = await apiController.AdicionarEtiqueta(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_MargemSuperior_Invalida()
        {
            var modelo = MockEtiqueta.MontaObjetoMargemSuperiorInvalida();
            var apiController = new EtiquetaApiController(mock.Object);
            var result = await apiController.AdicionarEtiqueta(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Margemlateral_Invalida()
        {
            var modelo = MockEtiqueta.MontaObjetoMargemLateralInvalida();
            var apiController = new EtiquetaApiController(mock.Object);
            var result = await apiController.AdicionarEtiqueta(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_AlturaEtiqueta_Invalida()
        {
            var modelo = MockEtiqueta.MontaObjetoAlturaEtiquetaInvalida();
            var apiController = new EtiquetaApiController(mock.Object);
            var result = await apiController.AdicionarEtiqueta(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_DistanciaVertical_Invalida()
        {
            var modelo = MockEtiqueta.MontaObjetoDistanciaVerticalInvalida();
            var apiController = new EtiquetaApiController(mock.Object);
            var result = await apiController.AdicionarEtiqueta(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_DistanciaHorizontal_Invalida()
        {
            var modelo = MockEtiqueta.MontaObjetoDistanciaHorizontalInvalida();
            var apiController = new EtiquetaApiController(mock.Object);
            var result = await apiController.AdicionarEtiqueta(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_LinhasPorPagina_Invalida()
        {
            var modelo = MockEtiqueta.MontaObjetoLinhasPorPaginaInvalida();
            var apiController = new EtiquetaApiController(mock.Object);
            var result = await apiController.AdicionarEtiqueta(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_ColunasPorPagina_Invalida()
        {
            var modelo = MockEtiqueta.MontaObjetoColunasPorPaginaInvalida();
            var apiController = new EtiquetaApiController(mock.Object);
            var result = await apiController.AdicionarEtiqueta(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_LayoutEtiquetaEntrada_Invalida()
        {
            var modelo = MockEtiqueta.MontaObjetoLayoutEtiquetaEntradaInvalida();
            var apiController = new EtiquetaApiController(mock.Object);
            var result = await apiController.AdicionarEtiqueta(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_LinhasPorEtiqueta_Invalida()
        {
            var modelo = MockEtiqueta.MontaObjetoLinhasPorEtiquetaInvalida();
            var apiController = new EtiquetaApiController(mock.Object);
            var result = await apiController.AdicionarEtiqueta(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_EspacoEntreLinhas_Invalida()
        {
            var modelo = MockEtiqueta.MontaObjetoEspacoEntreLinhasInvalida();
            var apiController = new EtiquetaApiController(mock.Object);
            var result = await apiController.AdicionarEtiqueta(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockEtiqueta.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Etiqueta>())).Returns(Task.CompletedTask);

            var service = new EtiquetaApiController(mock.Object);
            await service.EditarEtiqueta(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockEtiqueta.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Etiqueta>())).Returns(Task.CompletedTask);

            var service = new EtiquetaApiController(mock.Object);
            await service.ExcluirEtiqueta(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockEtiqueta.MontaObjetoUnico().Id)).ReturnsAsync(MockEtiqueta.MontaObjetoUnico());
            EtiquetaApiController ret = new EtiquetaApiController(mock.Object);
            var result = await ret.RetornaEtiquetaPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Etiqueta)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockEtiqueta.MontaListaItems());
            var controller = new EtiquetaApiController(mock.Object);
            var result = await controller.ListaEtiqueta();
            var viewResult = Assert.IsType<List<Etiqueta>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
