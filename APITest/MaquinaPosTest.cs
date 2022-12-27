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
    public class MaquinaPosTest
    {
        public Mock<IMaquinaPos> mock = new Mock<IMaquinaPos>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockMaquinaPos.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<MaquinaPos>())).Returns(Task.CompletedTask);

            var service = new MaquinaPosApiController(mock.Object);
            await service.AdicionarMaquinaPos(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_SerialPos_Nao_preenchido()
        {
            var modelo = MockMaquinaPos.MontaObjetoSerialPosVazio();
            var apiController = new MaquinaPosApiController(mock.Object);
            var result = await apiController.AdicionarMaquinaPos(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockMaquinaPos.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<MaquinaPos>())).Returns(Task.CompletedTask);

            var service = new MaquinaPosApiController(mock.Object);
            await service.EditarMaquinaPos(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockMaquinaPos.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<MaquinaPos>())).Returns(Task.CompletedTask);

            var service = new MaquinaPosApiController(mock.Object);
            await service.ExcluirMaquinaPos(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockMaquinaPos.MontaObjetoUnico().Id)).ReturnsAsync(MockMaquinaPos.MontaObjetoUnico());
            MaquinaPosApiController ret = new MaquinaPosApiController(mock.Object);
            var result = await ret.RetornaMaquinaPosPorId(1);
            //Assert.Equal("Teste 1", ((Data.Entidades.MaquinaPos)result.Value).SerialPos);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockMaquinaPos.MontaListaItems());
            var controller = new MaquinaPosApiController(mock.Object);
            var result = await controller.ListaMaquinaPos();
            var viewResult = Assert.IsType<List<MaquinaPos>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
