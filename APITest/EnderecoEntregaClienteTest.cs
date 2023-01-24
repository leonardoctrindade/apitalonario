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
    public class EnderecoEntregaClienteTest
    {
        public Mock<IEnderecoEntregaCliente> mock = new Mock<IEnderecoEntregaCliente>();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockEnderecoEntregaCliente.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<EnderecoEntregaCliente>())).Returns(Task.CompletedTask);

            var service = new EnderecoEntregaClienteApiController(mock.Object);
            await service.AdicionarEnderecoEntregaCliente(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_Titulo_Nao_Preenchido()
        {
            var modelo = MockEnderecoEntregaCliente.MontaObjetoTituloVazio();
            var apiController = new EnderecoEntregaClienteApiController(mock.Object);
            var result = await apiController.AdicionarEnderecoEntregaCliente(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockEnderecoEntregaCliente.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<EnderecoEntregaCliente>())).Returns(Task.CompletedTask);

            var service = new EnderecoEntregaClienteApiController(mock.Object);
            await service.EditarEnderecoEntregaCliente(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockEnderecoEntregaCliente.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<EnderecoEntregaCliente>())).Returns(Task.CompletedTask);

            var service = new EnderecoEntregaClienteApiController(mock.Object);
            await service.ExcluirEnderecoEntregaCliente(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockEnderecoEntregaCliente.MontaObjetoUnico().Id)).ReturnsAsync(MockEnderecoEntregaCliente.MontaObjetoUnico());
            EnderecoEntregaClienteApiController ret = new EnderecoEntregaClienteApiController(mock.Object);
            var result = await ret.RetornaEnderecoEntregaClientePorId(1);
            Assert.Equal("Teste Mock 1", ((Data.Entidades.EnderecoEntregaCliente)result.Value).Titulo);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockEnderecoEntregaCliente.MontaListaItems());
            var controller = new EnderecoEntregaClienteApiController(mock.Object);
            var result = await controller.ListaEnderecoEntregaCliente();
            var viewResult = Assert.IsType<List<EnderecoEntregaCliente>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
