
namespace SelectionExampleTests.Implementation_classes
{
    using SelectionExample.Interfaces;

    public class InputField : FormFieldInfoBase
    {
        public InputField(IDatabaseConnectable db, int id, bool activeUpdate = false)
            : base(db, id, activeUpdate)
        {
        }

        public InputField(IDatabaseConnectable db, IResultRow objectData, bool activeUpdate = false)
            : base(db, objectData, activeUpdate)
        {
        }

        public int FormFieldInfoId { get; set; }
        public string Type { get; set; }
        
        public string Placeholder { get; set; }

        public bool Autocomplete { get; set; }

        public bool Autofocus { get; set; }

        public bool Hidden { get; set; }
    }
}
