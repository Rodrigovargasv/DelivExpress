using DelivExpress.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelivExpress.Application.Interfaces
{
    public interface IProdutoService
    {
        // Metados para ser implemntado na pasta serviços
        Task<IEnumerable<ProdutoDTO>> GetProdutos();
        Task<ProdutoDTO> GetById(int? id);
        Task Add(ProdutoDTO produtoDto);
        Task Update(ProdutoDTO produtoDto);
        Task Remove(int? id);
    }
}
