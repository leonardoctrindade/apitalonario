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
    public class ConvenioTest
    {
        public Mock<IConvenio> mock = new Mock<IConvenio>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockConvenio.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Convenio>())).Returns(Task.CompletedTask);

            var service = new ConvenioApiController(mock.Object);
            await service.AdicionarConvenio(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Nome_Nao_Preenchido()
        {
            var modelo = MockConvenio.MontaObjetoNomeVazio();
            var apiController = new ConvenioApiController(mock.Object);
            var result = await apiController.AdicionarConvenio(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockConvenio.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Convenio>())).Returns(Task.CompletedTask);

            var service = new ConvenioApiController(mock.Object);
            await service.EditarConvenio(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockConvenio.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Convenio>())).Returns(Task.CompletedTask);

            var service = new ConvenioApiController(mock.Object);
            await service.ExcluirConvenio(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockConvenio.MontaObjetoUnico().Id)).ReturnsAsync(MockConvenio.MontaObjetoUnico());
            ConvenioApiController ret = new ConvenioApiController(mock.Object);
            var result = await ret.RetornaConvenioPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Convenio)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockConvenio.MontaListaItems());
            var controller = new ConvenioApiController(mock.Object);
            var result = await controller.ListaConvenio();
            var viewResult = Assert.IsType<List<Convenio>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
