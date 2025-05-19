using Microsoft.EntityFrameworkCore;
using ProjetoLivros.Context;
using ProjetoLivros.Interfaces;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repositories
{
    // Versão assíncrona do Repository
    public class CategoriaRepositoryAsync : ICategoriaRepositoryAsync
    {
        private readonly LivrosContext _context;

        public CategoriaRepositoryAsync(LivrosContext context)
        {
            _context = context;
        }

        public async Task<Categoria?> AtualizarAsync(int id, Categoria categoria)
        {
            var categoriaExistente = await _context.Categorias.FindAsync(id);

            if (categoriaExistente == null) return null;

            categoriaExistente.NomeCategoria = categoria.NomeCategoria;

            _context.Categorias.Update(categoriaExistente);
            await _context.SaveChangesAsync();

            return categoriaExistente;
        }

        public async Task<Categoria?> BuscarPorIdAsync(int id)
        {
            return await _context.Categorias
                             .FirstOrDefaultAsync(c => c.CategoriaId == id);
        }

        public async Task CadastrarAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);

            await _context.SaveChangesAsync();
        }

        public async Task<Categoria?> DeletarAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null) return null;

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task<List<Categoria>> ListarTodosAsync()
        {
            return await _context.Categorias.ToListAsync();
        }
    }
}
