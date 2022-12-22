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

        [HttpGet("/api/ListaBairro")]
        public async Task<JsonResult> ListaBairro()
        {
            try
            {
                return Json(await this.IBairro.List());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os bairros " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarBairro")]
        public async Task<JsonResult> AdicionarBairro([FromBody] Bairro Bairro)
        {
            try 
            {
                if (String.IsNullOrEmpty(Bairro.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IBairro.Add(Bairro)));

                return Json(Ok());
            } catch(Exception ex) 
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
            } catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o bairro " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarBairro")]
        public async Task<JsonResult> EditarBairro([FromBody] Bairro Bairro)
        {
            try
            {
                if (String.IsNullOrEmpty(Bairro.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IBairro.Update(Bairro)));
                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o bairro " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirBairro")]
        public async Task<JsonResult> ExcluirBairro([FromBody] Bairro Bairro)
        {
            try
            {
                return Json(await Task.FromResult(this.IBairro.Delete(Bairro)));
            } catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o bairro " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
