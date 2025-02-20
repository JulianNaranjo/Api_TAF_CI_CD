using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomationFramework.Business.blogMatches;
using TestAutomationFramework.Core;

namespace TestAutomationFramework.Test
{
    [TestClass]
    public sealed class InsightsTest : BaseTest
    {
        [TestMethod]
        [DataRow(2)]
        public void ValidateEqualsTitleOnBlog(int quantityClicks)
        {
            DriverFactory.NavigateToUrl("https://www.epam.com");
            landingBusiness.ClickInsightsLink();
            var insightsBusiness = new InsightsBusiness(driver);
            string previousTitle = insightsBusiness.MoveSwip(quantityClicks);
            string currentlyTitle = insightsBusiness.getArticleTitle();
            Assert.AreEqual(previousTitle, currentlyTitle);
        }
    }
}
