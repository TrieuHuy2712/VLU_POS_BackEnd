using TeduShop.Data.Infrastructure;
using TeduShop.Data.POS1Infrastructure;
using TeduShop.Data.POS2Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories.POS2Repository
{
    public interface IPOS2ProductTagRepository : IRepository<ProductTag>
    {
    }

    public class POS2ProductTagRepository : POS2RepositoryBase<ProductTag>, IPOS2ProductTagRepository
    {
        public POS2ProductTagRepository(IPOS2DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}