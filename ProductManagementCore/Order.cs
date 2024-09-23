using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Core
{
    public  class Order : DataClass
    {
        [Required]
        public required int CustomerId { get; set; }
        public required Customer Customer { get; set; }
        public required ICollection<OrderLineItem> OrderLineItems { get; set; }
    }
}
