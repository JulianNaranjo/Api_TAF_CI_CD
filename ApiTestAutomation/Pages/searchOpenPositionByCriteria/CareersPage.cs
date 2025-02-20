using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationFramework.AplicationInterface.CareersInterface
{
    public class CareersPage
    {
        private readonly IWebDriver driver;
        private WebDriverWait wait => new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        private readonly By keywordJobIdElement = By.Id("new_form_job_search-keyword");
        private readonly By locationsElement = By.ClassName("select2-selection__rendered");
        private readonly By allLocationsElement = By.XPath("//li[@title='All Locations' and @role='option']");
        private readonly By remoteCheckElement = By.XPath("//input[@name='remote']/following::label[1]");
        private readonly By submitButtonElement = By.XPath("//button[@type='submit']");
        private readonly By sortByElement = By.Id("sort-legend");
        private readonly By viewApplyElement = By.XPath("//ul[@class='search-result__list']/li[last()]/descendant::a[last()]");

        private IWebElement keywordJobId => driver.FindElement(keywordJobIdElement);
        private IWebElement locations => driver.FindElement(locationsElement);
        private IWebElement allLocations => driver.FindElement(allLocationsElement);
        private IWebElement remoteCheck => driver.FindElement(remoteCheckElement);
        private IWebElement submitButton => driver.FindElement(submitButtonElement);
        private IWebElement sortBy => driver.FindElement(sortByElement);
        private IWebElement viewApply => driver.FindElement(viewApplyElement);

        public CareersPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void enterKeyword(string keyword)
        {
            Actions clickAndPutKeywordActionsActions = new Actions(driver);
            clickAndPutKeywordActionsActions.Click(keywordJobId)
                .Pause(TimeSpan.FromSeconds(2))
                .SendKeys(keyword)
                .Pause(TimeSpan.FromSeconds(2))
                .Perform();
        }

        public void selectLocations()
        {
            locations.Click();
            allLocations.Click();
        }

        public void clickRemoteCheck()
        {
            remoteCheck.Click();
        }

        public void clickSubmitButton()
        {
            submitButton.Click();
        }

        public void clickApplyButton()
        {
            waitSortByPivot();
            getDisplayedApplyButton();
            viewApply.Click();
        }

        private void waitSortByPivot()
        {
            wait.Until(driver => sortBy);
        }

        private void getDisplayedApplyButton()
        {
            wait.Until(driver => viewApply.Displayed);
        }
    }
}
