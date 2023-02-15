using Lourtec.WebAppInventario.DAL.Contracts;
using Lourtec.WebAppInventario.DAL.DataContext;
using Lourtec.WebAppInventario.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lourtec.WebAppInventario.Logic.Services
{
    public class OrdenCompraService : GenericService<OrdenCompra>, IOrdenCompraService
    {
        public OrdenCompraService(IGenericRepository<OrdenCompra> respository) : base(respository)
        {
        }
    }
}
