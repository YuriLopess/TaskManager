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
using tests.Fixtures;

namespace tests.Services
{
    [Collection(nameof(DatabaseCollectionFixture))]
    public class UserServiceTest
    {
        private readonly AppDbContext _context;

        public UserServiceTest(DatabaseFixture fixture)
        {
            _context = fixture.Context; 
        }

        [Fact]
        public void SaveUser()
        {
            // arrange
            var user = new UserDTO("UsernameTest", "jonhdoe@gmail.com");

            var service = new UserService(_context);

            // act
            service.PostUser(user);

            // assert
            var userSave = service.GetUser(user.Id);
            Assert.NotNull(userSave);
        }
    }
}