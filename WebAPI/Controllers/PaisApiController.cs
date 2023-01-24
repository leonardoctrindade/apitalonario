using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class PaisApiController : Controller
    {
        private readonly IPais IPais;

        public PaisApiController(IPais IPais)
        {
            this.IPais = IPais;
        }


        [HttpGet("/api/ListaPaginacaoPais/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var paises = await this.IPais.List();

                var total = Convert.ToDouble(paises.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IPais.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : paises);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os paises " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaPais")]
        public async Task<JsonResult> ListaPais()
        {
            try
            {
                return Json(await this.IPais.List());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os paises " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarPais")]
        public async Task<IActionResult> AdicionarPais([FromBody] Pais Pais)
        {
            try
            {
                if (String.IsNullOrEmpty(Pais.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

                Json(await Task.FromResult(this.IPais.Add(Pais)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o pais " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaPaisPorId/{id}")]
        public async Task<JsonResult> RetornaPaisPorId(int id)
        {
            try
            {
                return Json(await this.IPais.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o pais " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarPais")]
        public async Task<IActionResult> EditarPais([FromBody] Pais Pais)
        {
            try
            {
                if(String.IsNullOrEmpty(Pais.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

                Json(await Task.FromResult(this.IPais.Update(Pais)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o pais " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirPais")]
        public async Task<JsonResult> ExcluirPais([FromBody] Pais Pais)
        {
            try
            {
                Json(await Task.FromResult(this.IPais.Delete(Pais)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o pais " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
