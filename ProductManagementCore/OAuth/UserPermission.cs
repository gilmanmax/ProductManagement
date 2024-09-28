using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Core
{
    public enum UserPermission
    {
        RegisterationIncomplete = 0,
        View = 1,
        Buy = 2,
        ProductAdmin =3,
        CustomerAdmin = 4,
        OrderAdmin = 5,
        CanAccessAmazon = 6,
        CompleteAdmin = 7
    }
}
