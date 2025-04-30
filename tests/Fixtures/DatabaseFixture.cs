using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data;

namespace tests.Fixtures
{
    public class DatabaseFixture : IDisposable
    {
        public AppDbContext Context { get; }

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            Context = new AppDbContext(options);
        }

        public void ClearDatabase()
        {
            Context.Database.ExecuteSqlRaw("DELETE FROM Users ");
            Context.Database.ExecuteSqlRaw("DELETE FROM Tasks");
        }

        public void Dispose()
        {
            Context.Dispose();
        }

    }
}
