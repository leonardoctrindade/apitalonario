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
    public class DcbApiController : Controller
    {
        private readonly IDcb iDcb;

        public DcbApiController(IDcb idcb)
        {
            iDcb = idcb;
        }

        [HttpGet("/api/ListarDcb")]
        public async Task<JsonResult> ListarDcb()
        {
            try
            {
                return Json(await this.iDcb.List());
            } catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os dcbs " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarDcb")]
        public async Task<JsonResult> AdicionarDcb([FromBody] Dcb dcb)
        {
            try
            {
                if (string.IsNullOrEmpty(dcb.Descricao) || string.IsNullOrEmpty(dcb.CodigoDcb))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.iDcb.Add(dcb)));

                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o dcb " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarDcbPorId/{id}")]
        public async Task<JsonResult> RetornarDcbPorId(int id)
        {
            try
            {
                return Json(await this.iDcb.GetEntityById(id));
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o dcb " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarDcb")]
        public async Task<JsonResult> EditarDcb([FromBody] Dcb dcb)
        {
            try
            {
                if (string.IsNullOrEmpty(dcb.Descricao) || string.IsNullOrEmpty(dcb.CodigoDcb))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.iDcb.Update(dcb)));

                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o dcb " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("api/ExcluirDcb")]
        public async Task<JsonResult> ExcluirDcb([FromBody] Dcb dcb)
        {
            try
            {
                Json(await Task.FromResult(this.iDcb.Delete(dcb)));
                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o dcb " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
