using System.Linq;
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
}
