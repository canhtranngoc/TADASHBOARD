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

            Thread.Sleep(1000);
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
