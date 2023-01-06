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
    public class ReacoesAdversasTest
    {
        public Mock<IReacoesAdversas> mock = new Mock<IReacoesAdversas>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockReacoesAdversas.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<ReacoesAdversas>())).Returns(Task.CompletedTask);

            var service = new ReacoesAdversasApiController(mock.Object);
            await service.AdicionarReacoesAdversas(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Data_Nao_Preenchida()
        {
            var modelo = MockReacoesAdversas.MontaObjetoDataVazia();
            var apiController = new ReacoesAdversasApiController(mock.Object);
            var result = await apiController.AdicionarReacoesAdversas(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockReacoesAdversas.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<ReacoesAdversas>())).Returns(Task.CompletedTask);

            var service = new ReacoesAdversasApiController(mock.Object);
            await service.EditarReacoesAdversas(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockReacoesAdversas.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<ReacoesAdversas>())).Returns(Task.CompletedTask);

            var service = new ReacoesAdversasApiController(mock.Object);
            await service.ExcluirReacoesAdversas(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockReacoesAdversas.MontaObjetoUnico().Id)).ReturnsAsync(MockReacoesAdversas.MontaObjetoUnico());
            ReacoesAdversasApiController ret = new ReacoesAdversasApiController(mock.Object);
            var result = await ret.RetornaReacoesAdversasPorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.ReacoesAdversas)result.Value).Medicamento);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockReacoesAdversas.MontaListaItems());
            var controller = new ReacoesAdversasApiController(mock.Object);
            var result = await controller.ListaReacoesAdversas();
            var viewResult = Assert.IsType<List<ReacoesAdversas>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
