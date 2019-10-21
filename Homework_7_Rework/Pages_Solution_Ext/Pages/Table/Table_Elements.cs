using OpenQA.Selenium;
using Pages_Solution.Pages;
using System.Collections.Generic;

namespace Pages_Solution
{
    public partial class TablePage : BasePage
    {
        public TablePage(IWebDriver driver) : base(driver)
        {
            SelectedFrame = 0;
            OldSelectedFrame = 0;
        }

        public IList<IWebElement> table => Driver.FindElements(By.XPath("/html/body/table/tbody/tr[2]/td[1]"));

        public IList<IWebElement> iframes => Driver.FindElements(By.TagName("iframe"));

        public IList<IWebElement> iframes_XPath => Driver.FindElements(By.TagName("//iframe"));

        public IWebElement Element =>ExtendedMethods.selectFirst_ByXPath_inAllFrames(Driver, "/html/body/table/tbody/tr[2]/td[1]");

        public int SelectedFrame { get; set; }
        public int OldSelectedFrame { get; set; }

    }
}
