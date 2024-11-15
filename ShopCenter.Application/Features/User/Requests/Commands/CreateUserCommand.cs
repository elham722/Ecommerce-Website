using MediatR;
using ShopCenter.Application.DTOs.User;
using ShopCenter.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.Features.User.Requests.Commands
{
    public class CreateUserCommand : IRequest<BaseCommandResponse>
    {
        public CreateUserDto UserDTO { get; set; }
    }
}
