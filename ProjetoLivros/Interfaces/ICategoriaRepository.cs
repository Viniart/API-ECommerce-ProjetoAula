using ProjetoLivros.Models;

namespace ProjetoLivros.Interfaces
{
    // Todos os métodos são síncronos
    // Versão funciona perfeitamente, ideal para projetos menores
    // Para grandes projetos com performance em mente, considerar a versão assincrona
    public interface ICategoriaRepository
    {
        List<Categoria> ListarTodos();
        Categoria? ListarPorId(int id);
        void Cadastrar(Categoria categoria);
        Categoria? Atualizar(int id, Categoria categoria);
        Categoria? Deletar (int id);    
    }
}
