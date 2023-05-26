using DelivExpress.Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DelivExpress.Application.DTOs
{
    public class ProdutoDTO
    {

        // Modelo de Mapemento da entidade Categoria para CategoriasDTO
        public int Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo nome é obrigatório.")]
        [MaxLength(100)]
        [MinLength(3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo descrição é obrigatório.")]
        [MaxLength(200)]
        [MinLength(5)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o preço")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo estoque é obrigatório.")]
        public int Estoque { get; set; }
        
        [MaxLength(200)]
        public string ImageUrl { get; set; }

        [JsonIgnore]
        public DateTime DataCadastro { get; set; } = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));

        public int? CategoriaId { get; set; }
       

    }
}
