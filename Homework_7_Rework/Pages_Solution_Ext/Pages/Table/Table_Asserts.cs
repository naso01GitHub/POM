
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
   
    public partial class TablePage : BasePage
    {
        public void AssertCellString(string Expect , string Actual) => Assert.AreEqual(Expect, Actual);
    }
}
 