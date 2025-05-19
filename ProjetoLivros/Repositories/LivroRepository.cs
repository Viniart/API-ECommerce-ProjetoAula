using ProjetoLivros.Context;
using ProjetoLivros.Interfaces;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private LivrosContext _context;

        public LivroRepository(LivrosContext context)
        {
            _context = context;
        }

        public Livro? Atualizar(int id, Livro livro)
        {
            var livroEncontrado = _context.Livros.FirstOrDefault(c => c.LivroId == id);

            if (livroEncontrado == null) return null;

            livroEncontrado.Titulo = livro.Titulo;
            livroEncontrado.Autor = livro.Autor;
            livroEncontrado.Descricao = livro.Descricao;
            livroEncontrado.DataPublicacao = livro.DataPublicacao;
            livroEncontrado.CategoriaId = livro.CategoriaId;

            _context.SaveChanges();

            return livroEncontrado;
        }

        public void Cadastrar(Livro livro)
        {
            _context.Livros.Add(livro);

            _context.SaveChanges();
        }

        public Livro? Deletar(int id)
        {
            var livro = _context.Livros.Find(id);

            if (livro == null) return null;

            _context.Livros.Remove(livro);
            _context.SaveChanges();

            return livro;
        }

        public List<Livro> ListarTodos()
        {
            return _context.Livros.ToList();
        }

        public Livro? ListarPorId(int id)
        {
            return _context.Livros
                             .FirstOrDefault(c => c.LivroId == id);
        }
    }
}
