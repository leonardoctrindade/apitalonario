using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace WebAPI.Controllers
{
    public class EspecificacaoCapsulaApiController: Controller
    {
        private readonly IEspecificacaoCapsula IEspecificacaoCapsula;

        public EspecificacaoCapsulaApiController(IEspecificacaoCapsula IEspecificacaoCapsula)
        {
            this.IEspecificacaoCapsula = IEspecificacaoCapsula;
        }

        [HttpGet("/api/ListaPaginacaoEspecificacaoCapsula/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var especificacaoCapsulas = await this.IEspecificacaoCapsula.List();

                var total = Convert.ToDouble(especificacaoCapsulas.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IEspecificacaoCapsula.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : especificacaoCapsulas);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as especificaoes capsula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaEspecificacaoCapsula")]
        public async Task<JsonResult> ListaEspecificacaoCapsula()
        {
            try
            {
                return Json(await this.IEspecificacaoCapsula.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as especificações da capsula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarEspecificacaoCapsula")]
        public async Task<IActionResult> AdicionarEspecificacaoCapsula([FromBody] EspecificacaoCapsula EspecificacaoCapsula)
        {
            try
            {
                if (String.IsNullOrEmpty(EspecificacaoCapsula.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IEspecificacaoCapsula.Add(EspecificacaoCapsula)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a especificação da capsula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaEspecificacaoCapsulaPorId/{id}")]
        public async Task<JsonResult> RetornaEspecificacaoCapsulaPorId(int id)
        {
            try
            {
                return Json(await this.IEspecificacaoCapsula.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a especificação da capsula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarEspecificacaoCapsula")]
        public async Task<IActionResult> EditarEspecificacaoCapsula([FromBody] EspecificacaoCapsula EspecificacaoCapsula)
        {
            try
            {
                if (String.IsNullOrEmpty(EspecificacaoCapsula.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IEspecificacaoCapsula.Update(EspecificacaoCapsula)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a especificação da capsula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirEspecificacaoCapsula")]
        public async Task<JsonResult> ExcluirEspecificacaoCapsula([FromBody] EspecificacaoCapsula EspecificacaoCapsula)
        {
            try
            {
                Json(await Task.FromResult(this.IEspecificacaoCapsula.Delete(EspecificacaoCapsula)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a especificação da capsula " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
