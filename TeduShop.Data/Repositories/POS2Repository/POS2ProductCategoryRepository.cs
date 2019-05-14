using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.POS1Infrastructure;
using TeduShop.Data.POS2Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories.POS2Repository
{
    public interface IPOS2ProductCategoryRepository : IRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }

    public class POS2ProductCategoryRepository : POS2RepositoryBase<ProductCategory>, IPOS2ProductCategoryRepository
    {
        public POS2ProductCategoryRepository(IPOS2DbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}