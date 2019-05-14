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
    public interface IPOS1ProductImageRepository : IRepository<ProductImage>
    {
    }

    public class POS1ProductImageRepository : POS1RepositoryBase<ProductImage>, IPOS1ProductImageRepository
    {
        public POS1ProductImageRepository(IPOS1DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
