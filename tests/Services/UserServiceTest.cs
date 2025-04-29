using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Dto;
using src.Models;
using src.Services.User;

namespace tests.Services
{
    public class UserServiceTest
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public void SaveUser()
        {
            // arrange
            var user = new UserDTO("UsernameTest", "jonhdoe@gmail.com");

            var context = GetInMemoryDbContext();
            var service = new UserService(context);

            // act
            service.PostUser(user);

            // assert
            var userSave = service.GetUser(user.Id);
            Assert.NotNull(userSave);
        }
    }
}