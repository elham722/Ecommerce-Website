using AutoMapper;
using MediatR;
using ShopCenter.Application.DTOs.User;
using ShopCenter.Application.Features.User.Requests.Queries;
using ShopCenter.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.Features.User.Handlers.Queries
{
    public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest, List<UserDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserListRequestHandler(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDTO>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            var useresList = await _userRepository.GetAll();
            return _mapper.Map<List<UserDTO>>(useresList);
        }
    }
}
