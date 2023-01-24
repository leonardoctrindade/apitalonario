using System;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace WebAPI.Controllers
{
    public class EcfApiController: Controller
    {
        private readonly IEcf IEcf;

        public EcfApiController(IEcf IEcf)
        {
            this.IEcf = IEcf;
        }

        [HttpGet("/api/ListaPaginacaoEcf/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var ecfs = await this.IEcf.List();

                var total = Convert.ToDouble(ecfs.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IEcf.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : ecfs);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os ecfs " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaEcf")]
        public async Task<JsonResult> ListaEcf()
        {
            try
            {
                return Json(await this.IEcf.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os ecfs " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarEcf")]
        public async Task<IActionResult> AdicionarEcf([FromBody] Ecf Ecf)
        {
            try
            {
                if (String.IsNullOrEmpty(Ecf.NumeroSerie.Trim()))
                    return BadRequest("Campo de número de série é obrigatório");
                if (Ecf.NumeroEquipamento < 0)
                    return BadRequest("Campo de número do equipamento é obrigatório");

                Json(await Task.FromResult(this.IEcf.Add(Ecf)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o Ecf " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaEcfPorId/{id}")]
        public async Task<JsonResult> RetornaEcfPorId(int id)
        {
            try
            {
                return Json(await this.IEcf.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o Ecf " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarEcf")]
        public async Task<IActionResult> EditarEcf([FromBody] Ecf Ecf)
        {
            try
            {
                if (String.IsNullOrEmpty(Ecf.NumeroSerie.Trim()))
                    return BadRequest("Campo de número de série é obrigatório");
                if (Ecf.NumeroEquipamento < 0)
                    return BadRequest("Campo de número do equipamento é obrigatório");

                Json(await Task.FromResult(this.IEcf.Update(Ecf)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o Ecf " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirEcf")]
        public async Task<JsonResult> ExcluirEcf([FromBody] Ecf Ecf)
        {
            try
            {
                Json(await Task.FromResult(this.IEcf.Delete(Ecf)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o Ecf " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
