using NUnit.Framework;
using System.Collections.Generic;

namespace Pages_Solution.Pages
{
    public partial class Registration_Page : BasePage
    {
       

        public void Check_Error_Messages_Count()
        {
            string BaseErrorMessage = Get_Web_BaseError_Message();
            if(BaseErrorMessage != string.Empty && ExpectedErrorMessages.Count == 0)
            {
                Assert.IsTrue(false, "Not expected error message: " + BaseErrorMessage);
            }
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


        public void Assert_Error_Message(string expected)
        {
            Assert.AreEqual(expected, BaseErrorMessage.Text);
        }


        public void ConfirmMail( bool color )
        {
            Assert.IsTrue(color , "Email is not accepted");
        }
    }
}
