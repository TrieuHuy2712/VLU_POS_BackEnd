namespace TeduShop.Web.Models
{
    public class OrderDetailViewModel
    {
        public int OrderID { set; get; }

        public int ProductID { set; get; }

        public int Quantity { set; get; }

        public int Price { set; get; }

        public ProductViewModel Product { get; set; }
    }
}