using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedUITestProject1.Views
{
    public class LoginPage : BasePage
    {
        public void LoginTest(UITestControl parent, string login, string pass)
        {
            //preencher login
            EnterText<HtmlEdit>(parent, PropertyType.Name, "UserName", login);
            EnterText<HtmlEdit>(parent, PropertyType.Name, "Password", pass);
            Click<HtmlInputButton>(parent, PropertyType.ValueAttribute, "Login");

            //Playback.Wait(5000);           
        }
    }
}
