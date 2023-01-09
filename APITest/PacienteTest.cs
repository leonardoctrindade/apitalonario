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
    public class PacienteTest
    {
        public Mock<IPaciente> mock = new Mock<IPaciente>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockPaciente.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Paciente>())).Returns(Task.CompletedTask);

            var service = new PacienteApiController(mock.Object);
            await service.AdicionarPaciente(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockPaciente.MontaObjetoNomeVazio();
            var apiController = new PacienteApiController(mock.Object);
            var result = await apiController.AdicionarPaciente(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_ClienteId_Invalido()
        {
            var modelo = MockPaciente.MontaObjetoClienteIdInvalido();
            var apiController = new PacienteApiController(mock.Object);
            var result = await apiController.AdicionarPaciente(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockPaciente.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Paciente>())).Returns(Task.CompletedTask);

            var service = new PacienteApiController(mock.Object);
            await service.EditarPaciente(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockPaciente.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Paciente>())).Returns(Task.CompletedTask);

            var service = new PacienteApiController(mock.Object);
            await service.ExcluirPaciente(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockPaciente.MontaObjetoUnico().Id)).ReturnsAsync(MockPaciente.MontaObjetoUnico());
            PacienteApiController ret = new PacienteApiController(mock.Object);
            var result = await ret.RetornaPacientePorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Paciente)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockPaciente.MontaListaItems());
            var controller = new PacienteApiController(mock.Object);
            var result = await controller.ListaPaciente();
            var viewResult = Assert.IsType<List<Paciente>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
