
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

        public void AssertString() => Assert.AreEqual("QA Automation - септември 2019", H_Element.Text);

    }
}
 