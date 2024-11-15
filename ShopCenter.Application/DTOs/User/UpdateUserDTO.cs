using ShopCenter.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.DTOs.User
{
    public class UpdateUserDTO:BaseDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
