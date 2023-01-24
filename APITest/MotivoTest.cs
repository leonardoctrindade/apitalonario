using System.Text;
using System.Linq;
using APITest.Mocks;
using Data.Entidades;
using Data.Interfaces;
using WebAPI.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace APITest
{
    public class MotivoTest
    {
        public Mock<IMotivo> mock = new Mock<IMotivo>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var motivo = MockMotivo.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Motivo>())).Returns(Task.CompletedTask);

            var service = new MotivoApiController(mock.Object);
            await service.AdicionarMotivo(motivo);

            mock.Verify(y => y.Add(motivo));
        }
        [Fact]
        public async Task Insere_Descricao_Vazio()
        {
            var motivo = MockMotivo.MontaObjetoDescricaoVazio();

            var service = new MotivoApiController(mock.Object);

            var result = await service.AdicionarMotivo(motivo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());

        }
        [Fact]
        public async Task Editar_Sucesso()
        {
            var motivo = MockMotivo.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Motivo>())).Returns(Task.CompletedTask);
            var service = new MotivoApiController(mock.Object);
            await service.EditarMotivo(motivo);

            mock.Verify(y => y.Update(motivo));
        }
        [Fact]
        public async Task Excluir_Sucesso()
        {
            var motivo = MockMotivo.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Motivo>())).Returns(Task.CompletedTask);
            var service = new MotivoApiController(mock.Object);
            await service.ExcluirMotivo(motivo);

            mock.Verify(y => y.Delete(motivo));
        }
        [Fact]
        public async Task RetornarProId()
        {
            mock.Setup(y => y.GetEntityById(MockMotivo.MontaObjetoUnico().Id)).ReturnsAsync(MockMotivo.MontaObjetoUnico());
            var service = new MotivoApiController(mock.Object);
            var result = await service.RetornarMotivoPorId(1);
            Assert.Equal("Motivo Mock", ((Data.Entidades.Motivo)result.Value).Descricao);
        }
        [Fact]
        public async Task RetornarLista()
        {
            mock.Setup(rep => rep.List()).ReturnsAsync(MockMotivo.MontaListaItens());

            var service = new MotivoApiController(mock.Object);
            var result = await service.ListaMotivo();
            var viewResult = Assert.IsType<List<Motivo>>(result.Value);

            Assert.Equal(3,viewResult.Count);
        }
    }
}
