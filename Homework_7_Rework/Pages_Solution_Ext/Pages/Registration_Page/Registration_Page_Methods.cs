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

        // Add Error message string to list of expected errors
        public void Add_to_ExpectedErrorList(string Error)
        {
            ExpectedErrorMessages.Add(Error);
        }


        // Return list of Error Messages strings 
        public List<string> Get_Web_Error_Messages()
        {
            List<string> Errors = new List<string>();

            var ErrMessages = ExtendedMethods.Wait_Until_FindElementByXpath(Driver, "//*[@id='center_column']/div/ol/li", wait_time);

            for (int i = 0; i < ErrMessages.Count; i++)
            {
                Errors.Add(ErrMessages[i].Text);
            }
            return Errors;
        }



        // Return Main Error Message  string
        public string Get_Web_BaseError_Message()
        {
            //  //*[@id="center_column"]/div
            //var ErrMessage = Driver.FindElement(By.XPath("//*[@id='center_column']/div/p"));
            var ErrMessage = ExtendedMethods.Wait_Until_FindElementByXpath(Driver, "//*[@id='center_column']/div/p", 2)[0];
            return ErrMessage.Text;
        }



        public void Navigate(LogIn_Page page)
        {  
            page.Navigate("http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation");
            //var Before_Attr_Color = page.Email.GetCssValue("color");
            page.SendDefaultMail();
            page.Submit.Click();
            ConfirmMail(ExtendedMethods.Wait_for_Color(page.Email, "rgba(53, 179, 63, 1)", 10));
         }


        // FillForm with elements from PageModel class
        public void FillForm( Pattern  UserData)
        {
            if (UserData.Gender >= 0 && UserData.Gender <= (int)ExtendedMethods.Gender.Male)
            {
                RadioButtons[UserData.Gender].Click();
            }

            ExtendedMethods.SendText_to_Element(Customer_FirstName, UserData.FirstName);
            ExtendedMethods.SendText_to_Element(Customer_LastName, UserData.LastName);
            ExtendedMethods.SendText_to_Element(Password, UserData.Password);
            DateDD.SelectByValue(UserData.B_Date);
            MonthDD.SelectByValue(UserData.B_Mounts);
            YearDD.SelectByValue(UserData.B_Year);
            ExtendedMethods.SendText_to_Element(FinalFirstName, UserData.Final_FirstName);
            ExtendedMethods.SendText_to_Element(FinalLastName, UserData.Final_LastName);
            ExtendedMethods.SendText_to_Element(Address, UserData.Address);
            if (UserData.Country == String.Empty)
            {
                Country.SelectByIndex(0);
            }
            else
            {
                Country.SelectByText(UserData.Country);
            }
            ExtendedMethods.SendText_to_Element(City, UserData.City);

            if (UserData.State == String.Empty)
            {
                State.SelectByIndex(0);
            }
            else
            {
                State.SelectByText(UserData.State);
            }

            ExtendedMethods.SendText_to_Element(PostCode, UserData.Zip);
            ExtendedMethods.SendText_to_Element(Phone, UserData.Phone);
            ExtendedMethods.SendText_to_Element(Alias, UserData.alias);
            Submit.Click();
        }
    }
}
