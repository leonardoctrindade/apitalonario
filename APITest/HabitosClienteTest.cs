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
    public class HabitosClienteTest
    {
        public Mock<IHabitosCliente> mock = new Mock<IHabitosCliente>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockHabitosCliente.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<HabitosCliente>())).Returns(Task.CompletedTask);

            var service = new HabitosClienteApiController(mock.Object);
            await service.AdicionarHabitosCliente(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_ClienteId_Invalido()
        {
            var modelo = MockHabitosCliente.MontaObjetoClienteIdInvalido();
            var apiController = new HabitosClienteApiController(mock.Object);
            var result = await apiController.AdicionarHabitosCliente(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockHabitosCliente.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<HabitosCliente>())).Returns(Task.CompletedTask);

            var service = new HabitosClienteApiController(mock.Object);
            await service.EditarHabitosCliente(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockHabitosCliente.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<HabitosCliente>())).Returns(Task.CompletedTask);

            var service = new HabitosClienteApiController(mock.Object);
            await service.ExcluirHabitosCliente(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockHabitosCliente.MontaObjetoUnico().Id)).ReturnsAsync(MockHabitosCliente.MontaObjetoUnico());
            HabitosClienteApiController ret = new HabitosClienteApiController(mock.Object);
            var result = await ret.RetornaHabitosClientePorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.HabitosCliente)result.Value).TempoFumante);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockHabitosCliente.MontaListaItems());
            var controller = new HabitosClienteApiController(mock.Object);
            var result = await controller.ListaHabitosCliente();
            var viewResult = Assert.IsType<List<HabitosCliente>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
