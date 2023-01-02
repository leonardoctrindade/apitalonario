using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data.Config;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repositorio
{
    public class RepositoryNcmEstado: RepositoryGenerics<NcmEstado>, INcmEstado
    {
        public Task<List<NcmEstado>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
