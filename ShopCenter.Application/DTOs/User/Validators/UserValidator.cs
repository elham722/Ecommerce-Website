using FluentValidation;
using ShopCenter.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.DTOs.User.Validators
{
    public class UserValidator : AbstractValidator<CreateUserDto>
    {
        private readonly IUserRepository _userRepository;
       
        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(u => u.UserName).NotEmpty().WithMessage("نام کاربری را وارد کنید{PropertyName}")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must 50 carecter");

            RuleFor(p => p.Password).NotEmpty();

            RuleFor(i => i.Id).MustAsync(async (id, token) =>
                {
                    var userExist = await _userRepository.Exist(id);
                    return !userExist;
                }).
                WithMessage("{PropertyName} not exist");


        }
    }
}
