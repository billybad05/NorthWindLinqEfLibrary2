using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWIndLinqEfLibrary2.Controllers;
using NorthWIndLinqEfLibrary2.Models;
using Microsoft.EntityFrameworkCore;


namespace NorthWIndLinqEfLibrary2.Controllers {

    public class OrderDetailsController { 

        private readonly AppDbContext _context = null!;
        public OrderDetailsController(AppDbContext context) {
            _context = context;
        }

        public IEnumerable<OrderDetail> GetAll() {
            return _context.OrderDetails;
        }

        public OrderDetail? GetByPK(int orderId, int productId) {
            return _context.OrderDetails.Find(orderId, productId);
        }

        public void Update(int orderId, int productId, OrderDetail orderDetail) {
            if (orderId != orderDetail.OrderId || productId != orderDetail.ProductId) { 
                throw new ArgumentException("PK doesn't match!");
            }
            _context.Entry(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return;
        }

        public OrderDetail Insert(OrderDetail orderDetail) {
            OrderDetail? od = GetByPK(orderDetail.OrderId, orderDetail.ProductId); 
            if(od is not null) {
                throw new Exception("Product already exist on the order!");
            }
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
            return orderDetail;
        }

        public void Delete(int orderId, int productId) {
            OrderDetail? orderDetail = GetByPK(orderId, productId);
            if (orderDetail is null) {
                throw new Exception("OrderDetail not found!");
            }
            _context.OrderDetails.Remove(orderDetail);
            _context.SaveChanges();
        }

    }
}

