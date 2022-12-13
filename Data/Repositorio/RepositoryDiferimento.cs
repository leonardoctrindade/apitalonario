using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryDiferimento: RepositoryGenerics<Diferimento>, IDiferimento
    {
        public Task<List<Diferimento>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
