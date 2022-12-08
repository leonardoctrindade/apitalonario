using System;
using System.Text;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Data.Repositorio
{
    public class RepositoryMensagensPadrao: RepositoryGenerics<MensagensPadrao>, IMensagensPadrao
    {
        public Task<List<MensagensPadrao>> ListagemCustomizada()
        {
            throw new NotImplementedException();
        }
    }
}
