using AutoMapper;
using MediatR;
using ShopCenter.Application.DTOs.User.Validators;
using ShopCenter.Application.Features.User.Requests.Commands;
using ShopCenter.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.Features.User.Handlers.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //var validator = new UserValidator(_userRepository);
            //var validatorResult = await validator.ValidateAsync(request.UpdateUserDTO);


            var user = await _userRepository.GetUserById(request.UpdateUserDTO.Id);
            _mapper.Map(request.UpdateUserDTO, user);
            await _userRepository.Update(user);
            return Unit.Value;
        }
    }
}
