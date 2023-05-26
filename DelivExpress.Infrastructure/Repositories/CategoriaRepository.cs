using DelivExpress.Domain.Entites;
using DelivExpress.Domain.Interfaces;
using DelivExpress.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace DelivExpress.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Relizar as operações de CRUD no banco de dados
        public async Task<Categoria> CreateAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> DeleteAsync(Categoria categoria)
        {
            _context.Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> GetByIdAsync(int? id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<IEnumerable<Categoria>> GetCategoriaAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> UpdateAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }
        #endregion
    }
}
