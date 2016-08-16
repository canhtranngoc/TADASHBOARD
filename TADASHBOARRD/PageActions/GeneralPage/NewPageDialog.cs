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
                TickCheckbox("public checkbox");
            }

            Click("ok button");

        }
        public void EditPage(string newPageName, string newParentPage, string newNumberOfColumns, string newDisplayAfter, string newStatus)
        {

            Thread.Sleep(1000);
            EnterValue("pagename textbox", newPageName);

            if (newParentPage != "")
            {
                EnterValueDropdownList("parentpage combobox", newParentPage);
            }

            if (newNumberOfColumns != "")
            {
                SelectItemByText("numberofcolumns combobox", newNumberOfColumns);
            }
            if (newDisplayAfter != "")
            {
                SelectItemByText("displayafter combobox", newDisplayAfter);
            }

            if (newStatus == "public")
            {
                TickCheckbox("public checkbox");
            }

            if (newStatus == "unpublic")
            {
                UntickCheckbox("public checkbox");
            }

            Click("ok button");

        }

        public string GetSelectedValueInNumberOfColumns()
        {
            Sleep(1);
            return GetSelectedValueInComboBox("numberofcolumns combobox");
        }
    }
}
