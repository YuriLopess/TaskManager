using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Dto;
using src.Models;
using src.Services.Task;
using tests.Fixtures;
using Xunit;

namespace tests.Services
{
    [Collection(nameof(DatabaseCollectionFixture))]
    public class TaskServiceTest
    {
        private readonly AppDbContext _context;
        private readonly TaskService _service;

        public TaskServiceTest(DatabaseFixture fixture)
        {
            _context = fixture.Context;
            _service = new TaskService(_context);
        }

        [Fact]
        public async Task DeleteTask_TaskNotFound_ReturnsNoRecordsFound()
        {
            var nonExistingId = Guid.NewGuid();
            var result = await _service.DeleteTask(nonExistingId);
            Assert.Equal("No records found", result.Message);
            Assert.False(result.Status);
        }

        [Fact]
        public async Task GetTask_TaskNotFound_ReturnsNoRecordsFound()
        {
            var nonExistingId = Guid.NewGuid();
            var result = await _service.GetTask(nonExistingId);
            Assert.Equal("No records found", result.Message);
            Assert.False(result.Status);
        }

        [Fact]
        public async Task PostTask_ValidData_AddsTask()
        {
            var taskDto = new TaskDTO(
                "Test Task",
                "Test Description",
                TagTypeModel.Work,
                Guid.NewGuid()
            );
            var result = await _service.PostTask(taskDto);
            Assert.Equal("Task successfully registered!", result.Message);
            Assert.True(result.Status);
            Assert.Contains(result.Data, t => t.Title == "Test Task" && t.Description == "Test Description");
        }

        [Fact]
        public async Task PutTask_TaskNotFound_ReturnsNoRecordsFound()
        {
            var taskDto = new TaskDTO(
                "Updated Title",
                "Updated Description",
                TagTypeModel.Personal,
                Guid.NewGuid()
            );
            var result = await _service.PutTask(taskDto);
            Assert.Equal("No records found", result.Message);
            Assert.False(result.Status);
        }
    }
}
