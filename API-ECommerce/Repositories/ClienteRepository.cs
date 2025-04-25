
using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.ViewModels;

namespace API_ECommerce.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly EcommerceContext _context;

        public ClienteRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Cliente clienteNovo)
        {
            // Acho o cliente que desejo
            var clienteEncontrado = _context.Clientes.FirstOrDefault(c => c.IdCliente == id);

            if (clienteEncontrado == null)
            {
                throw new ArgumentNullException("Cliente não encontrado");
            }

            // Campo a Campo alterando
            clienteEncontrado.NomeCompleto = clienteNovo.NomeCompleto;
            clienteEncontrado.Email = clienteNovo.Email;
            clienteEncontrado.Telefone = clienteNovo.Telefone;
            clienteEncontrado.Endereco = clienteNovo.Endereco;
            clienteEncontrado.Senha = clienteNovo.Senha;
            clienteEncontrado.DataCadastro = clienteNovo.DataCadastro;

            _context.SaveChanges();
        }

        public List<Cliente> BuscarClientePorNome(string nome)
        {
            // Where - Traz todos que atendem uma condicao
            var listaClientes = _context.Clientes.Where(c => c.NomeCompleto == nome)
                .ToList();

            return listaClientes;
        }

        /// <summary>
        /// Acessa o Banco de Dados, e encontra o Cliente com email e senha fornecidos
        /// </summary>
        /// <returns>Um cliente ou nulo</returns>
        public Cliente? BuscarPorEmailSenha(string email, string senha)
        {
            // Encontrar o Cliente que possui o email e senha fornecidos
            var clienteEncontrado = _context.Clientes.FirstOrDefault(c => c.Email == email && c.Senha == senha);

            return clienteEncontrado;
        }

        public Cliente BuscarPorId(int id)
        {
            // Qualquer método que vai me trazer apenas 1 cliente
            // First or Default
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Encontrar quem eu quero deletar

            // FirstOrDefault - Pesquisa por qualquer campo
            var clienteEncontrado = _context.Clientes.FirstOrDefault(c => c.IdCliente == id);

            // Find - Pesquisa SOMENTE pela chave primária (ID)
            // var clienteEncontrado2 = _context.Clientes.Find(id);

            // Caso eu não encontre o cliente lanço um erro
            if(clienteEncontrado == null)
            {
                throw new ArgumentNullException("Cliente não encontrado");
            }

            // Removo o Cliente
            _context.Clientes.Remove(clienteEncontrado);

            // Salvo as alterações
            _context.SaveChanges();
        }

        public List<ListarClienteViewModel> ListarTodos()
        {
            return _context.Clientes
                // Permite que eu selecione quais campos eu quero pegar
                .Select(
                    c => new ListarClienteViewModel
                    {
                        IdCliente = c.IdCliente,
                        NomeCompleto = c.NomeCompleto,
                        Email = c.Email,
                        Telefone = c.Telefone,
                        Endereco = c.Endereco
                    })
                .ToList();
        }
    }
}
