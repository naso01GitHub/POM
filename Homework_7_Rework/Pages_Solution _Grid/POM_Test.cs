﻿using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Pages_Solution.Pages;
using System;
using System.IO;
using System.Reflection;
namespace Pages_Solution
{
   
    [TestFixture]
    public class POM_Test
    {

        private OpenQA.Selenium.IWebDriver _driver;
        //private WebDriverWait _wait;
        private Pattern _DefaultUserData;
        private Registration_Page _regPage;
        private LogIn_Page _logInPage;
       


        [SetUp]
        public void ClassInit()
        {
            ChromeOptions options = new ChromeOptions();
            options.PlatformName = "windows";
            options.BrowserVersion = "77.0";

            _driver = new RemoteWebDriver(new Uri("http://192.33.168.101:4444/wd/hub"), options.ToCapabilities(), TimeSpan.FromSeconds(10));

            //_driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.FullScreen();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            _DefaultUserData = FactoryDefault.CreateTestModel();
            _logInPage = new LogIn_Page(_driver);
            _regPage = new Registration_Page(_driver);
            
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
            _driver.Quit();
        }
    }
}
