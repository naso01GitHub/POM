using OpenQA.Selenium;
using System.IO;


namespace Framework.Util
{
    public static class ScreenCapture
    {
        public static void ScreenShot(IWebDriver driver, string file)
        {
            // driver is your WebDriver

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var FilePath = Directory.GetCurrentDirectory();
            FilePath += "\\ScreenCapture";
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            FilePath += "\\" + file + ".png";
            screenshot.SaveAsFile(FilePath, ScreenshotImageFormat.Png);
        }

        public static void ClearCapture()
        {
            var FilePath = Directory.GetCurrentDirectory();
            FilePath += "\\ScreenCapture";
            if (Directory.Exists(FilePath))
            {
                Directory.Delete(FilePath, true);
            }
        }
    }
}
