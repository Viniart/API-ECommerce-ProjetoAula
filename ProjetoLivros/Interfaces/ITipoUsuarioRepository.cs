using ProjetoLivros.Models;

namespace ProjetoLivros.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        List<TipoUsuario> ListarTodos();
        TipoUsuario? ListarPorId(int id);
        void Cadastrar(TipoUsuario tipoUsuario);
        TipoUsuario? Atualizar(int id, TipoUsuario tipoUsuario);
        TipoUsuario? Deletar(int id);
    }
}
