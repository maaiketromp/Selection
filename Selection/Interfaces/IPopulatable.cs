// <copyright file="IPopulatable.cs" company="Maaike Tromp">
// Copyright (c) Maaike Tromp. All rights reserved.
// </copyright>

namespace SelectionExample.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for populatable data objects.
    /// </summary>
    public interface IPopulatable
    {
        /// <summary>
        /// Gets or sets a value indicating whether properties shall be updated immeadiately to the database.
        /// </summary>
        public bool ActiveUpdate { get; set; }

        /// <summary>
        /// Updates the populated object in the database.
        /// </summary>
        /// <returns>Number of rows (1) affected. returns zero on failure. </returns>
        public List<int> UpdateObject();
    }
}
