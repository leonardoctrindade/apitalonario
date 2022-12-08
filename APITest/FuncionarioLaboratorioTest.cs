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
    public class FuncionarioLaboratorioTest
    {
        public Mock<IFuncionarioLaboratorio> mock = new Mock<IFuncionarioLaboratorio>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockFuncionarioLaboratorio.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<FuncionarioLaboratorio>())).Returns(Task.CompletedTask);

            var service = new FuncionarioLaboratorioApiController(mock.Object);
            await service.AdicionarFuncionarioLaboratorio(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockFuncionarioLaboratorio.MontaObjetoNomeVazio();
            var apiController = new FuncionarioLaboratorioApiController(mock.Object);
            var result = await apiController.AdicionarFuncionarioLaboratorio(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockFuncionarioLaboratorio.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<FuncionarioLaboratorio>())).Returns(Task.CompletedTask);

            var service = new FuncionarioLaboratorioApiController(mock.Object);
            await service.EditarFuncionarioLaboratorio(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockFuncionarioLaboratorio.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<FuncionarioLaboratorio>())).Returns(Task.CompletedTask);

            var service = new FuncionarioLaboratorioApiController(mock.Object);
            await service.ExcluirFuncionarioLaboratorio(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockFuncionarioLaboratorio.MontaObjetoUnico().Id)).ReturnsAsync(MockFuncionarioLaboratorio.MontaObjetoUnico());
            FuncionarioLaboratorioApiController ret = new FuncionarioLaboratorioApiController(mock.Object);
            var result = await ret.RetornaFuncionarioLaboratorioPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.FuncionarioLaboratorio)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockFuncionarioLaboratorio.MontaListaItems());
            var controller = new FuncionarioLaboratorioApiController(mock.Object);
            var result = await controller.ListaFuncionarioLaboratorio();
            var viewResult = Assert.IsType<List<FuncionarioLaboratorio>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
