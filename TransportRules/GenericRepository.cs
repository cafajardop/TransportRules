using System;
using System.Collections.Generic;
using System.Text;
using OpheliaSuiteV2.Core.DataAccess.MongoDb;

namespace TransportRules {
    public class GenericRepository<T> : Repository<T> where T : EntityBase, new() {
        public GenericRepository(IDbContext context) : base(context) { }
    }
}
