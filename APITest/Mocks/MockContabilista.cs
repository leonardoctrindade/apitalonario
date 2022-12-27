using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace APITest.Mocks
{
    public class MockContabilista
    {
        public static Contabilista MontaObjetoUnico()
        {
            return new Contabilista { Id = 1, BairroId = 1, CidadeId = 1, EstadoId = 1, Nome = "Teste Mock 1", Cnpj = "656186168", Cpf = "4116161", Crc = "fgnagn oa", Endereco = "aofnaiogf", Numero = "127", Complemento = "nfiaponga", Cep = "fnagnaog", Email = "anognaog", Telefone = "galjanlajn", Fax = "gnaognaoun" };
        }

        public static Contabilista MontaObjetoNomeVazio()
        {
            return new Contabilista { Id = 1, BairroId = 1, CidadeId = 1, EstadoId = 1, Nome = null, Cnpj = "656186168", Cpf = "4116161", Crc = "fgnagn oa", Endereco = "aofnaiogf", Numero = "127", Complemento = "nfiaponga", Cep = "fnagnaog", Email = "anognaog", Telefone = "galjanlajn", Fax = "gnaognaoun" };
        }
        public static Contabilista MontaObjetoCnpjVazio()
        {
            return new Contabilista { Id = 1, BairroId = 1, CidadeId = 1, EstadoId = 1, Nome = "Teste Mock 1", Cnpj = null, Cpf = "4116161", Crc = "fgnagn oa", Endereco = "aofnaiogf", Numero = "127", Complemento = "nfiaponga", Cep = "fnagnaog", Email = "anognaog", Telefone = "galjanlajn", Fax = "gnaognaoun" };
        }
    
        public static Contabilista MontaObjetoCpfVazio()
        {
            return new Contabilista { Id = 1, BairroId = 1, CidadeId = 1, EstadoId = 1, Nome = "Teste Mock 1", Cnpj = "656186168", Cpf = null, Crc = "fgnagn oa", Endereco = "aofnaiogf", Numero = "127", Complemento = "nfiaponga", Cep = "fnagnaog", Email = "anognaog", Telefone = "galjanlajn", Fax = "gnaognaoun" };
        }

        public static Contabilista MontaObjetoCrcVazio()
        {
            return new Contabilista { Id = 1, BairroId = 1, CidadeId = 1, EstadoId = 1, Nome = "Teste Mock 1", Cnpj = "656186168", Cpf = "4116161", Crc = "fgnagn oa", Endereco = "aofnaiogf", Numero = "127", Complemento = "nfiaponga", Cep = "fnagnaog", Email = "anognaog", Telefone = "galjanlajn", Fax = "gnaognaoun" };
        }

        public static List<Contabilista> MontaListaItems()
        {
            return new List<Contabilista>()
            {
                new Contabilista() { Id = 1, BairroId = 1, CidadeId = 1, EstadoId = 1, Nome = "Teste Mock 1", Cnpj = "656186168", Cpf = "4116161", Crc = "fgnagn oa", Endereco = "aofnaiogf", Numero = "127", Complemento = "nfiaponga", Cep = "fnagnaog", Email = "anognaog", Telefone = "galjanlajn", Fax = "gnaognaoun" },
                new Contabilista() { Id = 2, BairroId = 2, CidadeId = 2, EstadoId = 2, Nome = "Teste Mock 2", Cnpj = "656186168", Cpf = "4116161", Crc = "fgnagn oa", Endereco = "aofnaiogf", Numero = "127", Complemento = "nfiaponga", Cep = "fnagnaog", Email = "anognaog", Telefone = "galjanlajn", Fax = "gnaognaoun" },
                new Contabilista() { Id = 3, BairroId = 3, CidadeId = 3, EstadoId = 3, Nome = "Teste Mock 3", Cnpj = "656186168", Cpf = "4116161", Crc = "fgnagn oa", Endereco = "aofnaiogf", Numero = "127", Complemento = "nfiaponga", Cep = "fnagnaog", Email = "anognaog", Telefone = "galjanlajn", Fax = "gnaognaoun" }
            };
        }
    }
}
