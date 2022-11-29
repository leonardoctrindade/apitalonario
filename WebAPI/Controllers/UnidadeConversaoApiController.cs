using System;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography.X509Certificates;

namespace WebAPI.Controllers
{
    public class UnidadeConversaoApiController : Controller
    {
        private readonly IUnidadeConversao IUnidadeConversao;

        public UnidadeConversaoApiController(IUnidadeConversao iUnidadeConversao)
        {
            IUnidadeConversao = iUnidadeConversao;
        }

        [HttpGet("/api/ListaUnidadeConversao")]
        public async Task<JsonResult> ListaUnidadeConversao()
        {
            return Json(await this.IUnidadeConversao.List());
        }

        [HttpPost("/api/AdicionarUnidadeConversao")]
        public async Task<JsonResult> AdicionarUnidadeConversao([FromBody] UnidadeConversao unidadeConversao)
        {
            if(string.IsNullOrEmpty(unidadeConversao.Sigla) || string.IsNullOrEmpty(unidadeConversao.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IUnidadeConversao.Add(unidadeConversao)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornarUnidadeConversaoPorId/{id}")]
        public async Task<JsonResult> RetornarUnidadeConversaoPorId(int id)
        {
            return Json(await this.IUnidadeConversao.GetEntityById(id));
        }

        [HttpPost("/api/EditarUnidadeConversao")]
        public async Task<JsonResult> EditarUnidadeConversao([FromBody] UnidadeConversao unidadeConversao)
        {
            if (string.IsNullOrEmpty(unidadeConversao.Sigla) || string.IsNullOrEmpty(unidadeConversao.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IUnidadeConversao.Update(unidadeConversao)));

            return Json(Ok());
        }

        [HttpPost("/api/ExcluirUnidadeConversao")]
        public async Task ExcluirUnidadeConversao([FromBody] UnidadeConversao unidadeConversao)
        {
            await Task.FromResult(this.IUnidadeConversao.Delete(unidadeConversao));
        }
        [HttpGet("/api/RetornarConversaoVinculada/{id}")]
        public async Task<JsonResult> RetornarConversaoVinculada(int id)
        {
            var Unidades = new List<UnidadeConversao>();
            var unidades = await this.IUnidadeConversao.List();

            foreach (var x in unidades)
            {
                if (x.IdUnidade == id)
                    Unidades.Add(x);
            }
            return Json(Unidades);
        }
        [HttpPost("/api/AdicionarListaUnidades")]
        public async Task<JsonResult> AdicionarListaUnidades([FromBody] List<UnidadeConversao> unidadeConversaos)
        {
            foreach (var x in unidadeConversaos)
            {
                Json(await Task.FromResult(this.IUnidadeConversao.Add(x)));

               
            }
            return Json(Ok());
        }
        
    }

}


