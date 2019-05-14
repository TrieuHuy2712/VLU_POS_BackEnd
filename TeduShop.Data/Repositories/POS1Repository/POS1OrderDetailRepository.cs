using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.POS1Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories.POS1Repository
{
    public interface IPOS1OrderDetailRepository : IRepository<OrderDetail>
    {
    }
    public class POS1OrderDetailRepository : POS1RepositoryBase<OrderDetail>, IPOS1OrderDetailRepository
    {
        public POS1OrderDetailRepository(IPOS1DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
