using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodedUITestProject1.Views;

namespace CodedUITestProject1
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        BrowserWindow browser;
        LoginPage login;
        HomePage home;

        public CodedUITest1()
        {
            browser = new BrowserWindow();
            login = new LoginPage();
            home = new HomePage();
        }

        [TestMethod]
        public void OpenBrowser()
        {
            BrowserWindow.CurrentBrowser = "IE";
            browser = BrowserWindow.Launch(new Uri("http://executeautomation.com/demosite/Login.html"));
            browser.Maximized = true;
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\data.csv"
        , "data#csv", DataAccessMethod.Sequential), DeploymentItem("data.csv"), TestMethod]
        public void Login()
        {
            LoginPage login = new LoginPage();
            login.LoginTest(browser, TestContext.DataRow["username"].ToString(),
                                          TestContext.DataRow["password"].ToString());
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\data.csv"
        , "data#csv", DataAccessMethod.Sequential), DeploymentItem("data.csv"), TestMethod]
        public void SaveInformations()
        {
            home.SaveUser(browser, TestContext.DataRow["title"].ToString(),
                                         TestContext.DataRow["inits"].ToString(),
                                         TestContext.DataRow["fname"].ToString(),
                                         TestContext.DataRow["mname"].ToString(),
                                         TestContext.DataRow["genre"].ToString());
        }

        [TestMethod]
        public void AcceptSeleniumTerm()
        {
            home.NavigateToSeleniumIDE(browser);
            home.AcceptTerms(browser);
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            Util.takeScreenshot(TestContext.TestName);
            browser.CloseOnPlaybackCleanup = false;
        }




        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

    }
}
