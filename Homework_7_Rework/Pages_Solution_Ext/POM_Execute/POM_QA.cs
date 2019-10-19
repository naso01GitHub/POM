using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages_Solution.Pages;
using System;
using Framework.Util;
using System.IO;
using System.Reflection;

namespace Pages_Solution
{
   
    [TestFixture]
    public class POM_QA : BaseTest
    {

        //private ChromeDriver _driver;
        //private WebDriverWait _wait;
        private QA_Logo _QA_logInPage;
       


        [SetUp]
        public void ClassInit()
        {
       
            if ( Driver == null)
            {
                Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                Driver.Manage().Window.FullScreen();
            }
            _QA_logInPage = new QA_Logo(Driver);
        }

        [Test]
        public void FindText()
        {
            _QA_logInPage.QA_Navigate();
            _QA_logInPage.ClickLearning();
            _QA_logInPage.ClickFindText();      
            _QA_logInPage.AssertString();
        }



        [TearDown]
        public void close_driver()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var result = TestContext.CurrentContext.Result.Outcome;

            if ( result != ResultState.Success)
            {
                ScreenCapture.ScreenShot(Driver, testName);
                Driver.Close();
                Driver = null;                        
            }
        }
    }
}
