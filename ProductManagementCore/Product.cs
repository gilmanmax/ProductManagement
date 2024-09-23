using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Core
{
    public class Product :DataClass
    {
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }
        [Required]
        [StringLength(1000)]
        public required string Description { get; set; }
        [Required]
        public required decimal UnitCost {  get; set; }
        [StringLength(10000)]
        public string? ImageURL { get; set; }
    }
}
