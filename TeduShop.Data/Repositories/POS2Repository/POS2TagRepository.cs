using TeduShop.Data.Infrastructure;
using TeduShop.Data.POS1Infrastructure;
using TeduShop.Data.POS2Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories.POS2Repository
{
    public interface IPOS2TagRepository : IRepository<Tag>
    {
    }

    public class POS2TagRepository : POS2RepositoryBase<Tag>, IPOS2TagRepository
    {
        public POS2TagRepository(IPOS2DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}