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
        public void CreateNewPage(string pageName, string parentPage, string numberOfColumns, string displayAfter)
        {
            Thread.Sleep(1000);
            EnterValue("pagename textbox", pageName);
           
            if (parentPage != "defaut")
            {
                SelectItemByText("parentpage combobox", parentPage);
            }

            if (numberOfColumns != "defaut")
            {
                SelectItemByText("numberofcolumns combobox", numberOfColumns);
            }
            if (displayAfter != "defaut")
            {
                SelectItemByText("displayafter combobox", displayAfter);
            }


            Click("ok button");


        }
    }
}
