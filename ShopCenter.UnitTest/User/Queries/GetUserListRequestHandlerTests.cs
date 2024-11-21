using AutoMapper;
using Moq;
using ShopCenter.Application.Contracts.Persistence;
using ShopCenter.Application.DTOs.User;
using ShopCenter.Application.Features.User.Handlers.Queries;
using ShopCenter.Application.Features.User.Requests.Queries;
using ShopCenter.Application.Profiles;
using ShopCenter.UnitTest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.UnitTest.User.Queries
{
    public class GetUserListRequestHandlerTests
    {
        IMapper _mapper;
        Mock<IUserRepository> _mockRepository;
        public GetUserListRequestHandlerTests()
        {
            _mockRepository = MockUserRepository.GetUserRepository();

            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetUserListTest()
        {
            var handler = new GetUserListRequestHandler(_mockRepository.Object,_mapper);
            var result = await handler.Handle(new GetUserListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<UserDTO>>();
            result.Count.ShouldBe(1);
                
        }   
    }
}
