using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class NcmApiController : Controller
    {
        private readonly INcm INcm;

        public NcmApiController(INcm INcm)
        {
            this.INcm = INcm;
        }

        [HttpGet("/api/ListaPaginacaoNcm/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var ncms = await this.INcm.List();

                var total = Convert.ToDouble(ncms.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.INcm.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : ncms);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os ncms " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaNcm")]
        public async Task<JsonResult> ListaNcm()
        {
            try
            {
                return Json(await this.INcm.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os ncms " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarNcm")]
        public async Task<IActionResult> AdicionarNcm([FromBody] Ncm Ncm)
        {
            try
            {
                if (string.IsNullOrEmpty(Ncm.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (string.IsNullOrEmpty(Ncm.CodigoNcm.Trim()))
                    return BadRequest("Campo de código ncm é obrigatório");

                Json(await Task.FromResult(this.INcm.Add(Ncm)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o ncm " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaNcmPorId/{id}")]
        public async Task<JsonResult> RetornaNcmPorId(int id)
        {
            try
            {
                return Json(await this.INcm.GetNcm(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o ncm " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarNcm")]
        public async Task<IActionResult> EditarNcm([FromBody] Ncm Ncm)
        {
            try
            {
                if (string.IsNullOrEmpty(Ncm.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (string.IsNullOrEmpty(Ncm.CodigoNcm.Trim()))
                    return BadRequest("Campo de código ncm é obrigatório");

                Json(await Task.FromResult(this.INcm.Update(Ncm)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o ncm " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirNcm")]
        public async Task<JsonResult> ExcluirNcm([FromBody] Ncm Ncm)
        {
            try
            {
                Json(await Task.FromResult(this.INcm.Delete(Ncm)));
                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o ncm " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
