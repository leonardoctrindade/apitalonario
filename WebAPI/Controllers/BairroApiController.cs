using System;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    public class BairroApiController : Controller
    {
        private readonly IBairro IBairro;

        public BairroApiController(IBairro iBairro)
        {
            this.IBairro = iBairro;
        }

        [HttpGet("/api/ListaPaginacaoBairro/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var bairros = await this.IBairro.List();

                var total = Convert.ToDouble(bairros.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IBairro.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : bairros);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os bairros " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaBairro")]
        public async Task<JsonResult> ListaBairro()
        {
            try
            {
                return Json(await this.IBairro.List());
            } 
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os bairros " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarBairro")]
        public async Task<IActionResult> AdicionarBairro([FromBody] Bairro Bairro)
        {
            try 
            {
                if (String.IsNullOrEmpty(Bairro.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

                Json(await Task.FromResult(this.IBairro.Add(Bairro)));

                return Json(Ok());
            } 
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o bairro " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaBairroPorId/{id}")]
        public async Task<JsonResult> RetornaBairroPorId(int id)
        {
            try
            {
                return Json(await this.IBairro.GetEntityById(id));
            } 
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o bairro " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarBairro")]
        public async Task<IActionResult> EditarBairro([FromBody] Bairro Bairro)
        {
            try
            {
                if (String.IsNullOrEmpty(Bairro.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

                Json(await Task.FromResult(this.IBairro.Update(Bairro)));
                return Json(Ok());
            } 
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o bairro " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirBairro")]
        public async Task<JsonResult> ExcluirBairro([FromBody] Bairro Bairro)
        {
            try
            {
                Json(await Task.FromResult(this.IBairro.Delete(Bairro)));
                return Json(Ok());
            } 
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o bairro " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
