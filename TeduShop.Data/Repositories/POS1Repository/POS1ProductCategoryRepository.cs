using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.POS1Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories.POS1Repository
{
    public interface IPOS1ProductCategoryRepository : IRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }

    public class POS1ProductCategoryRepository : POS1RepositoryBase<ProductCategory>, IPOS1ProductCategoryRepository
    {
        public POS1ProductCategoryRepository(IPOS1DbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}