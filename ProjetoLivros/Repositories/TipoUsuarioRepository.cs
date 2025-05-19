using ProjetoLivros.Context;
using ProjetoLivros.Interfaces;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private LivrosContext _context;

        public TipoUsuarioRepository(LivrosContext context)
        {
            _context = context;
        }

        public TipoUsuario? Atualizar(int id, TipoUsuario tipoUsuario)
        {
            var tipoEncontrado = _context.TiposUsuarios.FirstOrDefault(c => c.TipoUsuarioId == id);

            if (tipoEncontrado == null) return null;

            tipoEncontrado.DescricaoTipo = tipoUsuario.DescricaoTipo;

            _context.SaveChanges();

            return tipoEncontrado;
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            _context.TiposUsuarios.Add(tipoUsuario);

            _context.SaveChanges();
        }

        public TipoUsuario? Deletar(int id)
        {
            var tipoUsuario = _context.TiposUsuarios.Find(id);

            if (tipoUsuario == null) return null;

            _context.TiposUsuarios.Remove(tipoUsuario);
            _context.SaveChanges();

            return tipoUsuario;
        }

        public List<TipoUsuario> ListarTodos()
        {
            return _context.TiposUsuarios.ToList();
        }

        public TipoUsuario? ListarPorId(int id)
        {
            return _context.TiposUsuarios
                             .FirstOrDefault(c => c.TipoUsuarioId == id);
        }
    }
}
