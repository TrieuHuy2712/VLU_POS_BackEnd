using System.Collections.Generic;
using System.Data.SqlClient;
using TeduShop.Common.ViewModels;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;
using System.Linq;
using System;
using System.Globalization;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace TeduShop.Data.Repositories
{
    public interface IOrderBackupRepository : IRepository<OrderBackup>
    {
        IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);
    }

    public class OrderBackupRepository : RepositoryBaseBackup<OrderBackup>, IOrderBackupRepository
    {
        public OrderBackupRepository(IDbFactoryBackup dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate)
        {
            var query = from o in DbContext.OrderBackups
                        join od in DbContext.OrderBackupDetails
                        on o.ID equals od.OrderID
                       
                        select new
                        {
                            CreatedDate = o.CreatedDate,
                            Quantity = od.Quantity,
                            Price = od.Price,
                        };
            if (!string.IsNullOrEmpty(fromDate))
            {
                DateTime start = DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));

                query = query.Where(x => x.CreatedDate >= start);
            }
            if (!string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.ParseExact(toDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));

                query = query.Where(x => x.CreatedDate <= endDate);
            }

            var result = query.GroupBy(x => DbFunctions.TruncateTime(x.CreatedDate))
                .Select(r => new
                {
                    Date = r.Key.Value,
                    TotalSell = r.Sum(x => x.Price * x.Quantity),
                }).Select(x => new RevenueStatisticViewModel()
                {
                    Date = x.Date,
                    Revenues = x.TotalSell
                });
            return result.ToList();
        }
    }
}