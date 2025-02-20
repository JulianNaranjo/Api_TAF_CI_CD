using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using TestAutomationFramework.Helpers;

namespace TestAutomationFramework.Core
{
    public static class DriverFactory
    {
        private static IWebDriver driver;

        public static IWebDriver InitDriver(string browserType = "chrome")
        {
            if (driver == null)
            {
                switch (browserType.ToLower())
                {
                    case "chrome":
                        ChromeOptions options = new();
                        options.AddArgument("--no-sandbox");
                        options.AddArgument("disable-infobars");
                        options.AddArgument("--incognito");
                        options.AddArgument("--disable-dev-shm-usage");
                        options.AddArgument("--headless");
                        driver = new ChromeDriver(options);
                        break;
                    case "firefox":
                        driver = new FirefoxDriver();
                        break;
                    case "edge":
                        driver = new EdgeDriver();
                        break;
                    default:
                        throw new ArgumentException($"Browser not supported: {browserType}");
                }
                
            }
            driver.Manage().Window.Maximize();
            return driver;
        }

        public static IWebDriver GetDriver() 
        { 
            if (driver == null)
            {
                return InitDriver();
            }
            return driver; 
        }

        public static void NavigateToUrl(string url)
        {
            var message = $"Start test with the URL: {url}";
            Logger.LogInfo(message);
            driver.Navigate().GoToUrl(url);
        }

        public static void NavigateToUrl()
        {
            var message = $"Start test with the URL: \"https://www.epam.com\"";
            Logger.LogInfo(message);
            driver.Navigate().GoToUrl("https://www.epam.com");
        }

        public static void CloseDriver()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
            driver = null;
        }
    }
}
