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
    public class VendedorComissaoTest
    {
        public Mock<IVendedorComissao> mock = new Mock<IVendedorComissao>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockVendedorComissao.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<VendedorComissao>())).Returns(Task.CompletedTask);

            var service = new VendedorComissaoApiController(mock.Object);
            await service.AdicionarVendedorComissao(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockVendedorComissao.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<VendedorComissao>())).Returns(Task.CompletedTask);

            var service = new VendedorComissaoApiController(mock.Object);
            await service.EditarVendedorComissao(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockVendedorComissao.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<VendedorComissao>())).Returns(Task.CompletedTask);

            var service = new VendedorComissaoApiController(mock.Object);
            await service.ExcluirVendedorComissao(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockVendedorComissao.MontaObjetoUnico().Id)).ReturnsAsync(MockVendedorComissao.MontaObjetoUnico());
            VendedorComissaoApiController ret = new VendedorComissaoApiController(mock.Object);
            var result = await ret.RetornaVendedorComissaoPorId(1);
            Assert.Equal(55, ((Data.Entidades.VendedorComissao)result.Value).Comissao);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockVendedorComissao.MontaListaItems());
            var controller = new VendedorComissaoApiController(mock.Object);
            var result = await controller.ListaVendedorComissao();
            var viewResult = Assert.IsType<List<VendedorComissao>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
