using AutoMapper;
using DelivExpress.Application.DTOs;
using DelivExpress.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelivExpress.Application.Mappings
{
    public class DomainToDToMappingProfile : Profile
    {
        // Mapea a entidades categoria para entidades CategoriaDto
        // Mapea a entidades Produto para entidades ProdutoDto
        public DomainToDToMappingProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
