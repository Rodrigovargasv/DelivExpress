using AutoMapper;
using DelivExpress.Application.DTOs;
using DelivExpress.Application.Interfaces;
using DelivExpress.Domain.Entites;
using DelivExpress.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelivExpress.Application.Service
{
    public class CategoriaService : ICategoriaService
    {

        private ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;


        #region Implementação de metados de busca, atualização e deleção de dados.
        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        
        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            var categoriaEntity = await _categoriaRepository.GetCategoriaAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriaEntity);
        }
        public async Task<CategoriaDTO> GetById(int? id)
        {
            var categoriaEntity = await _categoriaRepository.GetByIdAsync(id);
            return _mapper.Map<CategoriaDTO>(categoriaEntity);
        }

        public async Task Add(CategoriaDTO categoriaDto)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaRepository.CreateAsync(categoriaEntity);
        }

        public async Task Update(CategoriaDTO categoriaDto)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaRepository.UpdateAsync(categoriaEntity);
        }
        public async Task Remove(int? id)
        {
            var categoriaEntity = _categoriaRepository.GetByIdAsync(id).Result;
            await _categoriaRepository.DeleteAsync(categoriaEntity);
        }

        #endregion
    }
}
