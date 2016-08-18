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
            EnterValue("page name textbox", pageName);

            if (parentPage != "")
            {
                SelectItemByText("parent page combobox", parentPage);
            }

            if (numberOfColumns != "")
            {
                SelectItemByText("number of columns combobox", numberOfColumns);
            }
            if (displayAfter != "")
            {
                SelectItemByText("display after combobox", displayAfter);
            }
            Sleep(1);
            if (status == "public")
            {
                TickCheckbox("public checkbox");
            }
            Click("ok button");
            Sleep(1);

        }
        public void EditPage(string newPageName, string newParentPage, string newNumberOfColumns, string newDisplayAfter, string newStatus)
        {

            Sleep(1);
            EnterValue("page name textbox", newPageName);

            if (newParentPage != "")
            {
                EnterValueDropdownList("parent page combobox", newParentPage);
            }

            if (newNumberOfColumns != "")
            {
                SelectItemByText("number of columns combobox", newNumberOfColumns);
            }
            if (newDisplayAfter != "")
            {
                SelectItemByText("display after combobox", newDisplayAfter);
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
            return GetSelectedValueInComboBox("number of columns combobox");
        }
    }
}
