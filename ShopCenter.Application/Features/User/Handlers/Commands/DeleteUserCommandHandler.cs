using AutoMapper;
using MediatR;
using ShopCenter.Application.Exceptions;
using ShopCenter.Application.Features.User.Requests.Commands;
using ShopCenter.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.Features.User.Handlers.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
           var user = await _userRepository.GetUserById(request.Id);
            if (user == null)
                throw new NotFoundException(nameof(user),request.Id);

            await _userRepository.Delete(user);
           // return Unit.Value;
        }
    }
}
