// <copyright file="ResultTable.cs" company="Maaike Tromp">
// Copyright (c) Maaike Tromp. All rights reserved.
// </copyright>

namespace SelectionExample.Helpers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using SelectionExample.Interfaces;

    /// <summary>
    /// ResultObject.
    /// </summary>
    public class ResultTable : IResultTable
    {
        private IResultRow[] rows;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultTable"/> class.
        /// </summary>
        /// <param name="columnInfo">Array of structs containing column information.</param>
        public ResultTable(ColumnInfo[] columnInfo)
        {
            this.rows = new ResultRow[0];
            this.ColumnInfo = columnInfo;
        }

        /// <summary>
        /// Gets array of column information.
        /// </summary>
        public ColumnInfo[] ColumnInfo { get; }

        /// <inheritdoc/>
        public int Count => this.rows.Length;

        /// <inheritdoc/>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets an Resultrow element on zero-based index.
        /// </summary>
        /// <param name="index">the nth element to access.</param>
        /// <returns>A resultrow object.</returns>
        public IResultRow this[int index]
        {
            get
            {
                return this.rows[index];
            }

            set
            {
                if (index < this.rows.Length)
                {
                    this.rows[index] = value;
                }
                else if (index == this.rows.Length)
                {
                    this.Add(value);
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        /// <inheritdoc/>
        public string GetColumnName(int i)
        {
            if (i >= this.ColumnInfo.Length)
            {
                throw new IndexOutOfRangeException();
            }

            return this.ColumnInfo[i].Name;
        }

        /// <inheritdoc/>
        public Type GetColumnType(int i)
        {
            if (i >= this.ColumnInfo.Length)
            {
                throw new IndexOutOfRangeException();
            }

            return this.ColumnInfo[i].Type;
        }

        /// <inheritdoc/>
        public IEnumerator<IResultRow> GetEnumerator()
        {
            return new RowEnum(this.rows);
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator1();
        }

        /// <inheritdoc/>
        public void Add(IResultRow item)
        {
            IResultRow[] temp = new ResultRow[this.rows.Length + 1];
            int i = 0;
            for (; i < this.rows.Length; i++)
            {
                temp[i] = this.rows[i];
            }

            temp[i] = item;
            this.rows = temp;
        }

        /// <inheritdoc/>
        public void Clear()
        {
            this.rows = null;
        }

        /// <inheritdoc/>
        public bool Contains(IResultRow item)
        {
            if (this.rows.Contains(item))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public void CopyTo(IResultRow[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("The array cannot be null.");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            }

            if (this.Count > array.Length - arrayIndex + 1)
            {
                throw new ArgumentException("The destination array has fewer elements than the collection.");
            }

            for (int i = 0; i < this.rows.Length; i++)
            {
                array[i + arrayIndex] = this.rows[i];
            }
        }

        /// <inheritdoc/>
        public bool Remove(IResultRow item)
        {
            bool result = false;

            if (this.rows.Contains(item))
            {
                int j = 0;
                IResultRow[] temp = new ResultRow[this.rows.Length - 1];
                for (int i = 0; i < this.rows.Length; i++)
                {
                    if (this.rows[i].Equals(item))
                    {
                        continue;
                    }

                    temp[j++] = this.rows[i];
                }

                this.rows = temp;
            }

            return result;
        }

        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }
    }
}
