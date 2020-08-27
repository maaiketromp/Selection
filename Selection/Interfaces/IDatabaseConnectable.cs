// <copyright file="IDatabaseConnectable.cs" company="Maaike Tromp">
// Copyright (c) Maaike Tromp. All rights reserved.
// </copyright>

namespace SelectionExample.Interfaces
{
    using Microsoft.Data.SqlClient;
    using System.Collections.Generic;
    using System.Data;

    public interface IDatabaseConnectable
    {
        /// <summary>
        /// Retrieves the result of a prepared query.
        /// </summary>
        /// <param name="commandText">Sql commandtext.</param>
        /// <param name="parameters">SqlParameter array.</param>
        /// <returns>A IResultTable object, which can be cast to IEnumerable.</returns>
        public IResultTable RetrievePreparedQueryResults(string commandText, SqlParameter[] parameters = null);

        /// <summary>
        /// Executes a userdefined SQL query.
        /// </summary>
        /// <param name="commandText">Sql string.</param>
        /// <param name="parameters">Array of SqlParameters.</param>
        /// <returns>Number of rows affected.</returns>
        public int ExecutePreparedNonQuery(string commandText, SqlParameter[] parameters = null);

        /// <summary>
        /// Executes a transaction of multiple statements, rolls back on failure .
        /// </summary>
        /// <param name="commandText">Array of commandTexts.</param>
        /// <param name="commandTypes">Array of CommandTypes.</param>
        /// <param name="parameters">Array of SqlParameterArrays.</param>
        /// <param name="transactionName">Name of the transaction.</param>
        /// <returns>the number of rows affected, per query.</returns>
        public List<int> PrepareAndExecuteTransaction(
            string[] commandText,
            CommandType[] commandTypes,
            SqlParameter[][] parameters,
            string transactionName);
    }
}
