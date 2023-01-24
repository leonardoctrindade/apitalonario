using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Data.Config;
using System.Transactions;

namespace WebAPI.Controllers
{
    public class ParametroApiController : Controller
    {
        private readonly IParametroDto IParametro;
        private readonly IEndereco IEndereco;
        private readonly IContato IContato;

        public ParametroApiController(IParametroDto IParametro, IEndereco IEndereco, IContato IContato)
        {
            this.IParametro = IParametro;
            this.IEndereco = IEndereco;
            this.IContato = IContato;
        }
      
        [HttpPost("/api/AdicionarParametro")]
        public async Task<JsonResult> AdicionarParametro([FromBody] ParametroDto parametro)
        {
            try
            {
                Json(await Task.FromResult(this.IParametro.AdicionarParametro(parametro.Farmacia, parametro.Farmacia.Endereco, parametro.Farmacia.Contato, parametro.Farmacia.Farmaceutico, parametro.Impressao, parametro.CupomFiscal, parametro.ConvenioParametro, parametro.CartoesTEF, parametro.NfeSped, parametro.Nfe, parametro.GeralFarmacia, parametro.PrismaSync, parametro.Sipro, parametro.GestaoEntrega, parametro.GeralManipulacao, parametro.OpcoesManipulacao, parametro.ImpressaoManipulacao, parametro.DrogariaAcabado)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o Parâmetro " + ex.Message }) { StatusCode = 400 };
            }
        }


    }
}
