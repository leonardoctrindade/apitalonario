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
    public class NcmTest
    {
        public Mock<INcm> mock = new();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockNcm.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Ncm>())).Returns(Task.CompletedTask);

            var service = new NcmApiController(mock.Object);
            await service.AdicionarNcm(modelo);

            mock.Verify(y => y.Add(modelo));
        }


        [Fact]
        public async Task InsereCodigoNcmNaoPreenchido()
        {
            var modelo = MockNcm.MontaObjetoCodigoNcmVazio();
            var apiController = new NcmApiController(mock.Object);
            var result = await apiController.AdicionarNcm(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task InsereDescricaoNaoPreenchido()
        {
            var modelo = MockNcm.MontaObjetoDescricaoVazia();
            var apiController = new NcmApiController(mock.Object);
            var result = await apiController.AdicionarNcm(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockNcm.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Ncm>())).Returns(Task.CompletedTask);

            var service = new NcmApiController(mock.Object);
            await service.EditarNcm(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockNcm.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Ncm>())).Returns(Task.CompletedTask);

            var service = new NcmApiController(mock.Object);
            await service.ExcluirNcm(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockNcm.MontaObjetoUnico().Id)).ReturnsAsync(MockNcm.MontaObjetoUnico());
            NcmApiController ret = new(mock.Object);
            var result = await ret.RetornaNcmPorId(1);
            //Assert.Equal("Teste 1", ((Data.Entidades.Ncm)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockNcm.MontaListaItems());
            var controller = new NcmApiController(mock.Object);
            var result = await controller.ListaNcm();
            var viewResult = Assert.IsType<List<Ncm>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
