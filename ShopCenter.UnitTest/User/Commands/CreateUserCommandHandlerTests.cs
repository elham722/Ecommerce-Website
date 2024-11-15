using AutoMapper;
using Moq;
using ShopCenter.Application.Contracts.Persistence;
using ShopCenter.Application.DTOs.User;
using ShopCenter.Application.Features.User.Handlers.Commands;
using ShopCenter.Application.Features.User.Handlers.Queries;
using ShopCenter.Application.Features.User.Requests.Commands;
using ShopCenter.Application.Features.User.Requests.Queries;
using ShopCenter.Application.Profiles;
using ShopCenter.UnitTest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.UnitTest.User.Commands
{
    public class CreateUserCommandHandlerTests
    {
        IMapper _mapper;
        Mock<IUserRepository> _mockRepository;
        CreateUserDto _userDTO;
        public CreateUserCommandHandlerTests()
        {
            _mockRepository = MockUserRepository.GetUserRepository();

            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _userDTO = new CreateUserDto()
            {
                Id = 2,
                Password = "password",
                UserName = "username",
            };
        }

        [Fact]
        public async Task CreateUserTest()
        {
            var handler = new CreateUserCommandHandler(_mockRepository.Object, _mapper);
            var result = await handler.Handle(new CreateUserCommand() { UserDTO = _userDTO}, CancellationToken.None);

            result.ShouldBeOfType<int>();
            var user = await _mockRepository.Object.GetAll();
            user.Count.ShouldBe(2);

        }
    }
}
