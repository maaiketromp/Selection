// <copyright file="IdPropertyAttribute.cs" company="Maaike Tromp">
// Copyright (c) Maaike Tromp. All rights reserved.
// </copyright>

namespace SelectionExample.Attributes
{
    using System;

    /// <summary>
    /// Identifies an Id Property (or properties) of a plain DataObject.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IdPropertyAttribute : Attribute
    {
    }
}
