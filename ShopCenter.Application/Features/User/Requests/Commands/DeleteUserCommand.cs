using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.Features.User.Requests.Commands
{
    public class DeleteUserCommand:IRequest
    {
        public int Id { get; set; }
    }
}
