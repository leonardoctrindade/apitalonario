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
    public class PosAdquirenteTest
    {
        public Mock<IPosAdquirente> mock = new Mock<IPosAdquirente>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockPosAdquirente.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<PosAdquirente>())).Returns(Task.CompletedTask);

            var service = new PosAdquirenteApiController(mock.Object);
            await service.AdicionarPosAdquirente(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_ChaveRequisicao_Nao_Preenchido()
        {
            var modelo = MockPosAdquirente.MontaObjetoChaveRequisicaoVazia();
            var apiController = new PosAdquirenteApiController(mock.Object);
            var result = await apiController.AdicionarPosAdquirente(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockPosAdquirente.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<PosAdquirente>())).Returns(Task.CompletedTask);

            var service = new PosAdquirenteApiController(mock.Object);
            await service.EditarPosAdquirente(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockPosAdquirente.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<PosAdquirente>())).Returns(Task.CompletedTask);

            var service = new PosAdquirenteApiController(mock.Object);
            await service.ExcluirPosAdquirente(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockPosAdquirente.MontaObjetoUnico().Id)).ReturnsAsync(MockPosAdquirente.MontaObjetoUnico());
            PosAdquirenteApiController ret = new PosAdquirenteApiController(mock.Object);
            var result = await ret.RetornaPosAdquirentePorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.PosAdquirente)result.Value).ChaveRequisicao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockPosAdquirente.MontaListaItems());
            var controller = new PosAdquirenteApiController(mock.Object);
            var result = await controller.ListaPosAdquirente();
            var viewResult = Assert.IsType<List<PosAdquirente>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
