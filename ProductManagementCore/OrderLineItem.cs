using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Core
{
    public class OrderLineItem :DataClass
    {
        public Order Order { get; set; }
        public Product Product { get; set; }
        [Required]
        public int Quantity { get;set; }
        public int OrderId { get; set; }
    }
}
