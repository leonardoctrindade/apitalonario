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
    public class AcompanhamentoPessoalApiController : Controller
    {
        private readonly IAcompanhamentoPessoal IAcompanhamentoPessoal;

        public AcompanhamentoPessoalApiController(IAcompanhamentoPessoal IAcompanhamentoPessoal)
        {
            this.IAcompanhamentoPessoal = IAcompanhamentoPessoal;
        }

        [HttpGet("/api/ListaAcompanhamentoPessoal")]
        public async Task<JsonResult> ListaAcompanhamentoPessoal()
        {
            try
            {
                return Json(await this.IAcompanhamentoPessoal.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os acompanhamentos pessoal " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarAcompanhamentoPessoal")]
        public async Task<JsonResult> AdicionarAcompanhamentoPessoal([FromBody] AcompanhamentoPessoal AcompanhamentoPessoal)
        {
            try
            {
                if (!AcompanhamentoPessoal.Data.HasValue || AcompanhamentoPessoal.ClienteId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IAcompanhamentoPessoal.Add(AcompanhamentoPessoal)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o AcompanhamentoPessoal" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaAcompanhamentoPessoalPorId/{id}")]
        public async Task<JsonResult> RetornaAcompanhamentoPessoalPorId(int id)
        {
            try
            {
                return Json(await this.IAcompanhamentoPessoal.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o AcompanhamentoPessoal " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarAcompanhamentoPessoal")]
        public async Task<JsonResult> EditarAcompanhamentoPessoal([FromBody] AcompanhamentoPessoal AcompanhamentoPessoal)
        {
            try
            {
                if (!AcompanhamentoPessoal.Data.HasValue || AcompanhamentoPessoal.ClienteId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IAcompanhamentoPessoal.Update(AcompanhamentoPessoal)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o AcompanhamentoPessoal " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirAcompanhamentoPessoal")]
        public async Task<JsonResult> ExcluirAcompanhamentoPessoal([FromBody] AcompanhamentoPessoal AcompanhamentoPessoal)
        {
            try
            {
                Json(await Task.FromResult(this.IAcompanhamentoPessoal.Delete(AcompanhamentoPessoal)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o AcompanhamentoPessoal " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
