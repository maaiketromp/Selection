using System;
using System.Collections.Generic;
using System.Text;

namespace SelectionExample.Interfaces
{
    public interface IFormField : IPopulatable
    {
        public string HtmlTag { get; set; }

        // user can add formfield methods like show() and validate()
    }
}
