using APITest.Mocks;
using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace APITest
{
    public class LaboratorioTest
    {
        public Mock<ILaboratorio> mock = new Mock<ILaboratorio>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var laboratorio = MockLaboratorio.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Laboratorio>())).Returns(Task.CompletedTask);

            var service = new LaboratorioApiController(mock.Object);
            await service.AdicionarLaboratorio(laboratorio);

            mock.Verify(y => y.Add(laboratorio));
        }
        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var laboratorio = MockLaboratorio.MontaObjetoDescricaoVazio();
            var service = new LaboratorioApiController(mock.Object);

            var result = await service.AdicionarLaboratorio(laboratorio);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }
        [Fact]
        public async Task Editar_Sucesso()
        {
            var laboratorio = MockLaboratorio.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Laboratorio>())).Returns(Task.CompletedTask);

            var service = new LaboratorioApiController(mock.Object);
            await service.EditarLaboratorio(laboratorio);

            mock.Verify(y => y.Update(laboratorio));
        }
        [Fact]
        public async Task Excluir_Sucesso()
        {
            var laboratorio = MockLaboratorio.MontaObjetoUnico();
            mock.Setup(y => y.Delete(It.IsAny<Laboratorio>())).Returns(Task.CompletedTask);

            var service = new LaboratorioApiController(mock.Object);
            await service.ExcluirLaboratorio(laboratorio);

            mock.Verify(y => y.Delete(laboratorio));
        }
        [Fact]
        public async Task RetornarPorId()
        {
            mock.Setup(y => y.GetEntityById(MockLaboratorio.MontaObjetoUnico().Id)).ReturnsAsync(MockLaboratorio.MontaObjetoUnico());
            var ret = new LaboratorioApiController(mock.Object);
            var result = await ret.RetornarLaboratorioId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Laboratorio)result.Value).Descricao);
        }
        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(rep => rep.List()).ReturnsAsync(MockLaboratorio.MontaListaItens());
            var service = new LaboratorioApiController(mock.Object);
            var result = await service.ListaLaboratorio();
            var viewResult = Assert.IsType<List<Laboratorio>>(result.Value);

            Assert.Equal(3,viewResult.Count);
        }
    }
}
