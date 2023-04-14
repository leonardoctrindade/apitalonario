using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Data.Entidades.ConsultaChassi;

namespace Data.Interfaces
{
    public interface IMultas : IGeneric<Multas>
    {
        Task<List<Multas>> ListagemCustomizada(int pagina);
        Task<Multas> BuscarMulta(int matricula, string placa, string data, string hora, string infracao);
        Task<ConsultaResponse> BuscaPlaca(string placa);
        Task<InformacaoChassi> BuscaChassi(string chassi);
        Task<List<Multas>> BuscaMultaAgente(int idMatricula);
        Task<Multas> BuscaMultaTalao(int numeroTalao);
        Task<List<Multas>> BuscarMultasData(int matricula, DateTime dataInicial, DateTime dataFinal);
        Task<List<TotalMultas>> BuscarMultasTotal(int matricula, DateTime dataInicial, DateTime dataFinal);
        Task<List<ValoresMultas>> ArrecadacaoPorData(DateTime dataInicial, DateTime dataFinal);

    }
}
