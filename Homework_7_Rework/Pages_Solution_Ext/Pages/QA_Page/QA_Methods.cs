
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
        public QA_Logo(IWebDriver driver) : base(driver)
        {

        }

        public void QA_Navigate()
        {
            Navigate("https://softuni.bg");
        }

        public void ClickLearning()
        {
            Learning.Click();
        }

        public void ClickModule()
        {
            QAModule.Click();
        }

        public void ClickFindText()
        {
            Module.Click();
        }
    }
}
 