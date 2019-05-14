using TeduShop.Data.Infrastructure;
using TeduShop.Data.POS1Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IPOS1TagRepository : IRepository<Tag>
    {
    }

    public class POS1TagRepository : POS1RepositoryBase<Tag>, IPOS1TagRepository
    {
        public POS1TagRepository(IPOS1DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}