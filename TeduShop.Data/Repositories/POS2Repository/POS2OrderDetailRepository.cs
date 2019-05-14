using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.POS2Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories.POS2Repository
{
    public interface IPOS2OrderDetailRepository : IRepository<OrderDetail>
    {
    }
    public class POS2OrderDetailRepository : POS2RepositoryBase<OrderDetail>, IPOS2OrderDetailRepository
    {
        public POS2OrderDetailRepository(IPOS2DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
