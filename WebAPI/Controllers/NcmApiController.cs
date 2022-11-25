using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class NcmApiController : Controller
    {
        private readonly INcm INcm;

        public NcmApiController(INcm INcm)
        {
            this.INcm = INcm;
        }

        [HttpGet("/api/ListaNcm")]
        public async Task<JsonResult> ListaNcm()
        {
            //return Json(await this.INcm.List());
            return Json(new List<Ncm>()
            {
                new Ncm() { Id = 1, Descricao = "Teste 1", CodigoNcm = "123Abc", CodigoNcmEx = 123, AliquotaCofins = 1, AliquotaIcmsProduto = 1, AliquotaImportacao = 1, AliquotaNacional =1, AliquotaPis = 1, IdTributoCstCofinsEntrada = 1, IdTributoCstCofinsSaida = 1, IdTributoCstPisEntrada = 1, IdTributoCstPisSaida = 1, PercentualMva = 1, ProdutoServico = true },
                new Ncm() { Id = 2, Descricao = "Teste 2", CodigoNcm = "123Abc", CodigoNcmEx = 123, AliquotaCofins = 1, AliquotaIcmsProduto = 1, AliquotaImportacao = 1, AliquotaNacional =1, AliquotaPis = 1, IdTributoCstCofinsEntrada = 1, IdTributoCstCofinsSaida = 1, IdTributoCstPisEntrada = 1, IdTributoCstPisSaida = 1, PercentualMva = 1, ProdutoServico = false },
                new Ncm() { Id = 3, Descricao = "Teste 3", CodigoNcm = "123Abc", CodigoNcmEx = 123, AliquotaCofins = 1, AliquotaIcmsProduto = 1, AliquotaImportacao = 1, AliquotaNacional =1, AliquotaPis = 1, IdTributoCstCofinsEntrada = 1, IdTributoCstCofinsSaida = 1, IdTributoCstPisEntrada = 1, IdTributoCstPisSaida = 1, PercentualMva = 1, ProdutoServico = false }
            });
        }

        [HttpPost("/api/AdicionarNcm")]
        public async Task<JsonResult> AdicionarNcm([FromBody] Ncm Ncm)
        {
            if (String.IsNullOrEmpty(Ncm.Descricao))
                return Json(BadRequest(ModelState));
            if (string.IsNullOrEmpty(Ncm.CodigoNcm))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.INcm.Add(Ncm)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaNcmPorId/{id}")]
        public async Task<JsonResult> RetornaNcmPorId(int id)
        {
            return Json(await this.INcm.GetEntityById(id));
        }

        [HttpPost("/api/EditarNcm")]
        public async Task<JsonResult> EditarNcm([FromBody] Ncm Ncm)
        {
            if (String.IsNullOrEmpty(Ncm.Descricao))
                return Json(BadRequest(ModelState));
            if (string.IsNullOrEmpty(Ncm.CodigoNcm))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.INcm.Update(Ncm)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirNcm")]
        public async Task ExcluirNcm([FromBody] Ncm Ncm)
        {
            await Task.FromResult(this.INcm.Delete(Ncm));
        }
    }
}
