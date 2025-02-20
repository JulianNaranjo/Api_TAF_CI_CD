using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestAutomationFramework.Business;
using TestAutomationFramework.Core;
using TestAutomationFramework.Core.BrowserUtils;
using TestAutomationFramework.Helpers;

namespace TestAutomationFramework.Test
{
    public abstract class BaseTest
    {
        protected IWebDriver? driver;
        protected LandingBusiness landingBusiness;
        public TestContext? TestContext { get; set; }

        [TestInitialize]
        public void setup()
        {            
            DriverFactory.InitDriver("chrome");
            driver = DriverFactory.GetDriver();
            var message = $"Start the BaseTest level with the driver: {driver}";
            Logger.LogInfo(message);
            landingBusiness = new LandingBusiness(driver);
        }

        [TestCleanup]
        public void closeBrowser()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                var message = $"When the test fail take of screenshot";
                Logger.LogInfo(message);
                ScreenshotMaker.TakeBrowserScreenshot(driver);
            }
            DriverFactory.CloseDriver();
        }
    }
}
