using DelivExpress.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelivExpress.Domain.Interfaces
{
    public interface ICategoriaRepository
    {

        // Modelos de repository para ser implementados na camada de Infrastructe
        Task<IEnumerable<Categoria>> GetCategoriaAsync();
        Task<Categoria> GetByIdAsync(int? id);
        Task<Categoria> CreateAsync(Categoria categoria);
        Task<Categoria> UpdateAsync(Categoria categoria);
        Task<Categoria> DeleteAsync(Categoria categoria);

    }
}
