using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data.Config;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Data.Helper;
using System.Net.Http;
using Newtonsoft.Json;
using System.Numerics;
using static Data.Entidades.ConsultaChassi;

namespace Data.Repositorio
{
    public class RepositoryMultas : RepositoryGenerics<Multas>, IMultas
    {
        public async Task<List<Multas>> ListagemCustomizada(int pagina)
        {
            using (var context = new ContextBase(this._OptionsBuilder))
            {
                var result = new List<Multas>();

                try
                {
                    result = await context.Multas
                   .OrderBy(x => x.NumeroTalao)
                   .Skip((pagina - 1) * 10)
                   .Take(10)
                   .ToListAsync();
                }
                catch (Exception)
                {

                    throw;
                }


                return result;
            }
        }


        public async Task<Multas> BuscaMultaTalao(int numeroTalao)
        {
            try
            {
                using (var context = new ContextBase(_OptionsBuilder))
                {
                    return await context.Multas.Where(x => x.NumeroTalao == numeroTalao).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<Multas>> BuscaMultaAgente(int idMatricula)
        {
            try
            {
                using (var context = new ContextBase(_OptionsBuilder))
                {
                    return await context.Multas.Where(x => x.idMatricula == idMatricula && x.DataInclusao.AddDays(-7) <= DateTime.Now).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Multas> BuscarMulta(int matricula, string placa, string data, string hora, string infracao)
        {
            try
            {
                using (var context = new ContextBase(_OptionsBuilder))
                {
                    var m = matricula;
                    var p = placa;
                    var d = data;
                    var h = hora.ToString();
                    var i = infracao.ToString();

                    return await context.Multas.Where(x => x.idMatricula == m && x.Placa == p && x.DataString == d && x.Hora == h && x.Infracao == i).OrderByDescending(z=>z.NumeroTalao).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public async Task<ConsultaResponse> BuscaPlaca(string placa)
        {


            var apiToken = "Lzwba4twyvfhG5B6N4b1abGiRS3I4I";
            var userIdEncripted = "7648C11ED3B911EDB51DF23C93327545";
            var tipoParametro = "Placa";
            var parametro = placa;

            var requestUri = $"https://sis.mtix.com.br/consultaveicular/api/Request/GetBinNacionalAsync?tipoParametro={tipoParametro}&parametro={parametro}";

            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.Headers.Add("accept", "*/*");
            request.Content = new StringContent(JsonConvert.SerializeObject(new { apiToken, userIdEncripted }), System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ConsultaResponse>(responseContent);

            result.data.dataEmissaoCrv = DateTime.Parse(result.data.dataEmissaoCrv).ToString("dd/MM/yyyy");

            return result;


        }

        public async Task<InformacaoChassi> BuscaChassi(string chassi)
        {
            var apiToken = "Lzwba4twyvfhG5B6N4b1abGiRS3I4I";
            var userIdEncripted = "7648C11ED3B911EDB51DF23C93327545";
            var tipoParametro = "Chassi";
            var parametro = chassi;

            var requestUri = $"https://sis.mtix.com.br/consultaveicular/api/Request/GetBinNacionalListAsync?tipoParametro={tipoParametro}&parametro={parametro}";

            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            request.Headers.Add("accept", "*/*");
            request.Content = new StringContent(JsonConvert.SerializeObject(new { apiToken, userIdEncripted }), System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<InformacaoChassi>(responseContent);

            return result;

        }


    }
}
