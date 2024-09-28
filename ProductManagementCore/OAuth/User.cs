using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Core
{
    public class User : DataClass
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        public string Username {  get; set; }
        [PasswordPropertyText]
        [StringLength(50)]
        public string Password { get; set; }

        public Customer Customer { get; set; }
        
        public ICollection<UserPermission> Permissions { get; set; }

        public ICollection<UserToken> UserTokens { get; set; }
    }
}
