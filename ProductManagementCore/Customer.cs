using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Core
{
    public class Customer :DataClass
    {
        
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        [StringLength(1000)]
        public required string Address { get; set; }
        [Required]
        [StringLength(255)]
        public required string City { get; set; }
        [Required]
        [StringLength(2)]
        public required string State { get; set; }
        [Required]
        public required int Zip { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
