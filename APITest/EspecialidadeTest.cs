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
    public class EspecialidadeTest
    {
        public Mock<IEspecialidade> mock = new Mock<IEspecialidade>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockEspecialidade.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Especialidade>())).Returns(Task.CompletedTask);

            var service = new EspecialidadeApiController(mock.Object);
            await service.AdicionarEspecialidade(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var modelo = MockEspecialidade.MontaObjetoDescricaoVazio();
            var apiController = new EspecialidadeApiController(mock.Object);
            var result = await apiController.AdicionarEspecialidade(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockEspecialidade.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Especialidade>())).Returns(Task.CompletedTask);

            var service = new EspecialidadeApiController(mock.Object);
            await service.EditarEspecialidade(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockEspecialidade.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Especialidade>())).Returns(Task.CompletedTask);

            var service = new EspecialidadeApiController(mock.Object);
            await service.ExcluirEspecialidade(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockEspecialidade.MontaObjetoUnico().Id)).ReturnsAsync(MockEspecialidade.MontaObjetoUnico());
            EspecialidadeApiController ret = new EspecialidadeApiController(mock.Object);
            var result = await ret.RetornarEspecialidadePorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Especialidade)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockEspecialidade.MontaListaItems());
            var controller = new EspecialidadeApiController(mock.Object);
            var result = await controller.ListaEspecialidade();
            var viewResult = Assert.IsType<List<Especialidade>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
