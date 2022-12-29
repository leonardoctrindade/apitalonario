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
    public class RepositoryAliquotaEstado: RepositoryGenerics<AliquotaEstado>, IAliquotaEstado
    {
        public Task<List<AliquotaEstado>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
