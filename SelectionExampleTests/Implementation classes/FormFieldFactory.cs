using SelectionExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelectionExampleTests.Implementation_classes
{
    public class FormFieldFactory : IFactory<IFormField>
    {
        private readonly IDatabaseConnectable db;

        public FormFieldFactory(IDatabaseConnectable db)
        {
            this.db = db;
        }

        public IFormField GetInstance(IResultRow row)
        {
            return (row["HtmlTag"]) switch
            {
                "input" => new InputField(this.db, row, false),
                "select" => new SelectField(this.db, row, false),
                _ => new FormFieldInfoBase(this.db, row, false),
            };
        }
    }
}
