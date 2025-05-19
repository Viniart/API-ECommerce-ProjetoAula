using Microsoft.EntityFrameworkCore;
using ProjetoLivros.Context;
using ProjetoLivros.Interfaces;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repositories
{
    // 1 - Herdar e Implementar
    // 2 - Injetar o Contexto
    public class CategoriaRepository : ICategoriaRepository
    {
        private LivrosContext _context;

        public CategoriaRepository(LivrosContext context)
        {
            _context = context;
        }

        public Categoria? Atualizar(int id, Categoria categoria)
        {
            // 1 - Procuro quem atualizar
            var categoriaEncontrada = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            // 2 - Se nao acho, retorno nulo
            if (categoriaEncontrada == null) return null;

            // 3 - Se acho eu atualizo as informacoes
            categoriaEncontrada.NomeCategoria = categoria.NomeCategoria;
            _context.SaveChanges();

            return categoriaEncontrada;
        }

        public void Cadastrar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);

            _context.SaveChanges();
        }

        public Categoria? Deletar(int id)
        {
            // 1 - Procuro que quero apagar
            var categoria = _context.Categorias.Find(id);

            // 2 - Se nao achei, retorno nulo
            if (categoria == null) return null;

            // 3 - Se achei apago
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return categoria;
        }

        public List<Categoria> ListarTodos()
        {
            return _context.Categorias.ToList();
        }

        public Categoria? ListarPorId(int id)
        {
            return _context.Categorias
                             .FirstOrDefault(c => c.CategoriaId == id);
        }
    }
}
