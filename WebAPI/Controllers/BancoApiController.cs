using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class BancoApiController : Controller
    {
        private readonly IBanco IBanco;

        public BancoApiController(IBanco IBanco)
        {
            this.IBanco = IBanco;
        }

        [HttpGet("/api/ListaBanco")]
        public async Task<JsonResult> ListaBanco()
        {
            try
            {
                return Json(await this.IBanco.List());
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os bancos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarBanco")]
        public async Task<JsonResult> AdicionarBanco([FromBody] Banco Banco)
        {
            try
            {
                if (String.IsNullOrEmpty(Banco.Nome))
                    return Json(BadRequest(ModelState));
                if (Banco.CodigoBanco.Count() == 0 || Banco.CodigoBanco.Count() > 3)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IBanco.Add(Banco)));

                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o banco " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaBancoPorId/{id}")]
        public async Task<JsonResult> RetornaBancoPorId(int id)
        {
            try
            {
                return Json(await this.IBanco.GetEntityById(id));
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o banco " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarBanco")]
        public async Task<JsonResult> EditarBanco([FromBody] Banco Banco)
        {
            try
            {
                if (String.IsNullOrEmpty(Banco.Nome))
                    return Json(BadRequest(ModelState));
                if (Banco.CodigoBanco.Count() == 0 || Banco.CodigoBanco.Count() > 3)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IBanco.Update(Banco)));
                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o banco " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirBanco")]
        public async Task<JsonResult> ExcluirBanco([FromBody] Banco Banco)
        {
            try
            {
                Json(await Task.FromResult(this.IBanco.Delete(Banco)));
                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o banco " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
