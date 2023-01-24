using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class GrupoApiController: Controller
    {
        private readonly IGrupo IGrupo;

        public GrupoApiController(IGrupo IGrupo)
        {
            this.IGrupo = IGrupo;
        }

        [HttpGet("/api/ListaPaginacaoGrupo/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var grupos = await this.IGrupo.List();

                var total = Convert.ToDouble(grupos.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IGrupo.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : grupos);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os grupos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaGrupo")]
        public async Task<JsonResult> ListaGrupo()
        {
            try
            {
                return Json(await this.IGrupo.List());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os grupos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarGrupo")]
        public async Task<IActionResult> AdicionarGrupo([FromBody] Grupo Grupo)
        {
            try
            {
                if (String.IsNullOrEmpty(Grupo.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (Grupo.PercentualDesconto <= 0)
                    return BadRequest("campo de percentual de desconto é obrigatório");

                Json(await Task.FromResult(this.IGrupo.Add(Grupo)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o grupo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaGrupoPorId/{id}")]
        public async Task<JsonResult> RetornaGrupoPorId(int id)
        {
            try
            {
                return Json(await this.IGrupo.GetGrupo(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o grupo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarGrupo")]
        public async Task<IActionResult> EditarGrupo([FromBody] Grupo Grupo)
        {
            try
            {
                if (String.IsNullOrEmpty(Grupo.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (Grupo.PercentualDesconto <= 0)
                    return BadRequest("campo de percentual de desconto é obrigatório");

                Json(await Task.FromResult(this.IGrupo.Update(Grupo)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o grupo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirGrupo")]
        public async Task<JsonResult> ExcluirGrupo([FromBody] Grupo Grupo)
        {
            try
            {
                Json(await Task.FromResult(this.IGrupo.Delete(Grupo)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o grupo " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
