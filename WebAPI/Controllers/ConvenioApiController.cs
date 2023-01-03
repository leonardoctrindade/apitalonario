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
    public class ConvenioApiController: Controller
    {
        public readonly IConvenio IConvenio;

        public ConvenioApiController(IConvenio IConvenio)
        {
            this.IConvenio = IConvenio;
        }

        [HttpGet("/api/ListaConvenio")]
        public async Task<JsonResult> ListaConvenio()
        {
            try
            {
                return Json(await this.IConvenio.List());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os convenios " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarConvenio")]
        public async Task<JsonResult> AdicionarConvenio([FromBody] Convenio Convenio)
        {
            try
            {
                if (String.IsNullOrEmpty(Convenio.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IConvenio.Add(Convenio)));

                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o convenio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaConvenioPorId/{id}")]
        public async Task<JsonResult> RetornaConvenioPorId(int id)
        {
            try
            {
                return Json(await this.IConvenio.GetConvenio(id));
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao retornar o convenio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarConvenio")]
        public async Task<JsonResult> EditarConvenio([FromBody] Convenio Convenio)
        {
            try
            {
                if (String.IsNullOrEmpty(Convenio.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IConvenio.Update(Convenio)));
                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o convenio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirConvenio")]
        public async Task<JsonResult> ExcluirConvenio([FromBody] Convenio Convenio)
        {
            try
            {
                Json(await Task.FromResult(this.IConvenio.Delete(Convenio)));
                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o convenio " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
