using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomationFramework.Business.searchGlobalScope;
using TestAutomationFramework.Core;

namespace TestAutomationFramework.Test
{
    [TestClass]
    public sealed class GloabalScopeTest : BaseTest
    {
        [TestMethod]
        [TestCategory("UI")]
        [DataRow("Blockchain")]
        public void searchGlobalScopeTest(string keyword)
        {
            DriverFactory.NavigateToUrl("https://www.epam.com");
            landingBusiness.ClickMagnifier();
            var searchGlobalScopeBusiness = new SearchGlobalScopeBusiness(driver);
            searchGlobalScopeBusiness.fillSearchForm(keyword);
            bool keywordOnListResutl = searchGlobalScopeBusiness.validateContainsWordOnLink(keyword);
            Assert.IsTrue(keywordOnListResutl);
        }
    }
}
