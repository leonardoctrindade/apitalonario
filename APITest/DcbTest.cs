using APITest.Mocks;
using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace APITest
{
    public class DcbTest
    {
        public Mock<IDcb> mock = new Mock<IDcb>();
        [Fact]
        public async Task Insere_Dcb_Sucesso()
        {
            var dcb = MockDcb.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Dcb>())).Returns(Task.CompletedTask);

            var service = new DcbApiController(mock.Object);

            await service.AdicionarDcb(dcb);

            mock.Verify(y => y.Add(dcb));
        }
        [Fact]
        public async Task Insere_Descricao_Nao_Preenchida()
        {
            var dcb = MockDcb.MontaObjetoComDescricaoVazio();
            var service = new DcbApiController(mock.Object);
            var result = await service.AdicionarDcb(dcb);

            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }
        [Fact]
        public async Task Insere_Codigo_Dcb_Nao_Preenchido()
        {
            var dcb = MockDcb.MontaObjetoComCodigoDcbVazio();
            var service = new DcbApiController(mock.Object);
            var result = await service.AdicionarDcb(dcb);

            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result.Value).StatusCode.Value.ToString());
        }
        [Fact]
        public async Task Editar_Sucesso()
        {
            var dcb = MockDcb.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Dcb>())).Returns(Task.CompletedTask);
            
            var service = new DcbApiController(mock.Object);
            await service.EditarDcb(dcb);

            mock.Verify(y => y.Update(dcb));
        }
        [Fact]
        public async Task Excluir_Sucesso()
        {
            var dcb = MockDcb.MontaObjetoUnico();
            mock.Setup(y => y.Delete(It.IsAny<Dcb>())).Returns(Task.CompletedTask);

            var service = new DcbApiController(mock.Object);
            await service.ExcluirDcb(dcb);

            mock.Verify(y => y.Delete(dcb));
        }
        [Fact]
        public async Task RetornarPorId()
        {
            mock.Setup(y => y.GetEntityById(MockDcb.MontaObjetoUnico().Id)).ReturnsAsync(MockDcb.MontaObjetoUnico());
            var ret = new DcbApiController(mock.Object);
            var result = await ret.RetornarDcbPorId(1);

            Assert.Equal("Teste Dcb", ((Data.Entidades.Dcb)result.Value).Descricao);
        }
        [Fact]
        public async Task RetornarLista()
        {
            mock.Setup(y => y.List()).ReturnsAsync(MockDcb.MontaListaItems());
            var controller = new DcbApiController(mock.Object);
            var result = await controller.ListarDcb();
            var viewResult = Assert.IsType<List<Dcb>>(result.Value);

            Assert.Equal(3,viewResult.Count);
        }
    }
}
