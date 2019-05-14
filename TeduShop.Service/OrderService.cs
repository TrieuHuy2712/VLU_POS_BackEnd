﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IOrderService
    {
        DetailOrder Create(DetailOrder order);
        List<DetailOrder> GetList(string startDate, string endDate, string customerName, string status,
            int pageIndex, int pageSize, out int totalRow);

        DetailOrder GetDetail(int orderId);

        OrderDetail CreateDetail(OrderDetail order);

        //void DeleteDetail(int productId, int orderId, int colorId, int sizeId);

        DetailOrder UpdateStatus(int orderId);
        void Update(DetailOrder detailOrder);

        List<OrderDetail> GetOrderDetails(int orderId);

        void Save();
    }

    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            this._orderRepository = orderRepository;
            this._orderDetailRepository = orderDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public DetailOrder Create(DetailOrder order)
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

        public DetailOrder UpdateStatus(int orderId)
        {
            return _orderRepository.GetSingleById(orderId); 
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public List<DetailOrder> GetList(string startDate, string endDate, string customerName,
            string paymentStatus, int pageIndex, int pageSize, out int totalRow)
        {
            var query= _orderRepository.GetAll();
           
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
            if (paymentStatus=="true")
                query = query.Where(x => x.Status== true);
            if(paymentStatus == "false")
                query = query.Where(x => x.Status == false);
            totalRow = query.Count();
            return query.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public DetailOrder GetDetail(int orderId)
        {
            return _orderRepository.GetSingleByCondition(x => x.ID == orderId, new string[] { "OrderDetails" });
        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            return _orderDetailRepository.GetMulti(x => x.OrderID == orderId, new string[] { "Order", "Product" }).ToList();
        }

        public OrderDetail CreateDetail(OrderDetail order)
        {
            return _orderDetailRepository.Add(order);
        }
        public void Update(DetailOrder detailOrder)
        {
            _orderRepository.Update(detailOrder);
            
        }


    }
}