using System;
using System.Linq;
using System.Text;
using Data.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace APITest.Mocks
{
    public static class MockCategoria
    {
        public static Categoria MontaObjetoUnico()
        {
            return new Categoria { Id = 1, Nome = "Teste Mock 1", IdCategoriaPai = 1, CategoriaAtivo = true, IdCategoriaMagento = 1, AlteradoPais = false, Excluidos = false, Integrados = false };
        }

        public static Categoria MontaObjetoNomeVazio()
        {
            return new Categoria { Id = 1, Nome = null, IdCategoriaPai = 1, CategoriaAtivo = true };
        }

        public static List<Categoria> MontaListaItems()
        {
            return new List<Categoria>()
            {
                new Categoria() {Id = 1, Nome = "Teste Mock 1", IdCategoriaPai = 1, CategoriaAtivo = true },
                new Categoria() {Id = 2, Nome = "Teste Mock 2", IdCategoriaPai = 2, CategoriaAtivo = false },
                new Categoria() {Id = 3, Nome = "Teste Mock 3", IdCategoriaPai = 3, CategoriaAtivo = true }
            };
        }
    }
}
