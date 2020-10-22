using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Triscal.Infrastructure.Data.Factory
{
    public class TriscalFactory
    {
        private readonly IDbConnection _dbConnection;

        public TriscalFactory(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IDbConnection DbConnection()
        {
            return _dbConnection;
        }
    }
}
