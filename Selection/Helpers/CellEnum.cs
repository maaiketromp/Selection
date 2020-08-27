// <copyright file="CellEnum.cs" company="Maaike Tromp">
// Copyright (c) Maaike Tromp. All rights reserved.
// </copyright>

namespace SelectionExample.Helpers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Cell enumerator.
    /// </summary>
    public class CellEnum : IEnumerator<object>
    {
        private readonly object[] cells;
        private int position;

        /// <summary>
        /// Initializes a new instance of the <see cref="CellEnum"/> class.
        /// </summary>
        /// <param name="cells">Array of databaseObject structs.</param>
        public CellEnum(object[] cells)
        {
            this.cells = cells;
            this.position = -1;
        }

        /// <inheritdoc/>
        public object Current
        {
            get
            {
                try
                {
                    return this.cells[this.position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        /// <inheritdoc/>
        object IEnumerator.Current { get => this.Current; }

        /// <inheritdoc/>
        public void Dispose()
        {
        }

        /// <inheritdoc/>
        public bool MoveNext()
        {
            this.position++;
            return this.position < this.cells.Length;
        }

        /// <inheritdoc/>
        public void Reset()
        {
            this.position = -1;
        }
    }
}
