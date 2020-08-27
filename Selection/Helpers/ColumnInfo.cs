// <copyright file="ColumnInfo.cs" company="Maaike Tromp">
// Copyright (c) Maaike Tromp. All rights reserved.
// </copyright>

namespace SelectionExample.Helpers
{
    using System;

    /// <summary>
    /// Column info object with column type and name.
    /// </summary>
    public struct ColumnInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnInfo"/> struct.
        /// </summary>
        /// <param name="name">Column name.</param>
        /// <param name="type">Column type.</param>
        public ColumnInfo(string name, Type type)
        {
            this.Name = name;
            this.Type = type;
        }

        /// <summary>
        /// Gets the column name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the column type.
        /// </summary>
        public Type Type { get; }
    }
}
