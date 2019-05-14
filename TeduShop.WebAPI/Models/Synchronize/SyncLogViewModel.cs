using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models.Synchronize
{
    public class SyncLogViewModel
    {
        public int ID { set; get; }
        public DateTime? CreatedDate { set; get; }

        public int Quantity { set; get; }

        public DateTime? LastTime { set; get; }
    }
}