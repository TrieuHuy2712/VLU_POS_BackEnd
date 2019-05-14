using TeduShop.Data.Infrastructure;
using TeduShop.Data.POS1Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories.POS1Repository
{
    public interface IPOS1ProductTagRepository : IRepository<ProductTag>
    {
    }

    public class POS1ProductTagRepository : POS1RepositoryBase<ProductTag>, IPOS1ProductTagRepository
    {
        public POS1ProductTagRepository(IPOS1DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}