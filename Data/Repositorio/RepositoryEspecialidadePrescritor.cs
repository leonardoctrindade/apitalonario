using Data.Config;
using Data.Entidades;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class RepositoryEspecialidadePrescritor : RepositoryGenerics<EspecialidadePrescritor>, IEspecialidadePrescritor
    {
        public Task<List<EspecialidadePrescritor>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
