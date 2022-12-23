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
        public async Task<JsonResult> AdicionarConvenioGrupo([FromBody] ConvenioGrupo ConvenioGrupo)
        {
            try
            {
                if (ConvenioGrupo.IdGrupo == 0 || ConvenioGrupo.IdConvenio == 0 || ConvenioGrupo.Desconto <= 0)
                    return Json(BadRequest(ModelState));

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
        public async Task<JsonResult> EditarConvenioGrupo([FromBody] ConvenioGrupo ConvenioGrupo)
        {
            try
            {
                if (ConvenioGrupo.IdGrupo == 0 || ConvenioGrupo.IdConvenio == 0 || ConvenioGrupo.Desconto <= 0)
                    return Json(BadRequest(ModelState));

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
                return Json(await Task.FromResult(this.IConvenioGrupo.Delete(ConvenioGrupo)));
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o grupo de convenio " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
