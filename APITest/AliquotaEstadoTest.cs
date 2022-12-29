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
    public class AliquotaEstadoTest
    {
        public Mock<IAliquotaEstado> mock = new Mock<IAliquotaEstado>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockAliquotaEstado.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<AliquotaEstado>())).Returns(Task.CompletedTask);

            var service = new AliquotaEstadoApiController(mock.Object);
            await service.AdicionarAliquotaEstado(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockAliquotaEstado.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<AliquotaEstado>())).Returns(Task.CompletedTask);

            var service = new AliquotaEstadoApiController(mock.Object);
            await service.EditarAliquotaEstado(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockAliquotaEstado.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<AliquotaEstado>())).Returns(Task.CompletedTask);

            var service = new AliquotaEstadoApiController(mock.Object);
            await service.ExcluirAliquotaEstado(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockAliquotaEstado.MontaObjetoUnico().Id)).ReturnsAsync(MockAliquotaEstado.MontaObjetoUnico());
            AliquotaEstadoApiController ret = new AliquotaEstadoApiController(mock.Object);
            var result = await ret.RetornaAliquotaEstadoPorId(1);
            Assert.Equal(1, ((Data.Entidades.AliquotaEstado)result.Value).EstadoOrigemId);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockAliquotaEstado.MontaListaItems());
            var controller = new AliquotaEstadoApiController(mock.Object);
            var result = await controller.ListaAliquotaEstado();
            var viewResult = Assert.IsType<List<AliquotaEstado>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
