// <copyright file="IFactory.cs" company="Maaike Tromp">
// Copyright (c) Maaike Tromp. All rights reserved.
// </copyright>

namespace SelectionExample.Interfaces
{
    /// <summary>
    /// Produces an instance of T.
    /// </summary>
    /// <typeparam name="T">An object that is IPopulatable.</typeparam>
    public interface IFactory<T>
        where T : IPopulatable
    {
        /// <summary>
        /// Gets an instance of object T.
        /// </summary>
        /// <param name="row">An object representing a row in a resultset.</param>
        /// <returns>An instance of T.</returns>
        public T GetInstance(IResultRow row);
    }
}
