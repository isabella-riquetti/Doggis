using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Doggis.Data.Programmability.Functions
{
    public class TableValuedFunctions
    {
        public const string ContextName = "DoggisContext";
        private readonly DbContext _dbContext;
        public TableValuedFunctions(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
