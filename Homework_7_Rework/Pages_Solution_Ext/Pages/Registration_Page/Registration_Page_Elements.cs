using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;




namespace Pages_Solution.Pages
{
    public partial class Registration_Page : BasePage
    {
        public Registration_Page(IWebDriver driver)
            :base(driver )
        {
        }


        private List<string> ExpectedErrorMessages = new List<string>();
        private int wait_time = 10;

        public new string Url => "http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation";

        //public new void Navigate()
        //{
        //    Driver.Url = "http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation";
        //}


        // //*[@id="id_gender2"]

        //public IList<IWebElement> RadioButtons => Wait.Until(d => d.FindElements(By.XPath("//div[@class='radio']//input")));


        public IList<IWebElement> RadioButtons => ExtendedMethods.Wait_Until_FindElementByXpath(Driver , "//div[@class='radio']//input", wait_time);

        //public IList<IWebElement> RadioButtons2 => Driver.FindElements(By.ClassName("radio-inline"));
            
         

        public IWebElement Customer_FirstName => ExtendedMethods.Wait_Until_FindElementByID(Driver , "customer_firstname" , wait_time)[0];
        public IWebElement Customer_LastName => Driver.FindElement(By.Id("customer_lastname"));

        public IWebElement Password => Driver.FindElement(By.Id("passwd"));
        public IWebElement FinalFirstName => Driver.FindElement(By.Id("firstname"));
        public IWebElement FinalLastName => Driver.FindElement(By.Id("lastname"));
        public IWebElement Address => Driver.FindElement(By.Id("address1"));
        public IWebElement City => Driver.FindElement(By.Id("city"));
        public IWebElement PostCode => Driver.FindElement(By.Id("postcode"));
        public IWebElement Phone => Driver.FindElement(By.Id("phone_mobile"));
        public IWebElement Alias => Driver.FindElement(By.Id("alias"));
        public IWebElement registerButton => Driver.FindElement(By.Id("submitAccount"));

        public SelectElement DateDD
        {
            get
            {
                 IWebElement returnData = Driver.FindElement(By.Id("days"));
                return new SelectElement(returnData);
            }
        }

        public SelectElement MonthDD
        {
            get
            {
                IWebElement returnData = Driver.FindElement(By.Id("months"));
                return new SelectElement(returnData);
            }
        }

        public SelectElement YearDD
        {
            get
            {
                IWebElement returnData = Driver.FindElement(By.Id("years"));
                return new SelectElement(returnData);
            }
        }


        public SelectElement Country
        {
            get
            {
                IWebElement returnData = Driver.FindElement(By.Id("id_country"));
                return new SelectElement(returnData);
            }
        }

        public SelectElement State
        {
            get
            {
                IWebElement returnData = Driver.FindElement(By.Id("id_state"));
                return new SelectElement(returnData);
            }
        }

       
        public IWebElement Submit => Driver.FindElement(By.Id("submitAccount"));


        public IWebElement BaseErrorMessage => Driver.FindElement(By.XPath("//*[@id='center_column']/div/p"));
        IList<IWebElement> IWebErrorMessages => Driver.FindElements(By.XPath("//*[@id='center_column']/div/ol/li"));
    }
}
