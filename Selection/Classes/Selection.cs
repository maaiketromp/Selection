// <copyright file="Selection.cs" company="Maaike Tromp">
// Copyright (c) Maaike Tromp. All rights reserved.
// </copyright>

namespace SelectionExample
{
    using SelectionExample.Interfaces;
    using System.Collections.Generic;

    /// <inheritdoc/>
    public class Selection<T> : ISelection<T>
        where T : IPopulatable
    {
        private readonly ISelectionModel<T> model;
        private readonly IFactory<T> factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Selection{T}"/> class.
        /// </summary>
        /// <param name="model">Model to retrieve data for collection.</param>
        /// <param name="factory">Factory to produce instances for the list.</param>
        public Selection(ISelectionModel<T> model, IFactory<T> factory)
        {
            this.model = model;
            this.factory = factory;
            this.CreateSelection();
        }

        /// <inheritdoc/>
        public List<T> SelectionList { get; private set; }

        private void CreateSelection()
        {
            var newList = new List<T>();
            var queryResult = this.model.GetSelection();
            foreach (var row in queryResult)
            {
                newList.Add(this.factory.GetInstance(row));
            }

            this.SelectionList = newList;
        }
    }
}
