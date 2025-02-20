using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationFramework.AplicationInterface.searchGlobalScope
{
    public class SearchResultsPage
    {
        private readonly IWebDriver driver;
        private WebDriverWait wait => new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        private readonly By resultTitleElement = By.CssSelector(".search-results__title");
        private readonly By resultItemsElement = By.XPath("//div[@class='search-results__items']");
        private readonly By resultArticleElement = By.TagName("article");

        private IWebElement resultTitle => driver.FindElement(resultTitleElement);
        private IWebElement resultItems => driver.FindElement(resultItemsElement);
        private List<IWebElement> resultArticle => resultItems.FindElements(resultArticleElement).ToList();

        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool getLinksContainsWord(string searchText)
        {
            waitResultTitle();
            List<IWebElement> article = resultArticle;
            List<string> articleText = article.Select(x => x.Text).ToList();

            return articleText.Any(text => text.Contains(searchText));
        }

        private void waitResultTitle()
        {
            wait.Until(driver => resultTitle);
        }

    }
}
