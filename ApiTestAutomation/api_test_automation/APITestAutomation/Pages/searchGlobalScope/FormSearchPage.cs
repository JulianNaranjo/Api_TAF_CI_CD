using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestAutomationFramework.AplicationInterface.searchGlobalScope
{
    public class FormSearchPage
    {
        private readonly IWebDriver driver;

        private readonly By formSearchElement = By.Id("new_form_search");
        private readonly By findButtonElement = By.ClassName("bth-text-layer");

        private IWebElement formSearch => driver.FindElement(formSearchElement);
        private IWebElement findButtons => driver.FindElement(findButtonElement);

        public FormSearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void enterSearchForm(string searchText)
        {
            Actions clickAndPutTextActions = new Actions(driver);
            clickAndPutTextActions.Click(formSearch)
                .Pause(TimeSpan.FromSeconds(2))
                .SendKeys(searchText)
                .Perform();
        }

        public void clickFindButton()
        {
            findButtons.Click();
        }
    }
}
