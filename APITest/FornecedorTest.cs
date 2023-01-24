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
    public class FornecedorTest
    {
        public Mock<IFornecedor> mock = new();

        [Fact]
        public async Task Insere_Sucesso()
        {
            var modelo = MockFornecedor.MontaObjetoUnico();

            mock.Setup(y => y.Add(It.IsAny<Fornecedor>())).Returns(Task.CompletedTask);

            var service = new FornecedorApiController(mock.Object);
            await service.AdicionarFornecedor(modelo);

            mock.Verify(y => y.Add(modelo));
        }

        [Fact]
        public async Task Insere_NomeFornecedor_Nao_Preenchido()
        {
            var modelo = MockFornecedor.MontaObjetoNomeFornecedorVazio();
            var apiController = new FornecedorApiController(mock.Object);
            var result = await apiController.AdicionarFornecedor(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_NomeFantasia_Nao_Preenchido()
        {
            var modelo = MockFornecedor.MontaObjetoNomeFantasiaVazio();
            var apiController = new FornecedorApiController(mock.Object);
            var result = await apiController.AdicionarFornecedor(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Cnpj_Nao_Preenchido()
        {
            var modelo = MockFornecedor.MontaObjetoCnpjVazio();
            var apiController = new FornecedorApiController(mock.Object);
            var result = await apiController.AdicionarFornecedor(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_Cpf_Nao_Preenchido()
        {
            var modelo = MockFornecedor.MontaObjetoCpfVazio();
            var apiController = new FornecedorApiController(mock.Object);
            var result = await apiController.AdicionarFornecedor(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_IncricaoEstadual_Nao_Preenchido()
        {
            var modelo = MockFornecedor.MontaObjetoIncricaoEstadualVazio();
            var apiController = new FornecedorApiController(mock.Object);
            var result = await apiController.AdicionarFornecedor(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Insere_IdEstado_Invalido()
        {
            var modelo = MockFornecedor.MontaObjetoIdEstadoInvalido();
            var apiController = new FornecedorApiController(mock.Object);
            var result = await apiController.AdicionarFornecedor(modelo);
            Assert.Equal(new StatusCodeResult(400).StatusCode.ToString(), ((ObjectResult)result).StatusCode.Value.ToString());
        }

        [Fact]
        public async Task Editar_Sucesso()
        {
            var modelo = MockFornecedor.MontaObjetoUnico();

            mock.Setup(y => y.Update(It.IsAny<Fornecedor>())).Returns(Task.CompletedTask);

            var service = new FornecedorApiController(mock.Object);
            await service.EditarFornecedor(modelo);

            mock.Verify(y => y.Update(modelo));
        }

        [Fact]
        public async Task Excluir_Sucesso()
        {
            var modelo = MockFornecedor.MontaObjetoUnico();

            mock.Setup(y => y.Delete(It.IsAny<Fornecedor>())).Returns(Task.CompletedTask);

            var service = new FornecedorApiController(mock.Object);
            await service.ExcluirFornecedor(modelo);

            mock.Verify(y => y.Delete(modelo));
        }

        [Fact]
        public async Task RetornaPorId()
        {
            mock.Setup(y => y.GetEntityById(MockFornecedor.MontaObjetoUnico().Id)).ReturnsAsync(MockFornecedor.MontaObjetoUnico());
            FornecedorApiController ret = new FornecedorApiController(mock.Object);
            var result = await ret.RetornaFornecedorPorId(1);
            //Assert.Equal("Teste Mock 1", ((Data.Entidades.Fornecedor)result.Value).NomeFornecedor);
        }

        [Fact]
        public async Task RetornoLista()
        {
            mock.Setup(repo => repo.List()).ReturnsAsync(MockFornecedor.MontaListaItems());
            var controller = new FornecedorApiController(mock.Object);
            var result = await controller.ListaFornecedor();
            var viewResult = Assert.IsType<List<Fornecedor>>(result.Value);

            Assert.Equal(3, viewResult.Count);
        }
    }
}
