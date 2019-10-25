using System;

namespace ProductApi.Models
{
    public class ProductItem
    {
        public ProductItem()
        {
        }

        public ProductItem(Guid itemID)
        {
            ItemID = itemID;
        }

        public Guid ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal? ItemPrice { get; set; }
    }
}
