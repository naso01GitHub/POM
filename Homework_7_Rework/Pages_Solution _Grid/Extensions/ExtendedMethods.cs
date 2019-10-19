using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Threading;
namespace Pages_Solution
{
    public static class ExtendedMethods
    {
        public static void SendText_to_Element(IWebElement element, string text)
        {
            element.Clear();
            if (text != String.Empty)
            {
                element.SendKeys(text);
            }
        }


        //wait until color change to desired
        //returns true/false
        public static bool Wait_for_Color(IWebElement Element, string ExpectColor, double seconds)
        {
            var dateAndTime = DateTime.Now;
            string ColorNow = Element.GetCssValue("color");
            while (ColorNow != ExpectColor)
            {
                var dateAndTimeNow = DateTime.Now;
                var diffInSeconds = (dateAndTimeNow - dateAndTime).TotalSeconds;
                if (diffInSeconds >= seconds)
                {
                    return false;
                }
                try
                {
                    ColorNow = Element.GetCssValue("color");
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }



        //gender enumerator
        public enum Gender
        {
            Male,
            Female
        }


        // Wait for ID and Returns list of  IWebElement 
        // or  NoSuchElementException
        public static ReadOnlyCollection<IWebElement> Wait_Until_FindElementByID(IWebDriver driver ,   string sId, int seconds)
        {
            //IWebElement temp = _wait.Until<IWebElement>(d => { return d.FindElement(By.Id(sId)); });

            var el = driver.FindElements(By.Id(sId));

            var Startime = DateTime.Now;
            while (el == null || el.Count == 0)
            {
                var dateAndTimeNow = DateTime.Now;
                var diffInSeconds = (dateAndTimeNow - Startime).TotalSeconds;
                if (diffInSeconds >= seconds)
                {
                    throw new NoSuchElementException(" Required ID: " + sId + " not found");
                }
                Thread.Sleep(100);
                el = driver.FindElements(By.Id(sId));
            }
            return el;
        }


        // Wait for XPath and Returns list of  IWebElement 
        // or  NoSuchElementException
        public static ReadOnlyCollection<IWebElement> Wait_Until_FindElementByXpath(IWebDriver driver  ,string sXpath, int seconds)
        {
            var el = driver.FindElements(By.XPath(sXpath));

            var Startime = DateTime.Now;
            while (el == null || el.Count == 0)
            {
                var dateAndTimeNow = DateTime.Now;
                var diffInSeconds = (dateAndTimeNow - Startime).TotalSeconds;
                if (diffInSeconds >= seconds)
                {
                    throw new NoSuchElementException(" Required XPath : " + sXpath + " not found");
                }
                Thread.Sleep(100);
                el = driver.FindElements(By.XPath(sXpath));
            }

            return el;
            //return _wait.Until<IWebElement>(d => { return d.FindElement(By.XPath(sXpath)); });
        }
    }
}
