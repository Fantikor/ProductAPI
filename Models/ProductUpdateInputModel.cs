using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Models
{
    public class ProductUpdateInputModel
    {
        [Key]
        [Required]
        public Guid ItemId { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemName { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ItemPrice { get; set; }
    }
}
