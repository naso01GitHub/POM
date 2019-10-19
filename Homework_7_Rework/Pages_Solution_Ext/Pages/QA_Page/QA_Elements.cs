
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Pages_Solution.Pages;
using System;
using System.IO;
using System.Reflection;

namespace Pages_Solution
{
    [TestFixture]
    public partial class QA_Logo : BasePage
    {

        public IWebElement visible_xs_class => ExtendedMethods.Wait_Until_FindElementByClass(Driver, "visible-xs", 3)[0];

        public IWebElement visible_xs_class_1 => Driver.FindElement(By.ClassName("visible-xs"));

        public IWebElement Learning => Driver.FindElement(By.XPath(@"//*[@id='header-nav']/div[1]/ul/li[2]/a/span"));


        public IWebElement QAModule => Driver.FindElement(By.XPath(@"//*[@id='header-nav']/div[1]/ul/li[2]/div/div/div[2]/div[2]/div/div[1]/ul[2]/div[1]/h2/a"));

        public IWebElement QAAutomationCourse => Driver.FindElement(By.XPath(@"/html/body/div[2]/div/section[2]/div[2]/div[3]/div/a/div[2]/h4"));

        //public IWebElement HeatherText => Wait.Until(c => c.FindElement(By.XPath(@"/html/body/div[2]/header/h1")));

        // IWebElement qa = driver.FindElement(By.XPath(@".//*/div/div/div[2]/div[2]/div/div[1]/ul[1]/div[1]/h2/a"));
        public IWebElement Module => Driver.FindElement(By.PartialLinkText("QA Automation - септември 2019"));

        public IWebElement H_Element => Driver.FindElement(By.TagName("h1"));

    }
}
 