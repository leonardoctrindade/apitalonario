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
    public class DciApiController : Controller
    {
        private readonly IDci IDci;
        
        public DciApiController(IDci idci)
        {
            IDci = idci;
        }

        [HttpGet("/api/ListaDci")]
        public async Task<JsonResult> ListaDci()
        {
            try
            {
                return Json(await this.IDci.List());
            } catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os dci " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarDci")]
        public async Task<JsonResult> AdicionarDci([FromBody] Dci dci)
        {
            try
            {
                if (string.IsNullOrEmpty(dci.CodigoDci) || string.IsNullOrEmpty(dci.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IDci.Add(dci)));

                return Json(Ok());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o dci " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarPorId/{id}")]
        public async Task<JsonResult> RetornarPorId(int id)
        {
            try
            {
                return Json(await this.IDci.GetEntityById(id));
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o dci " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarDci")]
        public async Task<JsonResult> EditarDci([FromBody] Dci dci)
        {
            try
            {
                if (string.IsNullOrEmpty(dci.CodigoDci) || string.IsNullOrEmpty(dci.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IDci.Update(dci)));

                return Json(Ok());
            } catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o dci " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirDci")]
        public async Task<JsonResult> ExcluirDci([FromBody] Dci dci)
        {
            try
            {
                return Json(await Task.FromResult(this.IDci.Delete(dci)));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o dci " + ex.Message }) { StatusCode = 400 };
            }

        }
    }
}
