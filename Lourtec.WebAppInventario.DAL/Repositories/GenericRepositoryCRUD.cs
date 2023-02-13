using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lourtec.WebAppInventario.DAL.Contracts;
using Lourtec.WebAppInventario.DAL.DataContext;
using Lourtec.WebAppInventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Lourtec.WebAppInventario.DAL.Repositories
{
    public class GenericRepositoryCRUD<T> : IGenericRepositoryCRUD<T> where T : class
    {
        private readonly DbInventarioContext _dbContext;
        private DbSet<T> table;

        public GenericRepositoryCRUD()
        {
            _dbContext= new DbInventarioContext();
            table = _dbContext.Set<T>();
        }
        public GenericRepositoryCRUD(DbInventarioContext dbContext)
        {
            _dbContext = dbContext;
            table = _dbContext.Set<T>();

        }

        public async Task<bool> Create(T entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            T existe = table.Find(id);
            table.Remove(existe);
             await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await table.FindAsync(id);
        }

        //public Task<IEnumerable<T>> GetName(string name)
        //{
        //    return await table.Where;
        //}

        public async Task<bool> Update(T entity)
        {
            table.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true; // Preguntar esto a chala 
        }
 

    }
}
