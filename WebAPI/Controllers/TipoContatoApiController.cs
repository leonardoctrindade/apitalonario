using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class TipoContatoApiController: Controller
    {
        private readonly ITipoContato ITipoContato;

        public TipoContatoApiController(ITipoContato ITipoContato)
        {
            this.ITipoContato = ITipoContato;
        }

        [HttpGet("/api/ListaTipoContato")]
        public async Task<JsonResult> ListaTipoContato()
        {
            try
            {
                return Json(await this.ITipoContato.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os tipos de contatos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarTipoContato")]
        public async Task<JsonResult> AdicionarTipoContato([FromBody] TipoContato TipoContato)
        {
            try
            {
                if (String.IsNullOrEmpty(TipoContato.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ITipoContato.Add(TipoContato)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o tipo de contato " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaTipoContatoPorId/{id}")]
        public async Task<JsonResult> RetornaTipoContatoPorId(int id)
        {
            try
            {
                return Json(await this.ITipoContato.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o tipo de contato " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarTipoContato")]
        public async Task<JsonResult> EditarTipoContato([FromBody] TipoContato TipoContato)
        {
            try
            {
                if (String.IsNullOrEmpty(TipoContato.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ITipoContato.Update(TipoContato)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o tipo de contato " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirTipoContato")]
        public async Task<JsonResult> ExcluirTipoContato([FromBody] TipoContato TipoContato)
        {
            try
            {
                Json(await Task.FromResult(this.ITipoContato.Delete(TipoContato)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o tipo de contato " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
