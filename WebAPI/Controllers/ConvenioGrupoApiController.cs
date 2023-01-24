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
    public class ConvenioGrupoApiController: Controller
    {
        private readonly IConvenioGrupo IConvenioGrupo;

        public ConvenioGrupoApiController(IConvenioGrupo IConvenioGrupo)
        {
            this.IConvenioGrupo = IConvenioGrupo;
        }

        [HttpGet("/api/ListaPaginacaoConvenioGrupo/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var conveniosgrupos = await this.IConvenioGrupo.List();

                var total = Convert.ToDouble(conveniosgrupos.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IConvenioGrupo.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : conveniosgrupos);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os convenios grupos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaConvenioGrupo")]
        public async Task<JsonResult> ListaConvenioGrupo()
        {
            try
            {
                return Json(await this.IConvenioGrupo.List());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os grupos de convenio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarConvenioGrupo")]
        public async Task<IActionResult> AdicionarConvenioGrupo([FromBody] ConvenioGrupo ConvenioGrupo)
        {
            try
            {
                if (ConvenioGrupo.GrupoId == 0)
                    return BadRequest("Campo de grupo é obrigatório");
                if (ConvenioGrupo.ConvenioId == 0)
                    return BadRequest("Campo de convenio é obrigatório");
                if (ConvenioGrupo.Desconto <= 0)
                    return BadRequest("Campo de desconto é obrigatório");

                Json(await Task.FromResult(this.IConvenioGrupo.Add(ConvenioGrupo)));

                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o grupo de convenio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaConvenioGrupoPorId/{id}")]
        public async Task<JsonResult> RetornaConvenioGrupoPorId(int id)
        {
            try
            {
                return Json(await this.IConvenioGrupo.GetEntityById(id));
            } catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o grupo de convenio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarConvenioGrupo")]
        public async Task<IActionResult> EditarConvenioGrupo([FromBody] ConvenioGrupo ConvenioGrupo)
        {
            try
            {
                if (ConvenioGrupo.GrupoId == 0)
                    return BadRequest("Campo de grupo é obrigatório");
                if (ConvenioGrupo.ConvenioId == 0)
                    return BadRequest("Campo de convenio é obrigatório");
                if (ConvenioGrupo.Desconto <= 0)
                    return BadRequest("Campo de desconto é obrigatório");

                Json(await Task.FromResult(this.IConvenioGrupo.Update(ConvenioGrupo)));
                return Json(Ok());
            } catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o grupo de convenio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirConvenioGrupo")]
        public async Task<JsonResult> ExcluirConvenioGrupo([FromBody] ConvenioGrupo ConvenioGrupo)
        {
            try
            {
                Json(await Task.FromResult(this.IConvenioGrupo.Delete(ConvenioGrupo)));
                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o grupo de convenio " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
