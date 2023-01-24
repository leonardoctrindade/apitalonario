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
    public class SetorDiasHorasTest
    {
        public Mock<ISetorDiasHoras> mock = new Mock<ISetorDiasHoras>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockSetorDiasHoras.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<SetorDiasHoras>())).Returns(Task.CompletedTask);

            var service = new SetorDiasHorasApiController(mock.Object);
            await service.AdicionarSetorDiasHoras(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_SetorId_Invalido()
        {
            var modelo = MockSetorDiasHoras.MontaObjetoSetorIdInvalido();
            var apiController = new SetorDiasHorasApiController(mock.Object);
            var result = await apiController.AdicionarSetorDiasHoras(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_DiasHorasId_Invalido()
        {
            var modelo = MockSetorDiasHoras.MontaObjetoDiasHorasIdInvalido();
            var apiController = new SetorDiasHorasApiController(mock.Object);
            var result = await apiController.AdicionarSetorDiasHoras(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockSetorDiasHoras.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<SetorDiasHoras>())).Returns(Task.CompletedTask);

            var service = new SetorDiasHorasApiController(mock.Object);
            await service.EditarSetorDiasHoras(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockSetorDiasHoras.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<SetorDiasHoras>())).Returns(Task.CompletedTask);

            var service = new SetorDiasHorasApiController(mock.Object);
            await service.ExcluirSetorDiasHoras(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockSetorDiasHoras.MontaObjetoUnico().Id)).ReturnsAsync(MockSetorDiasHoras.MontaObjetoUnico());
            SetorDiasHorasApiController ret = new(mock.Object);
            var result = await ret.RetornaSetorDiasHorasPorId(1);
            Assert.Equal(1, ((Data.Entidades.SetorDiasHoras)result.Value).SetorId);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockSetorDiasHoras.MontaListaItems());
            var controller = new SetorDiasHorasApiController(mock.Object);
            var result = await controller.ListaSetorDiasHoras();
            var viewResult = Assert.IsType<List<SetorDiasHoras>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
