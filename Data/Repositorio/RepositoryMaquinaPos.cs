using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryMaquinaPos : RepositoryGenerics<MaquinaPos>, IMaquinaPos
    {
        public Task<List<MaquinaPos>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
