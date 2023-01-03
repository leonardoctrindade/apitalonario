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
    public class SetorFormaTest
    {
        public Mock<ISetorForma> mock = new Mock<ISetorForma>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockSetorForma.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<SetorForma>())).Returns(Task.CompletedTask);

            var service = new SetorFormaApiController(mock.Object);
            await service.AdicionarSetorForma(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_SetorId_Invalido()
        {
            var modelo = MockSetorForma.MontaObjetoSetorIdInvalido();
            var apiController = new SetorFormaApiController(mock.Object);
            var result = await apiController.AdicionarSetorForma(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockSetorForma.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<SetorForma>())).Returns(Task.CompletedTask);

            var service = new SetorFormaApiController(mock.Object);
            await service.EditarSetorForma(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockSetorForma.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<SetorForma>())).Returns(Task.CompletedTask);

            var service = new SetorFormaApiController(mock.Object);
            await service.ExcluirSetorForma(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockSetorForma.MontaObjetoUnico().Id)).ReturnsAsync(MockSetorForma.MontaObjetoUnico());
            SetorFormaApiController ret = new SetorFormaApiController(mock.Object);
            var result = await ret.RetornaSetorFormaPorId(1);
            Assert.Equal(1, ((Data.Entidades.SetorForma)result.Value).SetorId);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockSetorForma.MontaListaItems());
            var controller = new SetorFormaApiController(mock.Object);
            var result = await controller.ListaSetorForma();
            var viewResult = Assert.IsType<List<SetorForma>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
