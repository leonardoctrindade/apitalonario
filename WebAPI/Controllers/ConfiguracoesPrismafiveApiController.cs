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
    public class ConfiguracoesPrismafiveApiController : Controller
    {
        private readonly IConfiguracoesPrismafive IConfiguracoesPrismafive;

        public ConfiguracoesPrismafiveApiController(IConfiguracoesPrismafive IConfiguracoesPrismafive)
        {
            this.IConfiguracoesPrismafive = IConfiguracoesPrismafive;
        }

        [HttpGet("/api/ListaConfiguracoesPrismafive")]
        public async Task<JsonResult> ListaConfiguracoesPrismafive()
        {
            try
            {
                return Json(await this.IConfiguracoesPrismafive.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as configuracoes prismafive " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarConfiguracoesPrismafive")]
        public async Task<JsonResult> AdicionarConfiguracoesPrismafive([FromBody] ConfiguracoesPrismafive ConfiguracoesPrismafive)
        {
            try
            {
                if (String.IsNullOrEmpty(ConfiguracoesPrismafive.Secao) || String.IsNullOrEmpty(ConfiguracoesPrismafive.UserMac) || String.IsNullOrEmpty(ConfiguracoesPrismafive.Chave))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IConfiguracoesPrismafive.Add(ConfiguracoesPrismafive)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar a configuracao prismafive " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaConfiguracoesPrismafivePorId/{id}")]
        public async Task<JsonResult> RetornaConfiguracoesPrismafivePorId(int id)
        {
            try
            {
                return Json(await this.IConfiguracoesPrismafive.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a configuracao prismafive " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarConfiguracoesPrismafive")]
        public async Task<JsonResult> EditarConfiguracoesPrismafive([FromBody] ConfiguracoesPrismafive ConfiguracoesPrismafive)
        {
            try
            {
                if (String.IsNullOrEmpty(ConfiguracoesPrismafive.Secao) || String.IsNullOrEmpty(ConfiguracoesPrismafive.UserMac) || String.IsNullOrEmpty(ConfiguracoesPrismafive.Chave))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IConfiguracoesPrismafive.Update(ConfiguracoesPrismafive)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a configuracao prismafive " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirConfiguracoesPrismafive")]
        public async Task<JsonResult> ExcluirConfiguracoesPrismafive([FromBody] ConfiguracoesPrismafive ConfiguracoesPrismafive)
        {
            try
            {
                Json(await Task.FromResult(this.IConfiguracoesPrismafive.Delete(ConfiguracoesPrismafive)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a configuracao prismafive " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
