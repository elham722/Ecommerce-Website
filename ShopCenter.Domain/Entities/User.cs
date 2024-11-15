using ShopCenter.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Domain.Entities
{
    public class User : BaseDomainEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
