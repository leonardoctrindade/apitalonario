using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class VendedorComissaoApiController: Controller
    {
        private readonly IVendedorComissao IVendedorComissao;

        public VendedorComissaoApiController(IVendedorComissao IVendedorComissao)
        {
            this.IVendedorComissao = IVendedorComissao;
        }

        [HttpGet("/api/ListaPaginacaoVendedorComissao/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var vendedores = await this.IVendedorComissao.List();

                var total = Convert.ToDouble(vendedores.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IVendedorComissao.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : vendedores);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os vendedores comissao " + ex.Message }) { StatusCode = 400 };
            }
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
                Json(await Task.FromResult(this.IVendedorComissao.Delete(VendedorComissao)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a comissão do vendedor " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
