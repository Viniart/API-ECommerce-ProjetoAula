using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    // Fachada - Contrato
    public interface IProdutoRepository
    {
        // R - Read (Leitura)
        // Retorno
        List<Produto> ListarTodos();
        // Recebe um identificador, e retorna o produto correspondente
        Produto BuscarPorId(int id);

        // C - Create (Cadastro)
        void Cadastrar(Produto produto);

        // U - Update (Atualização)
        // Recebe um identificador para encontrar o Produto, e recebe o Produto Novo para substituir o Antigo
        void Atualizar(int id, Produto produto);

        // D - Delete (Deleção)
        // Recebo o identificador de quem quero excluir
        void Deletar(int id);
    }
}
