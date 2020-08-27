// <copyright file="ResultRow.cs" company="Maaike Tromp">
// Copyright (c) Maaike Tromp. All rights reserved.
// </copyright>

namespace SelectionExample.Helpers
{
    using SelectionExample.Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <inheritdoc/>
    public class ResultRow : IResultRow
    {
        private readonly object[] cells;
        private readonly ColumnInfo[] columnInfos;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultRow"/> class.
        /// </summary>
        /// <param name="cells">row of database objects.</param>
        /// <param name="columnInfos">array of column info structs.</param>
        public ResultRow(object[] cells, ColumnInfo[] columnInfos)
        {
            // deep copy input array.
            this.cells = new object[cells.Length];
            for (int i = 0; i < cells.Length; i++)
            {
                this.cells[i] = cells[i];
            }

            this.columnInfos = columnInfos;
        }

        /// <inheritdoc/>
        public object this[string colName]
        {
            get
            {
                ColumnInfo col = (from colInfo in this.columnInfos
                                  where colInfo.Name == colName
                                  select colInfo).First();

                if (col.Equals(default(ColumnInfo)))
                {
                    throw new InvalidOperationException($"Could not find a column with column name {colName}");
                }

                int index = Array.IndexOf(this.columnInfos, col);
                return this.cells[index];
            }
        }

        /// <inheritdoc/>
        public object this[int index]
        {
            get
            {
                return this.cells[index];
            }
        }

        /// <inheritdoc/>
        public string GetColumnName(int i)
        {
            if (i < 0 || i >= this.columnInfos.Length)
            {
                throw new IndexOutOfRangeException();
            }

            return this.columnInfos[i].Name;
        }

        /// <inheritdoc/>
        public Type GetColumnType(int i)
        {
            if (i < 0 || i >= this.columnInfos.Length)
            {
                throw new IndexOutOfRangeException();
            }

            return this.columnInfos[i].Type;
        }

        /// <inheritdoc/>
        public IEnumerator<object> GetEnumerator()
        {
            return new CellEnum(this.cells);
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator1();
        }

        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }
    }
}
