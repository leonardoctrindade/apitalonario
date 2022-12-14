using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class VendedorApiController: Controller
    {
        private readonly IVendedor IVendedor;

        public VendedorApiController(IVendedor IVendedor)
        {
            this.IVendedor = IVendedor;
        }

        [HttpGet("/api/ListaVendedor")]
        public async Task<JsonResult> ListaVendedor()
        {
            return Json(await this.IVendedor.List());
        }

        [HttpPost("/api/AdicionarVendedor")]
        public async Task<JsonResult> AdicionarVendedor([FromBody] Vendedor Vendedor)
        {
            if (String.IsNullOrEmpty(Vendedor.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IVendedor.Add(Vendedor)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaVendedorPorId/{id}")]
        public async Task<JsonResult> RetornaVendedorPorId(int id)
        {
            return Json(await this.IVendedor.GetEntityById(id));
        }

        [HttpPost("/api/EditarVendedor")]
        public async Task<JsonResult> EditarVendedor([FromBody] Vendedor Vendedor)
        {
            if (String.IsNullOrEmpty(Vendedor.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IVendedor.Update(Vendedor)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirVendedor")]
        public async Task ExcluirVendedor([FromBody] Vendedor Vendedor)
        {
            await Task.FromResult(this.IVendedor.Delete(Vendedor));
        }
    }
}
