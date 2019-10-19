using NUnit.Framework;
using System.Collections.Generic;

namespace Pages_Solution.Pages
{
    public partial class Registration_Page : BasePage
    {
       

        public void Check_Error_Messages_Count()
        {
            string BaseErrorMessage = Get_Web_BaseError_Message();
            if (ExpectedErrorMessages.Count == 1)
            {
                Assert.IsTrue(BaseErrorMessage.Contains("There is " + ExpectedErrorMessages.Count.ToString()), "The error count in Main Error message is wrong.");
            }
            else if (ExpectedErrorMessages.Count > 1)
            {
                Assert.IsTrue(BaseErrorMessage.Contains("There are " + ExpectedErrorMessages.Count.ToString()), "The error count in Main Error message is wrong.");
            }
        }




        public void Check_Error_Messages_Pressent()
        {
            List<string> Errors = Get_Web_Error_Messages();
            for (int i = 0; i < ExpectedErrorMessages.Count; i++)
            {
                Assert.IsTrue(Errors.Contains(ExpectedErrorMessages[i]), "Error " + ExpectedErrorMessages[i] + "does not exist.");
            }
        }



        public void Navigate(LogIn_Page page)
        {
            page.Navigate("http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation");
            var Before_Attr_Color = page.Email.GetCssValue("color");
            page.SendDefaultMail();
            page.Submit.Click();
            Assert.IsTrue(ExtendedMethods.Wait_for_Color(page.Email, "rgba(53, 179, 63, 1)", 10), "Email is not accepted");
        }
    }
}
