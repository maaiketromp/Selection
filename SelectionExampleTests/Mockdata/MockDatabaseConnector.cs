using Microsoft.Data.SqlClient;
using SelectionExample.Helpers;
using SelectionExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SelectionExampleTests.Mockdata
{
    class MockDatabaseConnector : IDatabaseConnectable
    {
        public int ExecutePreparedNonQuery(string commandText, SqlParameter[] parameters = null)
        {
            return 0;
        }

        public List<int> PrepareAndExecuteTransaction(string[] commandText, CommandType[] commandTypes, SqlParameter[][] parameters, string transactionName)
        {
            return new List<int>();
        }

        public IResultTable RetrievePreparedQueryResults(string commandText, SqlParameter[] parameters = null)
        {
            return new ResultTable(new ColumnInfo[] { });
        }
    }
}
