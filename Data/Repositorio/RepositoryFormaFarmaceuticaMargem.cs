using Data.Entidades;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryFormaFarmaceuticaMargem: RepositoryGenerics<FormaFarmaceuticaMargem>, IFormaFarmaceuticaMargem
    {
        public Task<List<FormaFarmaceuticaMargem>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
