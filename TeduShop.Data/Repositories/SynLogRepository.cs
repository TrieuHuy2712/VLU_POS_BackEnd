using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface ISyncLogRepository: IRepository<SyncLog>
    {

    }
    public class SynLogRepository : RepositoryBase<SyncLog>, ISyncLogRepository
    {
        public SynLogRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
