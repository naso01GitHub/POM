using OpenQA.Selenium;

namespace Pages_Solution.Pages
{
    public class LogIn_Page : BasePage
    { 
        string sMail = "1_1_1_3@123.com";
        public LogIn_Page(IWebDriver driver)
            : base(driver)
        {
        }



        public new string Url => "http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation";
        public IWebElement Email => Driver.FindElement(By.Id("email_create"));
        public IWebElement Submit => Driver.FindElement(By.Id("SubmitCreate"));   
        
        public void SendDefaultMail()
        {
            Email.SendKeys(sMail);
        }
     
        //public new void Navigate()
        //{
        //   Driver.Url = "http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation";
       //}
    }
}
