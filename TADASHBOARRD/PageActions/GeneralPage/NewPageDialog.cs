using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions;

namespace TADASHBOARRD.PageActions.GeneralPage
{
    public class NewPageDialog : GeneralPage
    {
        public void CreateNewPage(string pageName, string parentPage, string numberOfColumns, string displayAfter, string status)
        {
            Thread.Sleep(1000);
            EnterValue("page name textbox", pageName);
            if (parentPage != "")
            {
                EnterValueDropdownList("parent page combobox", parentPage);
            }
            if (numberOfColumns != "")
            {
                SelectItemByText("number of columns combobox", numberOfColumns);
            }
            if (displayAfter != "")
            {
                SelectItemByText("display after combobox", displayAfter);
            }
            if (status == "public")
            {
                TickCheckbox("public checkbox");
            }
            Click("ok button");
        }
    }
}
