using System;
using System.Collections.Generic;
using System.Text;
using OpheliaSuiteV2.Core.DataAccess.MongoDb;

namespace TransportRules {
    public class GenericDbContext : DbContext {
        public GenericDbContext(IDbClient client, string database) : base(client, database) { }
    }
}
