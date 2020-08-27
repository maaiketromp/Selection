
using SelectionExample.Helpers;
using SelectionExample.Interfaces;

namespace SelectionExampleTests.Mockdata
{
    public class FormFieldModel : ISelectionModel<IFormField>
    {
        public IResultTable GetSelection()
        {
            var columns = new ColumnInfo[]
            {
                new ColumnInfo("Id", typeof(int)),
                new ColumnInfo("Name", typeof(string)),
                new ColumnInfo("HtmlTag", typeof(string)),
                new ColumnInfo("FormFieldInfoId", typeof(int)),
                new ColumnInfo("Type", typeof(string)),
                new ColumnInfo("Placeholder", typeof(string)),
                new ColumnInfo("Autocomplete", typeof(bool)),
                new ColumnInfo("Autofocus", typeof(bool)),
                new ColumnInfo("Hidden", typeof(bool)),
                new ColumnInfo("FormFieldInfoId", typeof(int)),
                new ColumnInfo("LookupTable", typeof(string)),
                new ColumnInfo("LookupValue", typeof(string)),
                new ColumnInfo("DisplayName", typeof(string)),
                new ColumnInfo("FilterWhere", typeof(string)),
                new ColumnInfo("OrderBy", typeof(string)),
            };

            var dataInputRow = new object[]
            {
                1,
                "FirstName",
                "input",
                1,
                "text",
                "First Name",
                false,
                false,
                false,
                null,
                null,
                null,
                null,
                null,
                null,
            };

            var dataSelectRow = new object[]
            {
                1,
                "PositionDropdown",
                "select",
                null,
                null,
                null,
                null,
                null,
                null,
                1,
                "Position",
                "Id",
                "Name",
                "",
                "Importance",
            };

            IResultTable data = new ResultTable(columns);
            data.Add(new ResultRow(dataInputRow, columns));
            data.Add(new ResultRow(dataSelectRow, columns));
            return data;
            
        }
    }
}
