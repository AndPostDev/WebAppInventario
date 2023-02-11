using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lourtec.WebAppInventario.Models;
using Lourtec.WebAppInventario.DAL.Contracts;
using Lourtec.WebAppInventario.DAL.DataContext;

namespace Lourtec.WebAppInventario.DAL.Repositories
{
    public class ProductoRepository : IGenericRepositoryCRUD<Producto>
    {
        private readonly DbwebInventarioContext _dbContext;

        public ProductoRepository(DbwebInventarioContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(Producto entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            Producto producto = _dbContext.Productos.Where(p => p.ProductoId == id).FirstOrDefault();
            _dbContext.Productos.Remove(producto);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Producto>> GetAll()
        {
            IQueryable<Producto> queryProductoSQL = _dbContext.Productos;
            return queryProductoSQL;
        }

        public async Task<Producto> GetById(int id)
        {
            return await _dbContext.Productos.FindAsync(id);
        }

        public async Task<bool> Update(Producto entity)
        {
            _dbContext.Productos.Update(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
