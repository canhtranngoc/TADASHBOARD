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
            Sleep(1);
            EnterValue("pagename textbox", pageName);
            SelectItemByText("parentpage combobox", parentPage);
            SelectItemByText("numberofcolumns combobox", numberOfColumns);
            SelectItemByText("displayafter combobox", displayAfter);
            TickCheckbox("public checkbox");
            Sleep(1);
            Click("ok button");
        }
    }
}
