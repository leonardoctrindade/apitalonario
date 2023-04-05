using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AgenteApiController : Controller
    {
        private readonly IAgente iAgente;
        public AgenteApiController(IAgente iAgente)
        {
            this.iAgente = iAgente;
        }


        [HttpGet("/api/ListaAgente")]
        public async Task<JsonResult> ListaAgente()
        {

            return Json(await this.iAgente.List());
        }


        [HttpPost("/api/AdicionarAgente")]
        public async Task<JsonResult> AdicionarAgente([FromBody] Agente Agente)
        {
            if (String.IsNullOrEmpty(Agente.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.iAgente.Add(Agente)));

            return Json(Ok());
        }


        [HttpGet("/api/RetornaAgentePorId/{id}")]
        public async Task<JsonResult> RetornaAgentePorId(int id)
        {
            return Json(await this.iAgente.GetEntityById(id));
        }

        [HttpPost("/api/EditarAgente")]
        public async Task<JsonResult> EditarAgente([FromBody] Agente Agente)
        {
            if (String.IsNullOrEmpty(Agente.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.iAgente.Update(Agente)));
            return Json(Ok());

        }

        [HttpPost("/api/ExcluirBpm")]
        public async Task ExcluirBpm([FromBody] Agente Agente)
        {
            await Task.FromResult(this.iAgente.Delete(Agente));
        }

    }
}