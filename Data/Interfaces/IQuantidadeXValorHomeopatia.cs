using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IQuantidadeXValorHomeopatia : IGeneric<QuantidadeXValorHomeopatia>
    {
        Task<List<QuantidadeXValorHomeopatia>> ListagemCustomizada(int pagina);
    }
}
