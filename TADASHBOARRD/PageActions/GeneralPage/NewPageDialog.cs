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
            EnterValue("pagename textbox", pageName);
           
            if (parentPage != "")
            {
                SelectItemByText("parentpage combobox", parentPage);
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
                Click("public checkbox");
            }
            Sleep(1);
            Click("ok button");


        }
    }
}
