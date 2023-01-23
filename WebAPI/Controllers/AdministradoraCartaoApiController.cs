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
    public class AdministradoraCartaoApiController: Controller
    {
        private readonly IAdministradoraCartao IAdministradoraCartao;

        public AdministradoraCartaoApiController(IAdministradoraCartao IAdministradoraCartao)
        {
            this.IAdministradoraCartao = IAdministradoraCartao;
        }

        [HttpGet("/api/ListaPaginacaoAdministradoraCartao/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var administradoraCartaoes = await this.IAdministradoraCartao.List();

                var total = Convert.ToDouble(administradoraCartaoes.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IAdministradoraCartao.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : administradoraCartaoes);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as administradoras de cartão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaAdministradoraCartao")]
        public async Task<JsonResult> ListaAdministradoraCartao()
        {
            try
            {
                return Json(await this.IAdministradoraCartao.List());
            } catch (Exception ex)
            {
                return new JsonResult( new { message = "Error ao listar os administradores de cartão " + ex.Message }) { StatusCode = 400 };
            }

        }

        [HttpPost("/api/AdicionarAdministradoraCartao")]
        public async Task<IActionResult> AdicionarAdministradoraCartao([FromBody] AdministradoraCartao AdministradoraCartao)
        {
            try
            {
                if (String.IsNullOrEmpty(AdministradoraCartao.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

                Json(await Task.FromResult(this.IAdministradoraCartao.Add(AdministradoraCartao)));

                return Json(Ok());
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o adiministrador de cartão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaAdministradoraCartaoPorId/{id}")]
        public async Task<JsonResult> RetornaAdministradoraCartaoPorId(int id)
        {
            try
            {
                return Json(await this.IAdministradoraCartao.GetAdministradoraCartao(id));
            } catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o adiministrador de cartão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarAdministradoraCartao")]
        public async Task<IActionResult> EditarAdministradoraCartao([FromBody] AdministradoraCartao AdministradoraCartao)
        {
            try
            {
                if (String.IsNullOrEmpty(AdministradoraCartao.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

                Json(await Task.FromResult(this.IAdministradoraCartao.Update(AdministradoraCartao)));
                return Json(Ok());
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o adiministrador de cartão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirAdministradoraCartao")]
        public async Task<JsonResult> ExcluirAdministradoraCartao([FromBody] AdministradoraCartao AdministradoraCartao)
        {
            try
            {
                Json(await Task.FromResult(this.IAdministradoraCartao.Delete(AdministradoraCartao)));
                return Json(Ok());
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o adiministrador de cartão " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
