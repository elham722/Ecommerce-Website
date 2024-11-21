using AutoMapper;
using MediatR;
using ShopCenter.Application.Contracts.Infrastructure;
using ShopCenter.Application.Contracts.Persistence;
using ShopCenter.Application.DTOs.User.Validators;
using ShopCenter.Application.Exceptions;
using ShopCenter.Application.Features.User.Requests.Commands;
using ShopCenter.Application.Models;
using ShopCenter.Application.Responses;
using ShopCenter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.Features.User.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper/*,IEmailSender emailSender*/)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            //_emailSender = emailSender;
        }


        public async Task<BaseCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var respose = new BaseCommandResponse();
            var validator = new UserValidator(_userRepository);
            var validatorResult = await validator.ValidateAsync(request.UserDTO);

            if (validatorResult.IsValid is false)
            {
                respose.Success = false;
                respose.Message = "creation failesd";
                respose.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var user = _mapper.Map<Domain.Entities.User>(request.UserDTO);
                user = await _userRepository.Add(user);
                respose.Success = true;
                respose.Message = "creation succesfil";
                respose.Id = user.Id;
            }

            //var email = new Email
            //{
            //    To = "eli",
            //    Subject = "v",
            //    Body = "h",
            //};
            ////try
            ////{
            ////    await _emailSender.SendEmail(email);
            ////}
            ////catch (Exception ex)
            ////{
            ////    //log
            ////}


            return respose;
        }
    }
}
