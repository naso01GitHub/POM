
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Pages_Solution;
using Pages_Solution.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Pages_Solution
{

    public partial class Google : BasePage
    {
        public Google(IWebDriver driver) : base(driver)
        {

        }

        public new string Url => "http://www.google.com";

        public IWebElement Search_Field => Driver.FindElement(By.Name("q"));
        public IList<IWebElement> AllResults => ExtendedMethods.Wait_Until_FindElementByXpath(Driver, "//*[@id='rso']/div[1]/div/div/div/div[1]/a[1]/h3", 3);
        
        
        //public IWebElement textfield => Driver.FindElement(By.Name("q"));

        //public IWebElement Firstpage => Wait.Until(t => t.FindElement(By.XPath("//*[@id='rso']/div[1]/div/div/div/div[1]/a[1]/h3")));
    }
}
 