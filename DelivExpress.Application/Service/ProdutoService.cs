using AutoMapper;
using DelivExpress.Application.DTOs;
using DelivExpress.Application.Interfaces;
using DelivExpress.Domain.Entites;
using DelivExpress.Domain.Interfaces;


namespace DelivExpress.Application.Service
{
    public class ProdutoService : IProdutoService
    {
       
        private IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }


        #region Implementação de metados de busca, atualização e deleção de dados.
        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
           var productEntity = await _produtoRepository.GetProdutosAsync();
           return _mapper.Map<IEnumerable<ProdutoDTO>>(productEntity);
        }

        public async Task<ProdutoDTO> GetById(int? id)
        {
            var productEntity = await _produtoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutoDTO>(productEntity);
        }

        public async Task Add(ProdutoDTO produtoDto)
        {
            var productEntity = _mapper.Map<Produto>(produtoDto);
            await _produtoRepository.CreateAsync(productEntity);
        }

        public async Task Update(ProdutoDTO produtoDto)
        {
            var productEntity = _mapper.Map<Produto>(produtoDto);
            await _produtoRepository.UpdateAsync(productEntity);
        }
        public async Task Remove(int? id)
        {
            var productEntity = _produtoRepository.GetByIdAsync(id).Result;
            await _produtoRepository.DeleteAsync(productEntity);
        }

        #endregion
    }


}
