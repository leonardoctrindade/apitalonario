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
    public class FormaFarmaceuticaTest
    {
        public Mock<IFormaFarmaceutica> mock = new Mock<IFormaFarmaceutica>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockFormaFarmaceutica.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<FormaFarmaceutica>())).Returns(Task.CompletedTask);

            var service = new FormaFarmaceuticaApiController(mock.Object);
            await service.AdicionarFormaFarmaceutica(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Vazia()
        {
            var modelo = MockFormaFarmaceutica.MontaObjetoDescricaoVazia();
            var apiController = new FormaFarmaceuticaApiController(mock.Object);
            var result = await apiController.AdicionarFormaFarmaceutica(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockFormaFarmaceutica.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<FormaFarmaceutica>())).Returns(Task.CompletedTask);

            var service = new FormaFarmaceuticaApiController(mock.Object);
            await service.EditarFormaFarmaceutica(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockFormaFarmaceutica.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<FormaFarmaceutica>())).Returns(Task.CompletedTask);

            var service = new FormaFarmaceuticaApiController(mock.Object);
            await service.ExcluirFormaFarmaceutica(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockFormaFarmaceutica.MontaObjetoUnico().Id)).ReturnsAsync(MockFormaFarmaceutica.MontaObjetoUnico());
            FormaFarmaceuticaApiController ret = new FormaFarmaceuticaApiController(mock.Object);
            var result = await ret.RetornaFormaFarmaceuticaPorId(1);
            //Assert.Equal("Teste Mock 1", ((Data.Entidades.FormaFarmaceutica)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockFormaFarmaceutica.MontaListaItems());
            var controller = new FormaFarmaceuticaApiController(mock.Object);
            var result = await controller.ListaFormaFarmaceutica();
            var viewResult = Assert.IsType<List<FormaFarmaceutica>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
