using ProjetoLivros.Models;

namespace ProjetoLivros.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> ListarTodos();
        Usuario? ListarPorId(int id);
        void Cadastrar(Usuario usuario);
        Usuario? Atualizar(int id, Usuario usuario);
        Usuario? Deletar(int id);
    }
}
