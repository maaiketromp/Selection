// <copyright file="ISelection.cs" company="Maaike Tromp">
// Copyright (c) Maaike Tromp. All rights reserved.
// </copyright>

namespace SelectionExample.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Generic Collection object.
    /// </summary>
    /// <typeparam name="T">Type of List stored in this object. T is IPopulatable.</typeparam>
    public interface ISelection<T>
        where T : IPopulatable
    {
        /// <summary>
        /// Gets the collectionList.
        /// </summary>
        List<T> SelectionList { get; }
    }
}