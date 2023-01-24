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
    public class FormaFarmaceuticaApiController: Controller
    {
        private readonly IFormaFarmaceutica IFormaFarmaceutica;

        public FormaFarmaceuticaApiController(IFormaFarmaceutica IFormaFarmaceutica)
        {
            this.IFormaFarmaceutica = IFormaFarmaceutica;
        }

        [HttpGet("/api/ListaPaginacaoFormaFarmaceutica/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var formaFarmaceuticas = await this.IFormaFarmaceutica.List();

                var total = Convert.ToDouble(formaFarmaceuticas.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IFormaFarmaceutica.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : formaFarmaceuticas);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as formas farmaceuticas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaFormaFarmaceutica")]
        public async Task<JsonResult> ListaFormaFarmaceutica()
        {
            try
            {
                return Json(await this.IFormaFarmaceutica.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as forma farmaceuticas" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarFormaFarmaceutica")]
        public async Task<IActionResult> AdicionarFormaFarmaceutica([FromBody] FormaFarmaceutica FormaFarmaceutica)
        {
            try
            {
                if (String.IsNullOrEmpty(FormaFarmaceutica.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                if (!string.IsNullOrEmpty(FormaFarmaceutica.Imagem))
                {
                    FormaFarmaceutica.ImagemByte = Convert.FromBase64String(FormaFarmaceutica.Imagem);
                    FormaFarmaceutica.Imagem = string.Empty;
                }

                Json(await Task.FromResult(this.IFormaFarmaceutica.Add(FormaFarmaceutica)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar a forma farmaceutica " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaFormaFarmaceuticaPorId/{id}")]
        public async Task<JsonResult> RetornaFormaFarmaceuticaPorId(int id)
        {
            try
            {
                var forma = await this.IFormaFarmaceutica.GetFormaFarmaceutica(id);

                if (forma.ImagemByte != null)
                    forma.Imagem = Convert.ToBase64String(forma.ImagemByte);

                return Json(forma);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o adiministrador de cartão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarFormaFarmaceutica")]
        public async Task<IActionResult> EditarFormaFarmaceutica([FromBody] FormaFarmaceutica FormaFarmaceutica)
        {
            try
            {
                if (String.IsNullOrEmpty(FormaFarmaceutica.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                if (!string.IsNullOrEmpty(FormaFarmaceutica.Imagem))
                {
                    FormaFarmaceutica.ImagemByte = Convert.FromBase64String(FormaFarmaceutica.Imagem);
                    FormaFarmaceutica.Imagem = string.Empty;
                }

                Json(await Task.FromResult(this.IFormaFarmaceutica.Update(FormaFarmaceutica)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o adiministrador de cartão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirFormaFarmaceutica")]
        public async Task<JsonResult> ExcluirFormaFarmaceutica([FromBody] FormaFarmaceutica FormaFarmaceutica)
        {
            try
            {
                Json(await Task.FromResult(this.IFormaFarmaceutica.Delete(FormaFarmaceutica)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o adiministrador de cartão " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
