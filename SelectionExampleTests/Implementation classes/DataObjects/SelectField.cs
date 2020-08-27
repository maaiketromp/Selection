// <copyright file="SelectField.cs" company="Maaike Tromp">
// Copyright (c) Maaike Tromp. All rights reserved.
// </copyright>

namespace SelectionExampleTests.Implementation_classes
{
    using SelectionExample.Interfaces;

    public class SelectField : FormFieldInfoBase
    {
        public SelectField(IDatabaseConnectable db, int id, bool activeUpdate = false)
            : base(db, id, activeUpdate)
        {
        }

        public SelectField(IDatabaseConnectable db, IResultRow objectData, bool activeUpdate = false)
            : base(db, objectData, activeUpdate)
        {
        }

        public int FormFieldInfoId { get; set; }

        public string LookupTable { get; set; }
        
        public string LookupValue { get; set; }

        public string DisplayName { get; set; }

        public string FilterWhere { get; set; }

        public string OrderBy { get; set; }
    }
}
