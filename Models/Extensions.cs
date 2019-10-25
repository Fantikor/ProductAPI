using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Models
{
    public static class ProductContextExtensions
    {
        public static async Task<ProductItem> GetProductItemsAsync(this ProductContext context, ProductItem entity)
        {
            return await context.ProductItems.FirstOrDefaultAsync(item => item.ItemID == entity.ItemID);
        }
    }

    public static class ProductCreateInputModelExtensions
    {
        public static ProductItem ToEntity(this ProductCreateInputModel model)
            => new ProductItem
            {
                ItemID = Guid.NewGuid(),
                ItemName = model.ItemName,
                ItemPrice = model.ItemPrice,
            };
    }
}
