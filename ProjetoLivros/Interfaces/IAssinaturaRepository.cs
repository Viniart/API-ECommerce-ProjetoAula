using ProjetoLivros.Models;

namespace ProjetoLivros.Interfaces
{
    public interface IAssinaturaRepository
    {
        List<Assinatura> ListarTodos();
        Assinatura? ListarPorId(int id);
        void Cadastrar(Assinatura assinatura);
        Assinatura? Atualizar(int id, Assinatura assinatura);
        Assinatura? Deletar(int id);
    }
}
