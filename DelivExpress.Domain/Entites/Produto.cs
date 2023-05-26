using DelivExpress.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelivExpress.Domain.Entites
{
    public sealed class Produto : EntityBase
    {

        // Modelos de entitide
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public string ImageUrl { get; private set; }
        public DateTime DataCadastro { get; private set; }

        
        public int? CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }


        // Construtor
        public Produto(string nome, string descricao, decimal preco, string imageUrl, DateTime dataCadastro)
        {
            ValidationDomain(nome, descricao, preco, imageUrl, dataCadastro);

        }

        // Sobrecarga de Construtor
        public Produto(int id, string nome, string descricao, decimal preco, string imageUrl, DateTime dataCadastro)
        {
            DomainExceptionValdation.When(id < 0,
                "Valor de Id Inválido.");
            Id = id;
            ValidationDomain(nome, descricao, preco, imageUrl, dataCadastro);
        }

        // Metado atuliza o Produto
        public void Update(string nome, string descricao, decimal preco, string imageUrl, DateTime dataCadastro, int categoriaId)
        {
            ValidationDomain(nome, descricao, preco, imageUrl, dataCadastro);
            CategoriaId = categoriaId;

        }

        // Implementação do mentado de Validação de erros
        public void ValidationDomain(string nome, string descricao, decimal preco, string imagem, DateTime dataCadastro)
        {
            
            DomainExceptionValdation.When(string.IsNullOrEmpty(nome),
                "Nome Inválido. O preenchimento campo é obrigatório");
            DomainExceptionValdation.When(nome.Length < 3,
                "O nome do produto deve ter no mínimo 3 caracteres");
            DomainExceptionValdation.When(string.IsNullOrEmpty(descricao),
                "Descrição Inválido. O preenchimento do campo é obrigatório");
            DomainExceptionValdation.When(preco < 0,
                "O Valor do produto deve ser maior ou igual 0");
            DomainExceptionValdation.When(string.IsNullOrEmpty(preco.ToString()),
                "Preço Inválido. O preenchimento campo é obrigatório");
            DomainExceptionValdation.When(string.IsNullOrEmpty(preco.ToString()),
                "Preço Inválido. O Campo preço é obrigatório");
            DomainExceptionValdation.When(imagem?.Length < 5,
               "O nome da categoria deve ter no mínimo 5 caracteres");
           
            Nome= nome;
            Descricao= descricao;
            Preco= preco;
            ImageUrl= imagem;
            DataCadastro= dataCadastro;

        }

    }

}
