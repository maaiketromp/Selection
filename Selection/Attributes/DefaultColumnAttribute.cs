// <copyright file="DefaultColumnAttribute.cs" company="Maaike Tromp">
// Copyright (c) Maaike Tromp. All rights reserved.
// </copyright>

namespace SelectionExample.Attributes
{
    using System;

    /// <summary>
    /// Identifies a column with a default value that needs to be updated when another column is updated.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DefaultColumnAttribute : Attribute
    {
    }
}
