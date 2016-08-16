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
           
            if (parentPage != "")
            {
                EnterValueDropdownList("parentpage combobox", parentPage);
            }

            if (numberOfColumns != "")
            {
                SelectItemByText("numberofcolumns combobox", numberOfColumns);
            }
            if (displayAfter != "")
            {
                SelectItemByText("displayafter combobox", displayAfter);
            }

            if (status == "public")
            {
                TickCheckbox("public checkbox");
            }

            Sleep(1);
            Click("ok button");
        }
    }
}
