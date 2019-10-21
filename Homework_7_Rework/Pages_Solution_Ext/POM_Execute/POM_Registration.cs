using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages_Solution.Pages;
using System;
using Framework.Util;
using System.IO;
using System.Reflection;

namespace Pages_Solution
{
   
    [TestFixture]
    public class POM_Registration : BaseTest
    {

        //private ChromeDriver _driver;
        //private WebDriverWait _wait;
        private Pattern _DefaultUserData;
        private Registration_Page _regPage;
        private LogIn_Page _logInPage;
       


        [SetUp]
        public void ClassInit()
        {
       
            if ( Driver == null)
            {
                Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                Driver.Manage().Window.FullScreen();
            }
            _DefaultUserData = FactoryDefault.CreateTestModel();
            _logInPage = new LogIn_Page(Driver);
            _regPage = new Registration_Page(Driver);          
        }



        [Test]
        public void  Missing_FirstName()
        {
            _DefaultUserData.Final_FirstName = string.Empty;
            _regPage.Add_to_ExpectedErrorList("firstname is required.");

            _regPage.Navigate(_logInPage);
            _regPage.FillForm(_DefaultUserData);
            _regPage.Check_Error_Messages_Count();
            _regPage.Check_Error_Messages_Pressent();
        }





        [Test]
        public void Missing_LastName()
        {
            _DefaultUserData.Final_LastName = string.Empty;
            _regPage.Add_to_ExpectedErrorList("lastname is required.");

            _regPage.Navigate(_logInPage);
            _regPage.FillForm(_DefaultUserData);
            _regPage.Check_Error_Messages_Count();
            _regPage.Check_Error_Messages_Pressent();
        }


        [Test]
        public void InvalidLastName()
        {
            _DefaultUserData.Final_LastName = "Aaaa@Bbbbb";
            _regPage.Add_to_ExpectedErrorList("lastname is invalid.");

            _regPage.Navigate(_logInPage);
            _regPage.FillForm(_DefaultUserData);
            _regPage.Check_Error_Messages_Count();
            _regPage.Check_Error_Messages_Pressent();
        }


        [Test]
        public void EmptyDate__EmptyMounts__WrongZip()
        {
            _DefaultUserData.B_Date = String.Empty;
            _DefaultUserData.B_Mounts = String.Empty;
            _regPage.Add_to_ExpectedErrorList("Invalid date of birth");
            _DefaultUserData.Zip = "12%^()";
            _regPage.Add_to_ExpectedErrorList("postcode is invalid.");
            _regPage.Add_to_ExpectedErrorList("The Zip/Postal code you've entered is invalid. It must follow this format: 00000");

            _regPage.Navigate(_logInPage);
            _regPage.FillForm(_DefaultUserData);
            _regPage.Check_Error_Messages_Count();
            _regPage.Check_Error_Messages_Pressent();
        }




        [Test]
        public void EmptyPhone__WrongGender__WrongZip_EmptyState()
        {
            _DefaultUserData.Phone = String.Empty;
            _regPage.Add_to_ExpectedErrorList("You must register at least one phone number.");
            _DefaultUserData.Zip = "12%^()";
            _regPage.Add_to_ExpectedErrorList("postcode is invalid.");
            _regPage.Add_to_ExpectedErrorList("The Zip/Postal code you've entered is invalid. It must follow this format: 00000");
            _DefaultUserData.Gender = 3;
            _DefaultUserData.State = String.Empty;
            _regPage.Add_to_ExpectedErrorList("This country requires you to choose a State.");

            _regPage.Navigate(_logInPage);
            _regPage.FillForm(_DefaultUserData);
            _regPage.Check_Error_Messages_Count();
            _regPage.Check_Error_Messages_Pressent();
        }


        [Test]
        public void EmptyPhone__WrongZip_EmptyPassword()
        {
            _DefaultUserData.Phone = String.Empty;
            _regPage.Add_to_ExpectedErrorList("You must register at least one phone number.");
            _DefaultUserData.Zip = "1234";
            _regPage.Add_to_ExpectedErrorList("The Zip/Postal code you've entered is invalid. It must follow this format: 00000");
            _DefaultUserData.Password = String.Empty;
            _regPage.Add_to_ExpectedErrorList("passwd is required.");

            _regPage.Navigate(_logInPage);
            _regPage.FillForm(_DefaultUserData);
            _regPage.Check_Error_Messages_Count();
            _regPage.Check_Error_Messages_Pressent();
        }



        [Test]
        public void EmptyCity()
        {
            _DefaultUserData.City = String.Empty;
            _regPage.Add_to_ExpectedErrorList("city is required.");
            
            _regPage.Navigate(_logInPage);
            _regPage.FillForm(_DefaultUserData);
            _regPage.Check_Error_Messages_Count();
            _regPage.Check_Error_Messages_Pressent();
        }




        [TearDown]
        public void close_driver()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var result = TestContext.CurrentContext.Result.Outcome;

            if ( result != ResultState.Success)
            {
                ScreenCapture.ScreenShot(Driver, testName);
                Driver.Close();
                Driver = null;                        
            }
        }
    }
}
