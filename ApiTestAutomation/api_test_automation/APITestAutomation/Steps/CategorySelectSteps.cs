using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestAutomationFramework.AplicationInterface;
using TestAutomationFramework.Business;
using TestAutomationFramework.Business.serviceCategory;
using TestAutomationFramework.Core;
using TestAutomationFramework.Pages.serviceCategory;

namespace TestAutomationFramework.Steps
{
    [Binding]
    public sealed class CategorySelectSteps
    {
        private readonly IWebDriver? driver;
        private LandingPage landingPage;
        private ResponsibleAIPage responsibleAIPage;

        public CategorySelectSteps() 
        {
            DriverFactory.InitDriver("chrome");
            this.driver = DriverFactory.GetDriver();
            landingPage = new LandingPage(driver);
            responsibleAIPage = new ResponsibleAIPage(driver);

        }

        [Given(@"I navigate to the EPAM Services page")]
        public void GivenINavigateToTheEpamServicesPage()
        {
            DriverFactory.NavigateToUrl();
            landingPage.acceptedCookies();
        }

        [When(@"I select '([^']*)'")]
        public void WhenISelectMenuOption(string menuOption)
        {
            landingPage.openDrowdown();
            landingPage.clickResponsibleAI();
        }
        
        [Then(@"I verify that the '([^']*)' is present in the page")]
        public void WhenIVerifyThatTheMenuOptionIsPresentInThePage(string title)
        {
            responsibleAIPage.getResponsibleAITitle();
        }
    }
}
