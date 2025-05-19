using ProjetoLivros.Models;

namespace ProjetoLivros.Interfaces
{
    // Versão Assíncrona da Interface
    // Lembrando que essa versão costuma ter maior performance para projetos maiores
    public interface ICategoriaRepositoryAsync
    {
        Task<List<Categoria>> ListarTodosAsync();
        Task<Categoria?> BuscarPorIdAsync(int id);
        Task CadastrarAsync(Categoria categoria);
        Task<Categoria?> AtualizarAsync(int id, Categoria categoria);
        Task<Categoria?> DeletarAsync(int id);
    }
}
