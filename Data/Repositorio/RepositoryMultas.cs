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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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


        public async Task<List<Multas>> BuscarMultasData(int matricula, DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                using (var context = new ContextBase(_OptionsBuilder))
                {
                    if (matricula != 0)
                    {
                        var m = matricula;

                        var query = (from multas in context.Multas
                                     join agente in context.Agente on multas.idMatricula equals agente.Matricula
                                     select new Multas
                                     {
                                         Nome = agente.Nome,
                                         Ano = multas.Ano,
                                         Id = multas.Id,
                                         OrgaoAutuador = multas.OrgaoAutuador,
                                         NumeroTalao = multas.NumeroTalao,
                                         Placa = multas.Placa,
                                         Marca = multas.Marca,
                                         Especie = multas.Especie,
                                         NomeCondutor = multas.NomeCondutor,
                                         CNHCondutor = multas.CNHCondutor,
                                         UFCondutor = multas.UFCondutor,
                                         CPFCondutor = multas.CPFCondutor,
                                         Logradouro = multas.Logradouro,
                                         Data = multas.Data,
                                         Hora = multas.Hora,
                                         Municipio = multas.Municipio,
                                         Infracao = multas.Infracao,
                                         idMatricula = multas.idMatricula,
                                         CpfEmbarcador = multas.CpfEmbarcador,
                                         NomeTransportador = multas.NomeTransportador,
                                         CpfTransportador = multas.CpfTransportador,
                                         FotoCNH = multas.FotoCNH,
                                         FotoVeiculo = multas.FotoVeiculo,
                                         DataInclusao = multas.DataInclusao,
                                         Situacao = multas.Situacao,
                                         Modelo = multas.Modelo,
                                         AnoModelo = multas.AnoModelo,
                                         UF = multas.UF,
                                         MunicipioPlaca = multas.MunicipioPlaca,
                                         Chassi = multas.Chassi,
                                         Guid = multas.Guid,
                                         Observacao = multas.Observacao,
                                         Transmitida = multas.Transmitida,
                                         Cancelada = multas.Cancelada,
                                         Ativa = multas.Ativa,
                                         Latitude = multas.Latitude,
                                         Longitude = multas.Longitude,
                                         NumeroTalaoDetran = multas.NumeroTalaoDetran,
                                         MedidaAdm = multas.MedidaAdm,
                                         DataString = multas.DataString

                                     }).Where(x => x.idMatricula == m && x.DataInclusao.Date >= dataInicial.Date && x.DataInclusao.Date <= dataFinal.Date).OrderBy(z => z.NumeroTalao).ToListAsync();
                        return await query;


                    }
                    else
                    {

                        var query = (from multas in context.Multas
                                     join agente in context.Agente on multas.idMatricula equals agente.Matricula
                                     select new Multas
                                     {
                                         Nome = agente.Nome,
                                         Ano = multas.Ano,
                                         Id = multas.Id,
                                         OrgaoAutuador = multas.OrgaoAutuador,
                                         NumeroTalao = multas.NumeroTalao,
                                         Placa = multas.Placa,
                                         Marca = multas.Marca,
                                         Especie = multas.Especie,
                                         NomeCondutor = multas.NomeCondutor,
                                         CNHCondutor = multas.CNHCondutor,
                                         UFCondutor = multas.UFCondutor,
                                         CPFCondutor = multas.CPFCondutor,
                                         Logradouro = multas.Logradouro,
                                         Data = multas.Data,
                                         Hora = multas.Hora,
                                         Municipio = multas.Municipio,
                                         Infracao = multas.Infracao,
                                         idMatricula = multas.idMatricula,
                                         CpfEmbarcador = multas.CpfEmbarcador,
                                         NomeTransportador = multas.NomeTransportador,
                                         CpfTransportador = multas.CpfTransportador,
                                         FotoCNH = multas.FotoCNH,
                                         FotoVeiculo = multas.FotoVeiculo,
                                         DataInclusao = multas.DataInclusao,
                                         Situacao = multas.Situacao,
                                         Modelo = multas.Modelo,
                                         AnoModelo = multas.AnoModelo,
                                         UF = multas.UF,
                                         MunicipioPlaca = multas.MunicipioPlaca,
                                         Chassi = multas.Chassi,
                                         Guid = multas.Guid,
                                         Observacao = multas.Observacao,
                                         Transmitida = multas.Transmitida,
                                         Cancelada = multas.Cancelada,
                                         Ativa = multas.Ativa,
                                         Latitude = multas.Latitude,
                                         Longitude = multas.Longitude,
                                         NumeroTalaoDetran = multas.NumeroTalaoDetran,
                                         MedidaAdm = multas.MedidaAdm,
                                         DataString = multas.DataString

                                     }).Where(x => x.DataInclusao.Date >= dataInicial.Date && x.DataInclusao.Date <= dataFinal.Date).OrderBy(z => z.NumeroTalao).ToListAsync();


                        return await query;
                    }

                }
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public async Task<List<ValoresMultas>> ArrecadacaoPorData(DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                using (var context = new ContextBase(_OptionsBuilder))
                {
                    var multas = await context.Multas.Where(x => x.DataInclusao.Date >= dataInicial.Date && x.DataInclusao.Date <= dataFinal.Date).ToListAsync();
                    var valores = await context.ValoresMultas.ToListAsync();
                    var listaMultas = new List<ValoresMultas>();

                    double x = 0;

                    foreach (var item in valores)
                    {
                        foreach (var item2 in multas)
                        {
                            if (item2.Infracao.Contains(item.Codigo))
                            {
                                ValoresMultas m = new ValoresMultas();
                                x = 0;
                                x = x + item.Valor;
                                m.Valor = x;
                                m.Infracao = item2.Infracao;
                                m.Endereco = item2.Logradouro;
                                m.Data = item2.Data;
                                listaMultas.Add(m);
                            }
                        }

                    }

                    var listaTotal = listaMultas
                                   .GroupBy(o => o.Infracao)
                                   .Select(g => new ValoresMultas
                                   {
                                       TotalMultas = g.Count(),
                                       Infracao = g.Key,
                                       Endereco = g.FirstOrDefault().Endereco,
                                       Valor = g.Sum(o => o.Valor),
                                       Data = g.FirstOrDefault().Data,
                                       Pontos = g.FirstOrDefault().Pontos
                                   })
                                   .ToList();

                    double z = 0;
                    int y = 0;

                    foreach (var item in listaTotal)
                    {
                        //y = y + item.TotalMultas;
                        z = z + item.Valor;
                    }

                    foreach (var item in listaTotal)
                    {
                        item.ValorGeral = z.ToString("C2");
                        item.ValorUnitarioString = item.Valor.ToString("C2");
                    }

                    return await Task.Run(() => listaTotal.ToList());
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<List<TotalMultas>> BuscarMultasTotal(int matricula, DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                using (var context = new ContextBase(_OptionsBuilder))
                {
                    if (matricula != 0)
                    {
                        var m = matricula;
                        var result = context.Multas
                           .Join(context.Agente, o => o.idMatricula, oi => oi.Matricula, (o, oi) => new { Multas = o, Agente = oi })
                           .GroupBy(x => x.Agente.Nome)
                           .Select(g => new TotalMultas { Nome = g.Key, Total = g.Count(), Matricula = g.FirstOrDefault().Multas.idMatricula, DataInclusao = g.FirstOrDefault().Multas.DataInclusao })
                           .Where(x => x.Matricula == m && x.DataInclusao.Date >= dataInicial.Date && x.DataInclusao.Date <= dataFinal.Date)
                           .OrderByDescending(x => x.Total)
                           .ToListAsync();

                        return await result;
                    }
                    else
                    {
                        var result = context.Multas
                          .Join(context.Agente, o => o.idMatricula, oi => oi.Matricula, (o, oi) => new { Multas = o, Agente = oi })
                          .GroupBy(x => x.Agente.Nome)
                          .Select(g => new TotalMultas { Nome = g.Key, Total = g.Count(), Matricula = g.FirstOrDefault().Multas.idMatricula, DataInclusao = g.FirstOrDefault().Multas.DataInclusao })
                          .Where(x => x.DataInclusao.Date >= dataInicial.Date && x.DataInclusao.Date <= dataFinal.Date)
                          .OrderByDescending(x => x.Total)
                          .ToListAsync();

                        return await result;
                    }

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

                    return await context.Multas.Where(x => x.idMatricula == m && x.Placa == p && x.DataString == d && x.Hora == h && x.Infracao == i).OrderBy(z => z.NumeroTalao).FirstOrDefaultAsync();
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
