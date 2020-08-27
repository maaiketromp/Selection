// <copyright file="RowEnum.cs" company="Maaike Tromp">
// Copyright (c) Maaike Tromp. All rights reserved.
// </copyright>

namespace SelectionExample.Helpers
{
    using SelectionExample.Interfaces;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Enum for row enumeration.
    /// </summary>
    public class RowEnum : IEnumerator<IResultRow>
    {
        private readonly IResultRow[] rows;
        private int position;

        /// <summary>
        /// Initializes a new instance of the <see cref="RowEnum"/> class.
        /// </summary>
        /// <param name="rows">Rows to enumerate.</param>
        public RowEnum(IResultRow[] rows)
        {
            this.rows = rows;
            this.position = -1;
        }

        /// <inheritdoc/>
        public IResultRow Current
        {
            get
            {
                try
                {
                    return this.rows[this.position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        /// <inheritdoc/>
        object IEnumerator.Current => this.Current;

        /// <inheritdoc/>
        public void Dispose()
        {
        }

        /// <inheritdoc/>
        public bool MoveNext()
        {
            this.position++;
            return this.position < this.rows.Length;
        }

        /// <inheritdoc/>
        public void Reset()
        {
            this.position = -1;
        }
    }
}
