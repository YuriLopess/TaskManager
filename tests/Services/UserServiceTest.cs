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
using Xunit;

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
        public async Task DeleteUser_UserNotFound_ReturnsNoRecordsFound()
        {
            var service = new UserService(_context);
            var nonExistingId = Guid.NewGuid();
            var result = await service.DeleteUser(nonExistingId);
            Assert.Equal("No records found", result.Message);
            Assert.False(result.Status);
        }

        [Fact]
        public async Task GetUser_UserNotFound_ReturnsNoRecordsFound()
        {
            var service = new UserService(_context);
            var nonExistingId = Guid.NewGuid();
            var result = await service.GetUser(nonExistingId);
            Assert.Equal("No records found", result.Message);
            Assert.False(result.Status);
        }

        [Fact]
        public async Task PostUser_ValidData_AddsUser()
        {
            var service = new UserService(_context);
            var userDto = new UserDTO("TestUser", "testuser@example.com");
            var result = await service.PostUser(userDto);
            Assert.Equal("User successfully registered!", result.Message);
            Assert.True(result.Status);
            Assert.Contains(result.Data, u => u.Username == "TestUser" && u.Email == "testuser@example.com");
        }

        [Fact]
        public async Task PutUser_UserNotFound_ReturnsNoRecordsFound()
        {
            var service = new UserService(_context);
            var userDto = new UserDTO("UpdatedUser", "updated@example.com");
            var result = await service.PutUser(userDto);
            Assert.Equal("No records found", result.Message);
            Assert.False(result.Status);
        }
    }
}
