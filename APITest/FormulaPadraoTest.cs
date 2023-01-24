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
    public class FormulaPadraoTest
    {
        public Mock<IFormulaPadrao> mock = new Mock<IFormulaPadrao>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockFormulaPadrao.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<FormulaPadrao>())).Returns(Task.CompletedTask);

            var service = new FormulaPadraoApiController(mock.Object);
            await service.AdicionarFormulaPadrao(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Descricao_Nao_Preenchido()
        {
            var modelo = MockFormulaPadrao.MontaObjetoDescricaoVazia();
            var apiController = new FormulaPadraoApiController(mock.Object);
            var result = await apiController.AdicionarFormulaPadrao(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_IdFormaFarmaceutica_Invalida()
        {
            var modelo = MockFormulaPadrao.MontaObjetoIdFormaFarmaceuticaInvalido();
            var apiController = new FormulaPadraoApiController(mock.Object);
            var result = await apiController.AdicionarFormulaPadrao(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockFormulaPadrao.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<FormulaPadrao>())).Returns(Task.CompletedTask);

            var service = new FormulaPadraoApiController(mock.Object);
            await service.EditarFormulaPadrao(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockFormulaPadrao.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<FormulaPadrao>())).Returns(Task.CompletedTask);

            var service = new FormulaPadraoApiController(mock.Object);
            await service.ExcluirFormulaPadrao(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockFormulaPadrao.MontaObjetoUnico().Id)).ReturnsAsync(MockFormulaPadrao.MontaObjetoUnico());
            FormulaPadraoApiController ret = new(mock.Object);
            var result = await ret.RetornaFormulaPadraoPorId(1);
            //Assert.Equal("Teste Mock 1", ((Data.Entidades.FormulaPadrao)result.Value).Descricao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockFormulaPadrao.MontaListaItems());
            var controller = new FormulaPadraoApiController(mock.Object);
            var result = await controller.ListaFormulaPadrao();
            var viewResult = Assert.IsType<List<FormulaPadrao>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
