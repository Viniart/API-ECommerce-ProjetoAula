using ProjetoLivros.Models;

namespace ProjetoLivros.Interfaces
{
    public interface ILivroRepository
    {
        List<Livro> ListarTodos();
        Livro? ListarPorId(int id);
        void Cadastrar(Livro livro);
        Livro? Atualizar(int id, Livro livro);
        Livro? Deletar(int id);
    }
}
