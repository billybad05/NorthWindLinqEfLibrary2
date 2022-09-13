using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWIndLinqEfLibrary2.Controllers;
using NorthWIndLinqEfLibrary2.Models;


namespace NorthWIndLinqEfLibrary2.Models {
    public class OrderDetail {

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public Single Discount { get; set; } //float

        public override string ToString() {
            return $"Order Detail: {OrderId}  |  {ProductId}  |  {UnitPrice}  |  {Quantity}  |  {Discount}";
        }


    }
}
