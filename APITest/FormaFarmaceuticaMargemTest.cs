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
    public class FormaFarmaceuticaMargemTest
    {
        public Mock<IFormaFarmaceuticaMargem> mock = new Mock<IFormaFarmaceuticaMargem>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockFormaFarmaceuticaMargem.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<FormaFarmaceuticaMargem>())).Returns(Task.CompletedTask);

            var service = new FormaFarmaceuticaMargemApiController(mock.Object);
            await service.AdicionarFormaFarmaceuticaMargem(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_FormaFarmaceuticaId_Vazio()
        {
            var modelo = MockFormaFarmaceuticaMargem.MontaObjetoFormaFarmaceuticaIdVazia();
            var apiController = new FormaFarmaceuticaMargemApiController(mock.Object);
            var result = await apiController.AdicionarFormaFarmaceuticaMargem(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockFormaFarmaceuticaMargem.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<FormaFarmaceuticaMargem>())).Returns(Task.CompletedTask);

            var service = new FormaFarmaceuticaMargemApiController(mock.Object);
            await service.EditarFormaFarmaceuticaMargem(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockFormaFarmaceuticaMargem.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<FormaFarmaceuticaMargem>())).Returns(Task.CompletedTask);

            var service = new FormaFarmaceuticaMargemApiController(mock.Object);
            await service.ExcluirFormaFarmaceuticaMargem(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockFormaFarmaceuticaMargem.MontaObjetoUnico().Id)).ReturnsAsync(MockFormaFarmaceuticaMargem.MontaObjetoUnico());
            FormaFarmaceuticaMargemApiController ret = new FormaFarmaceuticaMargemApiController(mock.Object);
            var result = await ret.RetornaFormaFarmaceuticaMargemPorId(1);
            Assert.Equal(1, ((Data.Entidades.FormaFarmaceuticaMargem)result.Value).Id);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockFormaFarmaceuticaMargem.MontaListaItems());
            var controller = new FormaFarmaceuticaMargemApiController(mock.Object);
            var result = await controller.ListaFormaFarmaceuticaMargem();
            var viewResult = Assert.IsType<List<FormaFarmaceuticaMargem>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
