using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IOrderBackupService
    {
        OrderBackup Create(OrderBackup order);
        List<OrderBackup> GetList(string startDate, string endDate, string customerName, string status,
            int pageIndex, int pageSize, out int totalRow);

        OrderBackup GetDetail(int orderId);

        OrderBackupDetail CreateDetail(OrderBackupDetail order);

        //void DeleteDetail(int productId, int orderId, int colorId, int sizeId);

        void UpdateStatus(int orderId);

        List<OrderBackupDetail> GetOrderDetails(int orderId);

        void Save();
    }
    public class OrderBackupService: IOrderBackupService
    {
        private IOrderBackupRepository _orderRepository;
        private IOrderDetailBackupRepository _orderDetailRepository;
        private IBackupUnitOfWork _unitOfWork;

        public OrderBackupService(IOrderBackupRepository orderRepository, IOrderDetailBackupRepository orderDetailRepository, IBackupUnitOfWork unitOfWork)
        {
            this._orderRepository = orderRepository;
            this._orderDetailRepository = orderDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public OrderBackup Create(OrderBackup order)
        {
            try
            {
                _orderRepository.Add(order);
                _unitOfWork.Commit();
                return order;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateStatus(int orderId)
        {
            var order = _orderRepository.GetSingleById(orderId);
            order.Status = true;
            _orderRepository.Update(order);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public List<OrderBackup> GetList(string startDate, string endDate, string customerName,
            string paymentStatus, int pageIndex, int pageSize, out int totalRow)
        {
            var query = _orderRepository.GetAll();
            if (!string.IsNullOrEmpty(startDate))
            {
                DateTime start = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
                query = query.Where(x => x.CreatedDate >= start);

            }
            if (!string.IsNullOrEmpty(endDate))
            {
                DateTime end = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"));
                query = query.Where(x => x.CreatedDate <= end);
            }
            if (!string.IsNullOrEmpty(paymentStatus))
                query = query.Where(x => x.PaymentStatus == paymentStatus);
            totalRow = query.Count();
            return query.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public OrderBackup GetDetail(int orderId)
        {
            return _orderRepository.GetSingleByCondition(x => x.ID == orderId, new string[] { "OrderDetails" });
        }

        public List<OrderBackupDetail> GetOrderDetails(int orderId)
        {
            return _orderDetailRepository.GetMulti(x => x.OrderID == orderId, new string[] { "Order", "Product" }).ToList();
        }

        public OrderBackupDetail CreateDetail(OrderBackupDetail order)
        {
            return _orderDetailRepository.Add(order);
        }

    }
}
