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
    public class EtiquetaApiController : Controller
    {
        private readonly IEtiqueta IEtiqueta;

        public EtiquetaApiController(IEtiqueta IEtiqueta)
        {
            this.IEtiqueta = IEtiqueta;
        }

        [HttpGet("/api/ListaPaginacaoEtiqueta/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var etiquetas = await this.IEtiqueta.List();

                var total = Convert.ToDouble(etiquetas.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IEtiqueta.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : etiquetas);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as etiquetas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaEtiqueta")]
        public async Task<JsonResult> ListaEtiqueta()
        {
            try
            {
                return Json(await this.IEtiqueta.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as etiquetas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarEtiqueta")]
        public async Task<IActionResult> AdicionarEtiqueta([FromBody] Etiqueta Etiqueta)
        {
            try
            {
                if (String.IsNullOrEmpty(Etiqueta.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (Etiqueta.Tipo < 0)
                    return BadRequest("Campo de tipo é obrigatório");
                if (Etiqueta.MargemSuperior < 0)
                    return BadRequest("Campo de maergem superior é obrigatório");
                if (Etiqueta.MargemLateral < 0)
                    return BadRequest("Campo de margem lateral é obrigatório");
                if (Etiqueta.AlturaEtiqueta < 0)
                    return BadRequest("Campo de altura da etiqueta é obrigatório");
                if (Etiqueta.LarguraEtiqueta < 0)
                    return BadRequest("Campo de largura da etiqueta é obrigatório");
                if (Etiqueta.DistanciaVertical < 0)
                    return BadRequest("Campo de distância vertical é obrigatório");
                if (Etiqueta.DistanciaHorizontal < 0)
                    return BadRequest("Campo de Distancia horizontal é obrigatório");
                if (Etiqueta.LinhasPorPagina < 0)
                    return BadRequest("Campo de linhas por página é obrigatório");
                if (Etiqueta.ColunasPorPagina < 0)
                    return BadRequest("Campo de colunas por página é obrigatório");
                if (Etiqueta.LayoutEtiquetaEntrada < 0)
                    return BadRequest("Campo de layout da etiqueta de entrada é obrigatório");
                if (Etiqueta.LinhasPorEtiqueta < 0)
                    return BadRequest("Campo de linhas por etiqueta é obrigatório");
                if (Etiqueta.EspacoEntreLinhas < 0)
                    return BadRequest("Campo de espaço entre linhas é obrigatório");


                Json(await Task.FromResult(this.IEtiqueta.Add(Etiqueta)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar a etiqueta " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaEtiquetaPorId/{id}")]
        public async Task<JsonResult> RetornaEtiquetaPorId(int id)
        {
            try
            {
                return Json(await this.IEtiqueta.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a etiqueta " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarEtiqueta")]
        public async Task<IActionResult> EditarEtiqueta([FromBody] Etiqueta Etiqueta)
        {
            try
            {
                if (String.IsNullOrEmpty(Etiqueta.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (Etiqueta.Tipo < 0)
                    return BadRequest("Campo de tipo é obrigatório");
                if (Etiqueta.MargemSuperior < 0)
                    return BadRequest("Campo de maergem superior é obrigatório");
                if (Etiqueta.MargemLateral < 0)
                    return BadRequest("Campo de margem lateral é obrigatório");
                if (Etiqueta.AlturaEtiqueta < 0)
                    return BadRequest("Campo de altura da etiqueta é obrigatório");
                if (Etiqueta.LarguraEtiqueta < 0)
                    return BadRequest("Campo de largura da etiqueta é obrigatório");
                if (Etiqueta.DistanciaVertical < 0)
                    return BadRequest("Campo de distância vertical é obrigatório");
                if (Etiqueta.DistanciaHorizontal < 0)
                    return BadRequest("Campo de Distancia horizontal é obrigatório");
                if (Etiqueta.LinhasPorPagina < 0)
                    return BadRequest("Campo de linhas por página é obrigatório");
                if (Etiqueta.ColunasPorPagina < 0)
                    return BadRequest("Campo de colunas por página é obrigatório");
                if (Etiqueta.LayoutEtiquetaEntrada < 0)
                    return BadRequest("Campo de layout da etiqueta de entrada é obrigatório");
                if (Etiqueta.LinhasPorEtiqueta < 0)
                    return BadRequest("Campo de linhas por etiqueta é obrigatório");
                if (Etiqueta.EspacoEntreLinhas < 0)
                    return BadRequest("Campo de espaço entre linhas é obrigatório");

                Json(await Task.FromResult(this.IEtiqueta.Update(Etiqueta)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a etiqueta " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirEtiqueta")]
        public async Task<JsonResult> ExcluirEtiqueta([FromBody] Etiqueta Etiqueta)
        {
            try
            {
                Json(await Task.FromResult(this.IEtiqueta.Delete(Etiqueta)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a etiqueta " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
