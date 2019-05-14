using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IOrderDetailBackupRepository : IRepository<OrderBackupDetail>
    {
    }
    public class OrderDetailBackupRepository : RepositoryBaseBackup<OrderBackupDetail>, IOrderDetailBackupRepository
    {
        public OrderDetailBackupRepository(IDbFactoryBackup dbFactory) : base(dbFactory)
        {
        }
    }
}
