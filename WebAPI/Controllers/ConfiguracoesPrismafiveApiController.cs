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

        [HttpGet("/api/ListaPaginacaoConfiguracoesPrismafive/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var configuracoes = await this.IConfiguracoesPrismafive.List();

                var total = Convert.ToDouble(configuracoes.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IConfiguracoesPrismafive.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : configuracoes);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as configurações prismafive " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarConfiguracoesPrismafive([FromBody] ConfiguracoesPrismafive ConfiguracoesPrismafive)
        {
            try
            {
                if (string.IsNullOrEmpty(ConfiguracoesPrismafive.Secao.Trim()))
                    return BadRequest("Campo de seção é obrigatorio");
                if (string.IsNullOrEmpty(ConfiguracoesPrismafive.UserMac))
                    return BadRequest("Campo de UserMac é obrigatório");
                if (string.IsNullOrEmpty(ConfiguracoesPrismafive.Chave.Trim()))
                    return BadRequest("Campo de chave é obrigatório");

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
        public async Task<IActionResult> EditarConfiguracoesPrismafive([FromBody] ConfiguracoesPrismafive ConfiguracoesPrismafive)
        {
            try
            {
                if (string.IsNullOrEmpty(ConfiguracoesPrismafive.Secao.Trim()))
                    return BadRequest("Campo de seção é obrigatorio");
                if (string.IsNullOrEmpty(ConfiguracoesPrismafive.UserMac))
                    return BadRequest("Campo de UserMac é obrigatório");
                if (string.IsNullOrEmpty(ConfiguracoesPrismafive.Chave.Trim()))
                    return BadRequest("Campo de chave é obrigatório");

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
