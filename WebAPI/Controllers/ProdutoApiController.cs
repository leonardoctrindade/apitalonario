using System;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Authorize]
    public class ProdutoApiController : Controller
    {
        private readonly IProduto IProduto;
        public ProdutoApiController(IProduto IProduto)
        {
            this.IProduto = IProduto;
        }

        [HttpGet("/api/ListaPaginacaoProduto/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var produtos = await this.IProduto.List();

                var total = Convert.ToDouble(produtos.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IProduto.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : produtos);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os produtos " + ex.Message }) { StatusCode = 400 };
            }
        }


        [HttpGet("/api/ListaProdutos")]
        public async Task<JsonResult> ListaProdutos()
        {
            try
            {
                return Json(await this.IProduto.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os produtos " + ex.Message }) { StatusCode = 400 };
            }
        }


        [HttpPost("/api/AdicionarProduto")]
        public async Task<JsonResult> AdicionarProduto([FromBody] Produto produto)
        {
            try
            {
                return Json(await Task.FromResult(this.IProduto.Add(produto)));
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o produto " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
