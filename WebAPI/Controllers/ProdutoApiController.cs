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


        [HttpGet("/api/ListaProdutos")]
        public async Task<JsonResult> ListaProdutos()
        {
            return Json(await this.IProduto.List());
        }


        [HttpPost("/api/AdicionarProduto")]
        public async Task AdicionarProduto([FromBody] Produto produto)
        {
            await Task.FromResult(this.IProduto.Add(produto));
        }


    }
}
