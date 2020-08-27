// <copyright file="DatabaseConnector.cs" company="Maaike Tromp">
// Copyright (c) Maaike Tromp. All rights reserved.
// </copyright>

namespace SelectionExample.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Microsoft.Data.SqlClient;
    using SelectionExample.Helpers;
    using SelectionExample.Interfaces;

    /// <summary>
    /// Wraps the database object to parse query results into IEnumerables.
    /// </summary>
    public class DatabaseConnector : IDisposable, IDatabaseConnectable
    {
        private readonly string connectionString;
        private SqlConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConnector"/> class.
        /// For development and testing purposes only.
        /// </summary>
        /// <param name="connString">Database connectionString.</param>
        public DatabaseConnector(string connString)
        {
            this.connectionString = connString;
            this.Initialize();
        }

        /// <inheritdoc/>
        public IResultTable RetrievePreparedQueryResults(string commandText, SqlParameter[] parameters = null)
        {
            using var rdr = this.PrepareAndExecuteQuery(commandText, parameters: parameters);

            ColumnInfo[] columns = (from col in rdr.GetColumnSchema()
                                    select new ColumnInfo(col.ColumnName, col.DataType)).ToArray();
            ResultTable result = new ResultTable(columns);

            while (rdr.Read())
            {
                object[] cells = new object[rdr.FieldCount];
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    object cell = rdr[i];
                }

                var row = new ResultRow(cells, columns);
                result.Add(row);
            }

            return result;
        }

        /// <inheritdoc/>
        public int ExecutePreparedNonQuery(string commandText, SqlParameter[] parameters = null)
        {
            using SqlCommand cmd = new SqlCommand(commandText, this.connection);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            return cmd.ExecuteNonQuery();
        }

        /// <inheritdoc/>
        public List<int> PrepareAndExecuteTransaction(
            string[] commandTexts,
            CommandType[] commandTypes,
            SqlParameter[][] parameters,
            string transactionName)
        {
            if (commandTexts.Length != commandTypes.Length ||
                commandTexts.Length != parameters.First().Length)
            {
                throw new InvalidOperationException("Input arrays must have the same lenghts");
            }

            List<int> returnValues = new List<int>();
            SqlCommand command = this.connection.CreateCommand();
            SqlTransaction transaction;

            transaction = this.connection.BeginTransaction(transactionName);
            command.Connection = this.connection;
            command.Transaction = transaction;

            try
            {
                for (int i = 0; i < commandTexts.Length; i++)
                {
                    command.CommandType = commandTypes[i];
                    command.CommandText = commandTexts[i];
                    if (parameters[i] != null)
                    {
                        command.Parameters.AddRange(parameters[i]);
                    }

                    returnValues.Add(command.ExecuteNonQuery());
                }

                transaction.Commit();
            }
            catch (Exception)
            {
                try
                {
                    transaction.Rollback();
                    return new List<int>() { 0 };
                }
                catch (Exception)
                {
                    // log exception.
                    return new List<int>() { -1 };
                }
            }

            return returnValues;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (this.connection.State != 0)
            {
                this.connection.Close();
            }
        }

        private void Initialize()
        {
            this.connection = new SqlConnection(this.connectionString);
            this.connection.Open();
        }

        private SqlDataReader PrepareAndExecuteQuery(
            string commandText,
            SqlParameter[] parameters = null)
        {
            using SqlCommand cmd = new SqlCommand(commandText, this.connection);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            return cmd.ExecuteReader();
        }
    }
}
