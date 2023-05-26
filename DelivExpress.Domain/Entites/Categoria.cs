using DelivExpress.Domain.Validation;

namespace DelivExpress.Domain.Entites
{
    public sealed class Categoria : EntityBase
    {
        // Modelo de entidades
        public string Nome { get; private set; }
        public string ImageUrl { get; private set; }

        public ICollection<Produto> Produtos { get; set;}


        //Construtor

        public Categoria(string nome, string imageUrl)
        {
            ValidationDomain(nome, imageUrl);
           
        }

        public Categoria(int id, string nome, string imageUrl)
        {
            DomainExceptionValdation.When(id < 0,
                "Valor de Id Inválido.");
            Id = id;
            ValidationDomain(nome, imageUrl);
        }

        // Atualiza categoria
        public void Update(string nome, string image)
        {
            ValidationDomain(nome, image);
        }


        // Implementação do mentado de Validação de erros
        public void ValidationDomain(string nome, string image)
        {
         
            DomainExceptionValdation.When(string.IsNullOrEmpty(nome),
                "Nome Inválido. O Campo nome é obrigatório");
            DomainExceptionValdation.When(string.IsNullOrEmpty(image),
                "Nome Inválido. O Campo Imagem é obrigatório");
            DomainExceptionValdation.When(nome.Length < 3,
               "O nome da categoria deve ter no mínimo 3 caracteres");
            DomainExceptionValdation.When(image.Length < 5,
               "O Imagem deve ter no mínimo 5 caracteres");

            Nome = nome;
            ImageUrl = image;

        }
    }
}
