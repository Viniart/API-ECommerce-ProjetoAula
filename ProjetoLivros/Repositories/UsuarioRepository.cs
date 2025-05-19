using ProjetoLivros.Context;
using ProjetoLivros.Interfaces;
using ProjetoLivros.Models;

namespace ProjetoLivros.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private LivrosContext _context;

        public UsuarioRepository(LivrosContext context)
        {
            _context = context;
        }

        public Usuario? Atualizar(int id, Usuario usuario)
        {
            var usuarioEncontrado = _context.Usuarios.FirstOrDefault(c => c.UsuarioId == id);

            if (usuarioEncontrado == null) return null;

            usuarioEncontrado.NomeCompleto = usuario.NomeCompleto;
            usuarioEncontrado.Email = usuario.Email;
            usuarioEncontrado.Senha = usuario.Senha;
            usuarioEncontrado.Telefone = usuario.Telefone;
            usuarioEncontrado.DataAtualizacao = usuario.DataAtualizacao;
            usuarioEncontrado.DataCadastro = usuario.DataCadastro;
            usuarioEncontrado.TipoUsuarioId = usuario.TipoUsuarioId;

            _context.SaveChanges();

            return usuarioEncontrado;
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);

            _context.SaveChanges();
        }

        public Usuario? Deletar(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null) return null;

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public List<Usuario> ListarTodos()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario? ListarPorId(int id)
        {
            return _context.Usuarios
                             .FirstOrDefault(c => c.UsuarioId == id);
        }
    }
}
