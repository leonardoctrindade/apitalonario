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
    public class FormaFarmaceuticaFaixaTest
    {
        public Mock<IFormaFarmaceuticaFaixa> mock = new();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockFormaFarmaceuticaFaixa.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<FormaFarmaceuticaFaixa>())).Returns(Task.CompletedTask);

            var service = new FormaFarmaceuticaFaixaApiController(mock.Object);
            await service.AdicionarFormaFarmaceuticaFaixa(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_FormaFarmaceuticaId_Nao_Preenchido()
        {
            var modelo = MockFormaFarmaceuticaFaixa.MontaObjetoFormaFarmaceuticaIdVazio();
            var apiController = new FormaFarmaceuticaFaixaApiController(mock.Object);
            var result = await apiController.AdicionarFormaFarmaceuticaFaixa(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockFormaFarmaceuticaFaixa.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<FormaFarmaceuticaFaixa>())).Returns(Task.CompletedTask);

            var service = new FormaFarmaceuticaFaixaApiController(mock.Object);
            await service.EditarFormaFarmaceuticaFaixa(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockFormaFarmaceuticaFaixa.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<FormaFarmaceuticaFaixa>())).Returns(Task.CompletedTask);

            var service = new FormaFarmaceuticaFaixaApiController(mock.Object);
            await service.ExcluirFormaFarmaceuticaFaixa(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockFormaFarmaceuticaFaixa.MontaObjetoUnico().Id)).ReturnsAsync(MockFormaFarmaceuticaFaixa.MontaObjetoUnico());
            FormaFarmaceuticaFaixaApiController ret = new(mock.Object);
            var result = await ret.RetornaFormaFarmaceuticaFaixaPorId(1);
            Assert.Equal(1, ((Data.Entidades.FormaFarmaceuticaFaixa)result.Value).Id);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockFormaFarmaceuticaFaixa.MontaListaItems());
            var controller = new FormaFarmaceuticaFaixaApiController(mock.Object);
            var result = await controller.ListaFormaFarmaceuticaFaixa();
            var viewResult = Assert.IsType<List<FormaFarmaceuticaFaixa>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
