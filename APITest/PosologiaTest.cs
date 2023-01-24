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
    public class PosologiaTest
    {
        public Mock<IPosologia> mock = new Mock<IPosologia>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockPosologia.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Posologia>())).Returns(Task.CompletedTask);

            var service = new PosologiaApiController(mock.Object);
            await service.AdicionarPosologia(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var modelo = MockPosologia.MontaObjetoDescricaoVazia();
            var apiController = new PosologiaApiController(mock.Object);
            var result = await apiController.AdicionarPosologia(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockPosologia.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Posologia>())).Returns(Task.CompletedTask);

            var service = new PosologiaApiController(mock.Object);
            await service.EditarPosologia(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockPosologia.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Posologia>())).Returns(Task.CompletedTask);

            var service = new PosologiaApiController(mock.Object);
            await service.ExcluirPosologia(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockPosologia.MontaObjetoUnico().Id)).ReturnsAsync(MockPosologia.MontaObjetoUnico());
            PosologiaApiController ret = new PosologiaApiController(mock.Object);
            var result = await ret.RetornaPosologiaPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Posologia)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockPosologia.MontaListaItems());
            var controller = new PosologiaApiController(mock.Object);
            var result = await controller.ListaPosologia();
            var viewResult = Assert.IsType<List<Posologia>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
