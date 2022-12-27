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
            return new Categoria { Id = 1, Nome = "Teste Mock 1", CategoriaPaiId = 1, CategoriaAtivo = true, CategoriaMagentoId = 1, AlteradoPais = false, Excluidos = false, Integrados = false };
        }

        public static Categoria MontaObjetoNomeVazio()
        {
            return new Categoria { Id = 1, Nome = null, CategoriaPaiId = 1, CategoriaAtivo = true };
        }

        public static List<Categoria> MontaListaItems()
        {
            return new List<Categoria>()
            {
                new Categoria() {Id = 1, Nome = "Teste Mock 1", CategoriaPaiId = 1, CategoriaAtivo = true },
                new Categoria() {Id = 2, Nome = "Teste Mock 2", CategoriaPaiId = 2, CategoriaAtivo = false },
                new Categoria() {Id = 3, Nome = "Teste Mock 3", CategoriaPaiId = 3, CategoriaAtivo = true }
            };
        }
    }
}
