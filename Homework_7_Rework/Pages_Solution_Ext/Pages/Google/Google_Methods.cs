
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
       

        public void GoogleNavigate()
        {
            Navigate("http://www.google.com");
        }

        public void Selenium()
        {
            Search_Field.SendKeys("Selenium");
            Search_Field.Submit();
            AllResults[0].Click();
        }
    }
}
 