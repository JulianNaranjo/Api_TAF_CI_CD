using OpenQA.Selenium;
using TestAutomationFramework.AplicationInterface.blogMatches;

namespace TestAutomationFramework.Business.blogMatches
{
    public class InsightsBusiness
    {
        private readonly InsightsPage insightsPage;

        public InsightsBusiness(IWebDriver driver) 
        {
            insightsPage = new InsightsPage(driver);
        }

        public string MoveSwip(int quantityClicks)
        {
            insightsPage.swipScroll();
            insightsPage.clickSwipButton(quantityClicks);
            string combineTitle = insightsPage.getCombineTitle();
            insightsPage.clickReadMoreButton();
            return combineTitle;
        }

        public string getArticleTitle()
        {
            return insightsPage.getArticleTitle();
        }
    }
}
