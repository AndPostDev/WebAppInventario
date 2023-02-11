using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lourtec.WebAppInventario.DAL.Contracts
{
    public interface IGenericRepositoryCRUD<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IQueryable<TEntity>> GetAll();
        Task<bool> Create(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(int id);  
    }
}
