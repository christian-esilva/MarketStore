using NerdStore.Catalogo.Application.Converter;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEstoqueService _estoqueService;

        public ProdutoAppService(IProdutoRepository produtoRepository, IEstoqueService estoqueService)
        {
            _produtoRepository = produtoRepository;
            _estoqueService = estoqueService;
        }

        public async Task AdicionarProduto(ProdutoViewModel produtoViewModel)
        {
            var produto = ApplicationConverter.ToProduto(produtoViewModel);
            _produtoRepository.Adicionar(produto);
            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarProduto(ProdutoViewModel produtoViewModel)
        {
            var produto = ApplicationConverter.ToProduto(produtoViewModel);
            _produtoRepository.Atualizar(produto);
            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<IEnumerable<CategoriaViewModel>> ObterCategorias()
        {
            return ApplicationConverter.ToCategoriaViewModel(await _produtoRepository.ObterCategorias());
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo)
        {
            return ApplicationConverter.ToProdutoViewModel(await _produtoRepository.ObterPorCategoria(codigo));
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            return ApplicationConverter.ToProdutoViewModel(await _produtoRepository.ObterPorId(id));
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return ApplicationConverter.ToProdutoViewModel(await _produtoRepository.ObterTodos());
        }

        public async Task<ProdutoViewModel> DebitarEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.DebitarEstoque(id, quantidade).Result)
            {
                throw new Exception("Falha ao debitar estoque");
            }

            return ApplicationConverter.ToProdutoViewModel(await _produtoRepository.ObterPorId(id));
        }

        public async Task<ProdutoViewModel> ReporEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.ReporEstoque(id, quantidade).Result)
            {
                throw new Exception("Falha ao debitar estoque");
            }

            return ApplicationConverter.ToProdutoViewModel(await _produtoRepository.ObterPorId(id));
        }
        public void Dispose()
        {
            _produtoRepository.Dispose();
            _estoqueService.Dispose();
        }
    }
}
