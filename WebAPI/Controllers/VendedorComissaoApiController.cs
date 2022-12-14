using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class VendedorComissaoApiController: Controller
    {
        private readonly IVendedorComissao IVendedorComissao;

        public VendedorComissaoApiController(IVendedorComissao IVendedorComissao)
        {
            this.IVendedorComissao = IVendedorComissao;
        }

        [HttpGet("/api/ListaVendedorComissao")]
        public async Task<JsonResult> ListaVendedorComissao()
        {
            return Json(await this.IVendedorComissao.List());
        }

        [HttpPost("/api/AdicionarVendedorComissao")]
        public async Task<JsonResult> AdicionarVendedorComissao([FromBody] VendedorComissao VendedorComissao)
        {
            Json(await Task.FromResult(this.IVendedorComissao.Add(VendedorComissao)));
            return Json(Ok());
        }

        [HttpGet("/api/RetornaVendedorComissaoPorId/{id}")]
        public async Task<JsonResult> RetornaVendedorComissaoPorId(int id)
        {
            return Json(await this.IVendedorComissao.GetEntityById(id));
        }

        [HttpPost("/api/EditarVendedorComissao")]
        public async Task<JsonResult> EditarVendedorComissao([FromBody] VendedorComissao VendedorComissao)
        {
            Json(await Task.FromResult(this.IVendedorComissao.Update(VendedorComissao)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirVendedorComissao")]
        public async Task ExcluirVendedorComissao([FromBody] VendedorComissao VendedorComissao)
        {
            await Task.FromResult(this.IVendedorComissao.Delete(VendedorComissao));
        }
    }
}
