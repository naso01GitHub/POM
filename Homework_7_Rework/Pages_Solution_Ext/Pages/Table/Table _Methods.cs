using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages_Solution.Pages;
using System.Collections.Generic;

namespace Pages_Solution
{
    public partial class TablePage : BasePage
    {
       
        public void switchFrames(int frame )
        {
            Driver.SwitchTo().Frame(frame);          
        }

 

        public bool navigateToFrame_ByName(string frame)
        {
            try
            {
                Driver.SwitchTo().Frame(frame);
            }
            catch(NoSuchFrameException)
            {
                return false;
            }
            return true;           
        }



        public IWebElement check_for_XPath_in_All_Frames(string XPAth)
        {

            IWebElement el =  ExtendedMethods.selectFirst_ByXPath_inAllFrames(Driver, XPAth);
            if( el == null)
            {
                throw new NoSuchElementException(" Required XPAth : " + XPAth + " not found in all Frames");
            }
            return el;
        }


            string web = "https://www.w3schools.com/html/tryit.asp?filename=tryhtml_table";
        //string web = "https://html.com/tables/";
        public void Table_Navigate()
        {
            Navigate(web);
        }
    }
}
