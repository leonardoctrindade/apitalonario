using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class VendedorApiController: Controller
    {
        private readonly IVendedor IVendedor;

        public VendedorApiController(IVendedor IVendedor)
        {
            this.IVendedor = IVendedor;
        }

        [HttpGet("/api/ListaPaginacaoVendedor/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var vendedores = await this.IVendedor.List();

                var total = Convert.ToDouble(vendedores.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IVendedor.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : vendedores);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os vendedores " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarVendedor([FromBody] Vendedor Vendedor)
        {
            try
            {
                if (String.IsNullOrEmpty(Vendedor.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

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
        public async Task<IActionResult> EditarVendedor([FromBody] Vendedor Vendedor)
        {
            try
            {
                if (String.IsNullOrEmpty(Vendedor.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

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
