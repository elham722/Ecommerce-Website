using MediatR;
using ShopCenter.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.Features.User.Requests.Queries
{
    public class GetUserListRequest : IRequest<List<UserDTO>>
    {
    }
}
