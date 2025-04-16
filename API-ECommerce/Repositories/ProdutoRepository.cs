using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        // Métodos que acessam o Banco de Dados

        // Injetar o Context
        // Injeção de Dependência
        private readonly EcommerceContext _context;

        // Metodo Construtor
        // Quando criar um objeto o que eu preciso ter?
        public ProdutoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Produto produto)
        {
            // Encontro o produto que desejo
            Produto produtoEncontrado = _context.Produtos.Find(id);

            // Caso nao encontre o produto, lanco um erro
            if (produtoEncontrado == null)
            {
                throw new Exception();
            }

            produtoEncontrado.Nome = produto.Nome;
            produtoEncontrado.Descricao = produto.Descricao;
            produtoEncontrado.Preco = produto.Preco;
            produtoEncontrado.Categoria = produto.Categoria;
            produtoEncontrado.Imagem = produto.Imagem;
            produtoEncontrado.EstoqueDisponivel = produto.EstoqueDisponivel;

            _context.SaveChanges();
        }

        public Produto BuscarPorId(int id)
        {
            // ToList() - Pegar Varios
            // FirstorDefault - Traz o Primeiro que Encontrar, ou null

            // Expressao Lambda
            // _context.Produtos - Acesse a tabela Produtos do Contexto
            // FirstOrDefault - Pegue o primeiro que encontrar
            // p => p.IdProduto == id
            // Para cada produto P, me retorne aquele que tem o IdProduto igual ao id
            return _context.Produtos.FirstOrDefault(produto => produto.IdProduto == id);
        }

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // 1 - Encontrar o que eu quero Excluir
            // Find - Procura pela chave primaria
            Produto produtoEncontrado = _context.Produtos.Find(id);

            // Caso nao encontre o produto, lanco um erro
            if(produtoEncontrado == null)
            {
                throw new Exception();
            }

            // Caso eu encontre o produto, removo ele
            _context.Produtos.Remove(produtoEncontrado);

            // Salvo as alteracoes
            _context.SaveChanges();
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}
