using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Dto;
using src.Models;
using src.Services.User;

namespace tests.Services
{
    public class UserServiceTest
    {
        private readonly IUserService _service; 

        public UserServiceTest(IUserService service) 
        {
            _service = service;
        }   

        [Fact]
        public void SaveUser()
        {
            // arrange
            var user = new UserDTO("UsernameTest", "jonhdoe@gmail.com");

            // act
            _service.PostUser(user);

            // assert
            var userSave = _service.GetUser(user.Id);
            Assert.NotNull(userSave);
        }
    }
}