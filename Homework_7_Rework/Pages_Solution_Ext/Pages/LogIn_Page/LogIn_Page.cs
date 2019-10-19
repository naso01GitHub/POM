using Framework.Util;
using OpenQA.Selenium;
using System.Diagnostics;

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
            var testMail = Random_gnerator.GenerateMail();
            Debug.WriteLine(testMail);
            Email.SendKeys( testMail);
            Debug.WriteLine(Email.Text);
            //Email.SendKeys(sMail);
        }
     
         
        //public new void Navigate()
        //{
        //   Driver.Url = "http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation";
        //}
    }
}
