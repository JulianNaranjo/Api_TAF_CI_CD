using TestAutomationFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace TestAutomationFramework.AplicationInterface
{
    public class LandingPage
    {
        private readonly IWebDriver driver;

        private readonly By cookiesAcceptedButtonElement = By.Id("onetrust-accept-btn-handler");
        private readonly By insightsLinkElement = By.PartialLinkText("Insights");
        private readonly By aboutLinkElement = By.PartialLinkText("About");
        private readonly By careersLinkElement = By.PartialLinkText("Careers");
        private readonly By serviceLinkElement = By.PartialLinkText("Service");
        private readonly By searchIconElement = By.CssSelector(".search-icon");
        private readonly By ResponsibleAIElement = By.PartialLinkText("Responsible AI");

        private IWebElement AcceptAllCookiesButton => driver.FindElement(cookiesAcceptedButtonElement);
        private IWebElement insightsLink => driver.FindElement(insightsLinkElement);
        private IWebElement aboutLink => driver.FindElement(aboutLinkElement);
        private IWebElement careersLink => driver.FindElement(careersLinkElement);
        private IWebElement serviceLink => driver.FindElement(serviceLinkElement);
        private IWebElement searchIcon => driver.FindElement(searchIconElement);
        private IWebElement responsibleAI => driver.FindElement(ResponsibleAIElement);

        public LandingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void clickInsightsLink()
        {
            insightsLink.Click();
        }

        public void clickAboutLink()
        {
            aboutLink.Click();
        }

        public void clickCareersLink()
        {
            careersLink.Click();
        }

        public void openDrowdown()
        {
            Actions actionDropdown = new Actions(driver);
            actionDropdown
                .MoveToElement(serviceLink)
                .Perform();
        }

        public void clickResponsibleAI()
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => responsibleAI.Displayed);
            responsibleAI.Click();
        }

        public void clickSearchIcon()
        {
            searchIcon.Click();
        }

        public void acceptedCookies()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => AcceptAllCookiesButton.Displayed);
                AcceptAllCookiesButton.Click();
                wait.Until(driver => !AcceptAllCookiesButton.Displayed);

            }
            catch (Exception ex)
            {
                var message = $"Unable to click Accept All Cookies button.\n{ex.Message}.";
                Logger.LogError(message, ex );
            }
        }
    }
}
