using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class DiferimentoApiController : Controller
    {
        private readonly IDiferimento IDiferimento;

        public DiferimentoApiController(IDiferimento IDiferimento)
        {
            this.IDiferimento = IDiferimento;
        }

        [HttpGet("/api/ListaDiferimento")]
        public async Task<JsonResult> ListaDiferimento()
        {
            try
            {
                return Json(await this.IDiferimento.List());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os diferimentos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarDiferimento")]
        public async Task<JsonResult> AdicionarDiferimento([FromBody] Diferimento Diferimento)
        {
            try
            {
                if (String.IsNullOrEmpty(Diferimento.Cst))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Diferimento.SiglaEstado))
                    return Json(BadRequest(ModelState));
                if (Diferimento.AliquotaDiferimento <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IDiferimento.Add(Diferimento)));

                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o diferimento " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaDiferimentoPorId/{id}")]
        public async Task<JsonResult> RetornaDiferimentoPorId(int id)
        {
            try
            {
                return Json(await this.IDiferimento.GetEntityById(id));
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao retornar o diferimento " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarDiferimento")]
        public async Task<JsonResult> EditarDiferimento([FromBody] Diferimento Diferimento)
        {
            try
            {
                if (String.IsNullOrEmpty(Diferimento.Cst))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Diferimento.SiglaEstado))
                    return Json(BadRequest(ModelState));
                if (Diferimento.AliquotaDiferimento <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IDiferimento.Update(Diferimento)));
                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o diferimento " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirDiferimento")]
        public async Task<JsonResult> ExcluirDiferimento([FromBody] Diferimento Diferimento)
        {
            try
            {
                return Json(await Task.FromResult(this.IDiferimento.Delete(Diferimento)));
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o diferimento " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
