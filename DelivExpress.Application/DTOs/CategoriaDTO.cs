using DelivExpress.Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DelivExpress.Application.DTOs
{
    public class CategoriaDTO
    {
        // Modelo de Mapemento da entidade de produto para ProdutosDTO
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o nome da imagem")]
        [MinLength(5)]
        [MaxLength(250)]
        public string ImageUrl { get; set; }

        [JsonIgnore]
        public ICollection<Produto>? Produtos { get; set; }
    }
}

