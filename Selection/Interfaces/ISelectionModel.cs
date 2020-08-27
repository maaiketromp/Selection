// <copyright file="ISelectionModel.cs" company="Maaike Tromp">
// Copyright (c) Maaike Tromp. All rights reserved.
// </copyright>

namespace SelectionExample.Interfaces
{
    /// <summary>
    /// Interface for a model that is supplied to a Selection class.
    /// </summary>
    /// <typeparam name="T">Type paramater is unused, but forces the correct model to be added to Selection.</typeparam>
    public interface ISelectionModel<T>
        where T : IPopulatable
    {
        /// <summary>
        /// Gets the data for the Selection.
        /// </summary>
        /// <returns>A resultset that acts as a collection.</returns>
        public IResultTable GetSelection();
    }
}
