

namespace SelectionExampleTests.Implementation_classes
{
    using SelectionExample.Attributes;
    using SelectionExample.Data;
    using SelectionExample.Interfaces;

    public class FormFieldInfoBase : DataObjectBase, IFormField
    {
        public FormFieldInfoBase(IDatabaseConnectable db, int id, bool activeUpdate = false)
            : base(db, id, activeUpdate)
        {
        }

        public FormFieldInfoBase(IDatabaseConnectable db, IResultRow objectData, bool activeUpdate = false)
            : base(db, objectData, activeUpdate)
        {
        }

        [IdProperty]
        public int Id { get; set; }

        public string Name { get; set; }

        public string HtmlTag { get; set; }

        public string Value { get; set; }
    }
}
