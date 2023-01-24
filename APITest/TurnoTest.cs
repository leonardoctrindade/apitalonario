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
    public class TurnoTest
    {
        public Mock<ITurno> mock = new Mock<ITurno>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockTurno.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Turno>())).Returns(Task.CompletedTask);

            var service = new TurnoApiController(mock.Object);
            await service.AdicionarTurno(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_HoraInicial_Nao_Preenchido()
        {
            var modelo = MockTurno.MontaObjetoHoraInicialVazio();
            var apiController = new TurnoApiController(mock.Object);
            var result = await apiController.AdicionarTurno(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_HoraFinal_Nao_Preenchido()
        {
            var modelo = MockTurno.MontaObjetoHoraFinalVazio();
            var apiController = new TurnoApiController(mock.Object);
            var result = await apiController.AdicionarTurno(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_HoraInicialMaiorQueHoraFinal()
        {
            var modelo = MockTurno.MontaObjetoHoraInicialMaiorQueHoraFInal();
            var apiController = new TurnoApiController(mock.Object);
            var result = await apiController.AdicionarTurno(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockTurno.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Turno>())).Returns(Task.CompletedTask);

            var service = new TurnoApiController(mock.Object);
            await service.EditarTurno(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockTurno.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Turno>())).Returns(Task.CompletedTask);

            var service = new TurnoApiController(mock.Object);
            await service.ExcluirTurno(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockTurno.MontaObjetoUnico().Id)).ReturnsAsync(MockTurno.MontaObjetoUnico());
            TurnoApiController ret = new TurnoApiController(mock.Object);
            var result = await ret.RetornaTurnoPorId(1);
            Assert.Equal(1 , ((Data.Entidades.Turno)result.Value).FilialId);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockTurno.MontaListaItems());
            var controller = new TurnoApiController(mock.Object);
            var result = await controller.ListaTurno();
            var viewResult = Assert.IsType<List<Turno>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
