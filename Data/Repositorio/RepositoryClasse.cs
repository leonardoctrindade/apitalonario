using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryClasse : RepositoryGenerics<Classe>,IClasse
    {
        public Task<List<Classe>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
