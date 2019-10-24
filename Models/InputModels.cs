using System;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models
{
    public class ProductCreateInputModel
    {
        [Required]
        [StringLength(100)]
        public string ItemName { get; set; }

        [Required]
        public decimal ItemPrice { get; set; }
    }

    public class ProductUpdateInputModel
    {
        [Key]
        [Required]
        public Guid ItemId { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemName { get; set; }

        [Required]
        public decimal ItemPrice { get; set; }
    }

    public static class Extensions
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
