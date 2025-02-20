using OpenQA.Selenium;
using TestAutomationFramework.AplicationInterface;

namespace TestAutomationFramework.Business
{
    public class LandingBusiness
    {
        private readonly LandingPage landingPage;

        public LandingBusiness(IWebDriver driver)
        {
            landingPage = new LandingPage(driver);
        }

        public void ClickCareersLink()
        {
            OpenMenuOption("careers");
        }

        public void ClickMagnifier()
        {
            OpenMenuOption("search icon");
        }

        public void ClickAboutLink()
        {
            OpenMenuOption("about");      
        }

        public void ClickInsightsLink()
        {
            OpenMenuOption("insights");           
        }

        public void openDrowdown()
        {
            OpenMenuOption("services");
        }

        public void OpenMenuOption(string menuOption)
        {
            landingPage.acceptedCookies();
            switch (menuOption)
            {
                case "careers":
                    landingPage.clickCareersLink();
                    break;
                case "search icon":
                    landingPage.clickSearchIcon();
                    break;
                case "about":
                    landingPage.clickAboutLink();
                    break;
                case "insights":
                    landingPage.clickInsightsLink();
                    break;
                case "services":
                    landingPage.openDrowdown();
                    landingPage.clickResponsibleAI();
                    break;
                default:
                    throw new ArgumentException($"Menu option not found: {menuOption}");
            }
        }

    }
}
