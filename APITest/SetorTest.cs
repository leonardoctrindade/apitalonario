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
    public class SetorTest
    {
        public Mock<ISetor> mock = new Mock<ISetor>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockSetor.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Setor>())).Returns(Task.CompletedTask);

            var service = new SetorApiController(mock.Object);
            await service.AdicionarSetor(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockSetor.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Setor>())).Returns(Task.CompletedTask);

            var service = new SetorApiController(mock.Object);
            await service.EditarSetor(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockSetor.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Setor>())).Returns(Task.CompletedTask);

            var service = new SetorApiController(mock.Object);
            await service.ExcluirSetor(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockSetor.MontaObjetoUnico().Id)).ReturnsAsync(MockSetor.MontaObjetoUnico());
            SetorApiController ret = new SetorApiController(mock.Object);
            var result = await ret.RetornaSetorPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.Setor)result.Value).Nome);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockSetor.MontaListaItems());
            var controller = new SetorApiController(mock.Object);
            var result = await controller.ListaSetor();
            var viewResult = Assert.IsType<List<Setor>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
