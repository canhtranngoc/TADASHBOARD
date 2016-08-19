using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TADASHBOARRD.PageActions.GeneralPage
{
    class EditPageDialog:GeneralPage
    {
        ///<summary>
        ///
        ///</summary>
        public void CancelEditPageDialog()
        {
            Click("cancel button");
        }

        ///<summary>
        ///
        ///</summary>
        public void EditPage(string newPageName, string newParentPage, string newNumberOfColumns, string newDisplayAfter, string newStatus)
        {

            Sleep(1);
            if (newParentPage != "")
            {
                EnterValueDropdownList("parent page combobox", newParentPage);
            }
            //wait for add page popup is loaded completedly
            Sleep(1);
            EnterValue("page name textbox", newPageName);
            if (newNumberOfColumns != "")
            {
                SelectItemByText("number of columns combobox", newNumberOfColumns);
            }
            if (newDisplayAfter != "")
            {
                SelectItemByText("display after combobox", newDisplayAfter);
            }
            Sleep(1);
            if (newStatus == "public")
            {
                TickCheckbox("public checkbox");
            }
            if (newStatus == "unpublic")
            {
                UntickCheckbox("public checkbox");
            }
            Click("ok button");
            Sleep(1);
        }

        ///<summary>
        ///
        ///</summary>
        public string GetSelectedValueInNumberOfColumns()
        {
            Sleep(1);
            return GetSelectedValueInComboBox("number of columns combobox");
        }
    }
}
