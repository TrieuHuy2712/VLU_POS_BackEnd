using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models.Synchronize
{
    public class OrderDetailBackupViewModel
    {
        public int ID { set; get; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }
        public int OrderID { set; get; }
        public int ProductID { set; get; }

    }
}