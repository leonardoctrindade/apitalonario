using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class AdministradoraCartaoApiController: Controller
    {
        private readonly IAdministradoraCartao IAdministradoraCartao;

        public AdministradoraCartaoApiController(IAdministradoraCartao IAdministradoraCartao)
        {
            this.IAdministradoraCartao = IAdministradoraCartao;
        }

        [HttpGet("/api/ListaAdministradoraCartao")]
        public async Task<JsonResult> ListaAdministradoraCartao()
        {
            return Json(await this.IAdministradoraCartao.List());
        }

        [HttpPost("/api/AdicionarAdministradoraCartao")]
        public async Task<JsonResult> AdicionarAdministradoraCartao([FromBody] AdministradoraCartao AdministradoraCartao)
        {
            if (String.IsNullOrEmpty(AdministradoraCartao.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IAdministradoraCartao.Add(AdministradoraCartao)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaAdministradoraCartaoPorId/{id}")]
        public async Task<JsonResult> RetornaAdministradoraCartaoPorId(int id)
        {
            return Json(await this.IAdministradoraCartao.GetEntityById(id));
        }

        [HttpPost("/api/EditarAdministradoraCartao")]
        public async Task<JsonResult> EditarAdministradoraCartao([FromBody] AdministradoraCartao AdministradoraCartao)
        {
            if (String.IsNullOrEmpty(AdministradoraCartao.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IAdministradoraCartao.Update(AdministradoraCartao)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirAdministradoraCartao")]
        public async Task ExcluirAdministradoraCartao([FromBody] AdministradoraCartao AdministradoraCartao)
        {
            await Task.FromResult(this.IAdministradoraCartao.Delete(AdministradoraCartao));
        }
    }
}
