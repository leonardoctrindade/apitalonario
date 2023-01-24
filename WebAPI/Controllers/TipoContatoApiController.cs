using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class TipoContatoApiController: Controller
    {
        private readonly ITipoContato ITipoContato;

        public TipoContatoApiController(ITipoContato ITipoContato)
        {
            this.ITipoContato = ITipoContato;
        }

        [HttpGet("/api/ListaPaginacaoTipoContato/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var tipoContatos = await this.ITipoContato.List();

                var total = Convert.ToDouble(tipoContatos.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ITipoContato.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : tipoContatos);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os tipos de contatos " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarTipoContato([FromBody] TipoContato TipoContato)
        {
            try
            {
                if (string.IsNullOrEmpty(TipoContato.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

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
        public async Task<IActionResult> EditarTipoContato([FromBody] TipoContato TipoContato)
        {
            try
            {
                if (string.IsNullOrEmpty(TipoContato.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

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
