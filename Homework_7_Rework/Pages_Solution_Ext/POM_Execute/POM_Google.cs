using Framework.Util;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using Pages_Solution;
using System.IO;
using System.Reflection;

namespace Pages_Solution
{
    [TestFixture]
    public class POM_Google : BaseTest
    {
        private Google _google;

        [SetUp]
        public void ClassInit()
        {
            if (Driver == null)
            {
                Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                Driver.Manage().Window.FullScreen();
            }
            _google = new Google(Driver);
        }
       
        [Test]
        public void SeleniunBrowse()    
        {
            _google.GoogleNavigate();
            _google.Selenium();
            _google.AssertTitleString("Selenium - Web Browser Automation");
        }


        [TearDown]
        public void close_driver()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var result = TestContext.CurrentContext.Result.Outcome;

            if (result != ResultState.Success)
            {
                ScreenCapture.ScreenShot(Driver, testName);
                Driver.Close();
                Driver = null;
            }
        }
    }
}
