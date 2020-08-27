using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelectionExample;
using SelectionExample.Interfaces;
using SelectionExampleTests.Implementation_classes;
using SelectionExampleTests.Mockdata;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelectionExampleTests
{
    [TestClass]
    public class SelectionTests
    {
        [TestMethod]
        public void TestSelection()
        {
            IDatabaseConnectable db = new MockDatabaseConnector();
            ISelectionModel<IFormField> model = new FormFieldModel();
            IFactory<IFormField> factory = new FormFieldFactory(db);
            ISelection<IFormField> selection = new Selection<IFormField>(model, factory);

            IResultTable modelData = model.GetSelection();
            List<IFormField> selectionData = selection.SelectionList;
            Assert.AreEqual(selectionData[0].HtmlTag, modelData[0]["HtmlTag"]);
            Assert.AreEqual(selectionData[1].HtmlTag, modelData[1]["HtmlTag"]);
        }
    }
}