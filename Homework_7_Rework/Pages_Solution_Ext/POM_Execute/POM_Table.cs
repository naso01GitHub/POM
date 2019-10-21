using Framework.Util;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages_Solution;
using Pages_Solution.Pages;
using System.IO;
using System.Reflection;

namespace Pages_Solution
{
    [TestFixture]
    public class POM_Table:BaseTest
    {
      
        private TablePage _table;

        [SetUp]
        public void Init()
        {
            if (Driver == null)
            {
                Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                Driver.Manage().Window.FullScreen();
            }
            _table = new TablePage(Driver);
            _table.Table_Navigate();
        }



        [Test]
        public void FindCell_0()
        {
            if(_table.navigateToFrame_ByName("iframeResult"))
            {
                _table.AssertCellString("Jill", _table.table[0].Text);
            }
            else
            {
                throw new  NoSuchFrameException(" Required iFrame name :  iframeResult  not found");
            }            
        }



        [Test]
        public void FindCell_1()
        {         
             _table.AssertCellString("Jill", _table.Element.Text);
        }




        [TearDown]
        public void Close()
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
