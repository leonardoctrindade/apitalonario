using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IAgente : IGeneric<Agente>
    {
        Task<List<Agente>> ListagemCustomizada(int pagina);
        Task<Agente> BuscarAgente(int matricula, string senha);
        Task<Agente> BuscarAgente(int matricula);
        Task MudarSenhaAgente(int matricula, string senha, string assinaturaDigital);
        Task MudarSenhaAgenteSemMatricula(int matricula, string senha);
    }
}
