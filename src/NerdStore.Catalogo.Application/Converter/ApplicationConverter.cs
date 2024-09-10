using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.Converter
{
    public static class ApplicationConverter
    {
        public static ProdutoViewModel ToProdutoViewModel(this Produto produto)
        {
            if (ReferenceEquals(produto, null)) return null!;
            return new ProdutoViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Ativo = produto.Ativo,
                CategoriaId = produto.CategoriaId,
                DataCadastro = produto.DataCadastro,
                Descricao = produto.Descricao,
                Imagem = produto.Imagem,
                QuantidadeEstoque = produto.QuantidadeEstoque,
                Valor = produto.Valor,
                Altura = (int)produto.Dimensoes.Altura,
                Largura = (int)produto.Dimensoes.Largura,
                Profundidade = (int)produto.Dimensoes.Profundidade,
                Categorias = [ToCategoriaViewModel(produto.Categoria)],
            };
        }
        public static IEnumerable<ProdutoViewModel> ToProdutoViewModel(this IEnumerable<Produto> produtos)
        {
            var produtosViewModel = new List<ProdutoViewModel>();
            foreach (var produto in produtos)
            {
                produtosViewModel.Add(ToProdutoViewModel(produto));
            }

            return produtosViewModel;
        }
        public static CategoriaViewModel ToCategoriaViewModel(this Categoria categoria)
        {
            if (ReferenceEquals(categoria, null)) return null!;
            else
                return new CategoriaViewModel
                {
                    Id = categoria.Id,
                    Codigo = categoria.Codigo,
                    Nome = categoria.Nome,
                };
        }
        public static IEnumerable<CategoriaViewModel> ToCategoriaViewModel(this IEnumerable<Categoria> categorias)
        {
            var categoriasViewModel = new List<CategoriaViewModel>();
            foreach (var categoria in categorias)
            {
                categoriasViewModel.Add(ToCategoriaViewModel(categoria));
            }

            return categoriasViewModel;
        }
        public static Produto ToProduto(ProdutoViewModel model)
        {
            return new Produto(model.Nome, model.Descricao, model.Ativo, model.Valor, model.CategoriaId, model.DataCadastro, model.Imagem, new Dimensoes(model.Altura, model.Largura, model.Profundidade));
        }
    }
}
