using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests.Fixtures
{
    [CollectionDefinition(nameof(DatabaseCollectionFixture))]
    public class DatabaseCollectionFixture : ICollectionFixture<DatabaseFixture>
    {

    }
}
