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
    public class DiasHorasTest
    {
        public Mock<IDiasHoras> mock = new Mock<IDiasHoras>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockDiasHoras.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<DiasHoras>())).Returns(Task.CompletedTask);

            var service = new DiasHorasApiController(mock.Object);
            await service.AdicionarDiasHoras(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_CodigoDia_Vazio()
        {
            var modelo = MockDiasHoras.MontaObjetoCodigoDiaVazio();
            var apiController = new DiasHorasApiController(mock.Object);
            var result = await apiController.AdicionarDiasHoras(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Sequencia_Vazio()
        {
            var modelo = MockDiasHoras.MontaObjetoSequenciaVazio();
            var apiController = new DiasHorasApiController(mock.Object);
            var result = await apiController.AdicionarDiasHoras(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockDiasHoras.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<DiasHoras>())).Returns(Task.CompletedTask);

            var service = new DiasHorasApiController(mock.Object);
            await service.EditarDiasHoras(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockDiasHoras.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<DiasHoras>())).Returns(Task.CompletedTask);

            var service = new DiasHorasApiController(mock.Object);
            await service.ExcluirDiasHoras(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockDiasHoras.MontaObjetoUnico().Id)).ReturnsAsync(MockDiasHoras.MontaObjetoUnico());
            DiasHorasApiController ret = new DiasHorasApiController(mock.Object);
            var result = await ret.RetornaDiasHorasPorId(1);
            Assert.Equal(1, ((Data.Entidades.DiasHoras)result.Value).CodigoDia);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockDiasHoras.MontaListaItems());
            var controller = new DiasHorasApiController(mock.Object);
            var result = await controller.ListaDiasHoras();
            var viewResult = Assert.IsType<List<DiasHoras>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
