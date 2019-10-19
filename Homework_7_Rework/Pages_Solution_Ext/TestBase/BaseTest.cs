using Framework.Util;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;


namespace Pages_Solution
{

    public class BaseTest
    {
        public IWebDriver Driver { get; set; }
        [OneTimeSetUp]
        public void Initiliaze()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Driver.Manage().Window.FullScreen();
            ScreenCapture.ClearCapture();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }



        [OneTimeTearDown]
        public void CleanUp()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }
    }   
}
