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
            try
            {
                return Json(await this.IVendedor.List());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os vendedores " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarVendedor")]
        public async Task<JsonResult> AdicionarVendedor([FromBody] Vendedor Vendedor)
        {
            try
            {
                if (String.IsNullOrEmpty(Vendedor.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IVendedor.Add(Vendedor)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o vendedor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaVendedorPorId/{id}")]
        public async Task<JsonResult> RetornaVendedorPorId(int id)
        {
            try
            {
                return Json(await this.IVendedor.GetVendedor(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o vendedor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarVendedor")]
        public async Task<JsonResult> EditarVendedor([FromBody] Vendedor Vendedor)
        {
            try
            {
                if (String.IsNullOrEmpty(Vendedor.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IVendedor.Update(Vendedor)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o vendedor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirVendedor")]
        public async Task<JsonResult> ExcluirVendedor([FromBody] Vendedor Vendedor)
        {
            try
            {
                Json(await Task.FromResult(this.IVendedor.Delete(Vendedor)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o vendedor " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
