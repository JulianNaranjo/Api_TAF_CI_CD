using OpenQA.Selenium;

namespace TestAutomationFramework.Core.BrowserUtils
{
    public class ScreenshotMaker
    {
        public static string TakeBrowserScreenshot(IWebDriver driver)
        {
            var now = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-fff");
            var screenshotPath = Path.Combine(Environment.CurrentDirectory, $"Display_{now}.png");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenshotPath);

            return screenshotPath;
        }
    }
}
