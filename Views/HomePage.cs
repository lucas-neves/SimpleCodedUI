using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUITestProject1.Views
{
    public class HomePage : BasePage
    {
        public void SaveUser(UITestControl parent,
            string title, string inits, string fname, string mname, string genre)
        {
            //prosseguir e validar
            SelectComboBoxItemList(parent, "TitleId", title);
            EnterText<HtmlEdit>(parent, PropertyType.Id, "Initial", inits);
            EnterText<HtmlEdit>(parent, PropertyType.Id, "FirstName", fname);
            EnterText<HtmlEdit>(parent, PropertyType.Id, "MiddleName", mname);
            SelectRadioItemList(parent, genre);
            CheckItemCbx(parent, "english");
            CheckItemCbx(parent, "Hindi");
            Click<HtmlInputButton>(parent, PropertyType.Name, "Save");
        }

        public void NavigateToSeleniumIDE(UITestControl parent)
        {
            HoverInMenu<HtmlHyperlink>(parent, PropertyType.InnerText, "Automation Tools");
            HoverInMenu<HtmlHyperlink>(parent, PropertyType.InnerText, "Selenium");
            Click<HtmlHyperlink>(parent, PropertyType.InnerText, "Selenium IDE");
        }

        public void AcceptTerms(UITestControl parent)
        {
            ScrollAndClick<HtmlRadioButton>(parent, PropertyType.Name, "Accept");
        }
    }
}
