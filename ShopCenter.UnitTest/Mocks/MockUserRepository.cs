using Moq;
using ShopCenter.Application.Contracts.Persistence;
using ShopCenter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.UnitTest.Mocks
{
    public static class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserRepository()
        {
            var users = new List<Domain.Entities.User>() 
            {
               new Domain.Entities.User
               {
                   Id = 1,
                   UserName = "Testunit",
                   Password = "Testunit",
               } 
            };
            var mock = new Mock<IUserRepository>();
            mock.Setup(r => r.GetAll()).ReturnsAsync(users);

            mock.Setup(u => u.Add(It.IsAny<Domain.Entities.User>()))
                .ReturnsAsync( (Domain.Entities.User user) =>
                {
                    users.Add(user);
                    return user;
                });

            return mock; 
        }
    }
}
