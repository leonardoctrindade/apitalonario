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
    public class NcmEstadoTest
    {
        public Mock<INcmEstado> mock = new Mock<INcmEstado>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockNcmEstado.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<NcmEstado>())).Returns(Task.CompletedTask);

            var service = new NcmEstadoApiController(mock.Object);
            await service.AdicionarNcmEstado(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_IdEstadoOrigem_Invalido()
        {
            var modelo = MockNcmEstado.MontaObjetoIdEstadoOrigemInvalido();
            var apiController = new NcmEstadoApiController(mock.Object);
            var result = await apiController.AdicionarNcmEstado(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_IdEstadoDestino_Invalido()
        {
            var modelo = MockNcmEstado.MontaObjetoIdEstadoDestinoInvalido();
            var apiController = new NcmEstadoApiController(mock.Object);
            var result = await apiController.AdicionarNcmEstado(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_IdNcm_Invalido()
        {
            var modelo = MockNcmEstado.MontaObjetoIdNcmInvalido();
            var apiController = new NcmEstadoApiController(mock.Object);
            var result = await apiController.AdicionarNcmEstado(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockNcmEstado.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<NcmEstado>())).Returns(Task.CompletedTask);

            var service = new NcmEstadoApiController(mock.Object);
            await service.EditarNcmEstado(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockNcmEstado.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<NcmEstado>())).Returns(Task.CompletedTask);

            var service = new NcmEstadoApiController(mock.Object);
            await service.ExcluirNcmEstado(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockNcmEstado.MontaObjetoUnico().Id)).ReturnsAsync(MockNcmEstado.MontaObjetoUnico());
            NcmEstadoApiController ret = new NcmEstadoApiController(mock.Object);
            var result = await ret.RetornaNcmEstadoPorId(1);
            Assert.Equal(1, ((Data.Entidades.NcmEstado)result.Value).EstadoOrigemId);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockNcmEstado.MontaListaItems());
            var controller = new NcmEstadoApiController(mock.Object);
            var result = await controller.ListaNcmEstado();
            var viewResult = Assert.IsType<List<NcmEstado>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
