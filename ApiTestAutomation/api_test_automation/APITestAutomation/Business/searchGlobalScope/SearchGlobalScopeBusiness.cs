using OpenQA.Selenium;
using TestAutomationFramework.AplicationInterface.searchGlobalScope;

namespace TestAutomationFramework.Business.searchGlobalScope
{
    public class SearchGlobalScopeBusiness
    {
        private readonly FormSearchPage formSearchPage;
        private readonly SearchResultsPage searchResultsPage;

        public SearchGlobalScopeBusiness(IWebDriver driver)
        {
            formSearchPage = new FormSearchPage(driver);
            searchResultsPage = new SearchResultsPage(driver);
        }

        public void fillSearchForm(string keyword)
        {
            formSearchPage.enterSearchForm(keyword);
            formSearchPage.clickFindButton();
        }

        public bool validateContainsWordOnLink(string keyword)
        {
            return searchResultsPage.getLinksContainsWord(keyword);
        }
    }
}
