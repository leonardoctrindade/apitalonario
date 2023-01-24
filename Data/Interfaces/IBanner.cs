using System;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;

namespace Data.Interfaces
{
    public interface IBanner : IGeneric<Banner>
    {
        Task<List<Banner>> ListagemCustomizada(int pagina);
    }
}
