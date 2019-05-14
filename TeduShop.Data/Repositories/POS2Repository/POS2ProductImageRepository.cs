using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.POS1Infrastructure;
using TeduShop.Data.POS2Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories.POS2Repository
{
    public interface IPOS2ProductImageRepository : IRepository<ProductImage>
    {
    }

    public class POS2ProductImageRepository : POS2RepositoryBase<ProductImage>, IPOS2ProductImageRepository
    {
        public POS2ProductImageRepository(IPOS2DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
