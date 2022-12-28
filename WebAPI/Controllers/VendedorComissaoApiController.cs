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
            try
            {
                return Json(await this.IVendedorComissao.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as comissões do vendedor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarVendedorComissao")]
        public async Task<JsonResult> AdicionarVendedorComissao([FromBody] VendedorComissao VendedorComissao)
        {
            try
            {
                Json(await Task.FromResult(this.IVendedorComissao.Add(VendedorComissao)));
                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a comissão do vendedor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaVendedorComissaoPorId/{id}")]
        public async Task<JsonResult> RetornaVendedorComissaoPorId(int id)
        {
            try
            {
                return Json(await this.IVendedorComissao.GetVendedorComissao(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a comissão do vendedor " + ex.Message }) { StatusCode = 400 };
            }
            
        }

        [HttpPost("/api/EditarVendedorComissao")]
        public async Task<JsonResult> EditarVendedorComissao([FromBody] VendedorComissao VendedorComissao)
        {
            try
            {
                Json(await Task.FromResult(this.IVendedorComissao.Update(VendedorComissao)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a comissão do vendedor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirVendedorComissao")]
        public async Task<JsonResult> ExcluirVendedorComissao([FromBody] VendedorComissao VendedorComissao)
        {
            try
            {
                return Json(await Task.FromResult(this.IVendedorComissao.Delete(VendedorComissao)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a comissão do vendedor " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
