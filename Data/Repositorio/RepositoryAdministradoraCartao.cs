using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryAdministradoraCartao: RepositoryGenerics<AdministradoraCartao>, IAdministradoraCartao
    {
        public Task<List<AdministradoraCartao>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
