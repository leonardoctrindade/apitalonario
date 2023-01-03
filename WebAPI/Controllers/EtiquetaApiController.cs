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
        public async Task<JsonResult> AdicionarEtiqueta([FromBody] Etiqueta Etiqueta)
        {
            try
            {
                if (
                    String.IsNullOrEmpty(Etiqueta.Descricao) ||
                    Etiqueta.Tipo < 0 ||
                    Etiqueta.MargemSuperior < 0 ||
                    Etiqueta.MargemLateral < 0 ||
                    Etiqueta.AlturaEtiqueta < 0 ||
                    Etiqueta.LarguraEtiqueta < 0 ||
                    Etiqueta.DistanciaVertical < 0 ||
                    Etiqueta.DistanciaHorizontal < 0 ||
                    Etiqueta.LinhasPorPagina < 0 ||
                    Etiqueta.ColunasPorPagina < 0 ||
                    Etiqueta.LayoutEtiquetaEntrada < 0 ||
                    Etiqueta.LinhasPorEtiqueta < 0 ||
                    Etiqueta.EspacoEntreLinhas < 0
                ){
                    return Json(BadRequest(ModelState));
                }

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
        public async Task<JsonResult> EditarEtiqueta([FromBody] Etiqueta Etiqueta)
        {
            try
            {
                if (
                    String.IsNullOrEmpty(Etiqueta.Descricao) ||
                    Etiqueta.Tipo < 0 ||
                    Etiqueta.MargemSuperior < 0 ||
                    Etiqueta.MargemLateral < 0 ||
                    Etiqueta.AlturaEtiqueta < 0 ||
                    Etiqueta.LarguraEtiqueta < 0 ||
                    Etiqueta.DistanciaVertical < 0 ||
                    Etiqueta.DistanciaHorizontal < 0 ||
                    Etiqueta.LinhasPorPagina < 0 ||
                    Etiqueta.ColunasPorPagina < 0 ||
                    Etiqueta.LayoutEtiquetaEntrada < 0 ||
                    Etiqueta.LinhasPorEtiqueta < 0 ||
                    Etiqueta.EspacoEntreLinhas < 0
                )
                {
                    return Json(BadRequest(ModelState));
                }

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
