using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data;
using tests.Fixtures;

namespace tests.Services
{
    public class TaskServiceTest : IClassFixture<DatabaseFixture>
    {
        private readonly AppDbContext _context;

        public TaskServiceTest(DatabaseFixture fixture)
        {
            _context = fixture.Context;
        }
    }
}
