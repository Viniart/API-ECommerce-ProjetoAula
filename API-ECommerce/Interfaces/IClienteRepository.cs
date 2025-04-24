using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> ListarTodos();
        Cliente BuscarPorId(int id);
        Cliente? BuscarPorEmailSenha(string email, string senha);
        void Cadastrar(Cliente cliente);
        void Atualizar(int id, Cliente cliente);
        void Deletar(int id);
        List<Cliente> BuscarClientePorNome(string nome);
    }
}
