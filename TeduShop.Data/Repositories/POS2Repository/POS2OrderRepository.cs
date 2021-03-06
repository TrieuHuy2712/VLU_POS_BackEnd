﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Common.ViewModels;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.POS2Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories.POS2Repository
{
    public interface IPOS2OrderRepository : IRepository<DetailOrder>
    {
        IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);
    }

    public class POS2OrderRepository : POS2RepositoryBase<DetailOrder>, IPOS2OrderRepository
    {
        public POS2OrderRepository(IPOS2DbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<RevenueStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate)
        {
            var query = from o in DbContext.Orders
                        join od in DbContext.OrderDetails
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
