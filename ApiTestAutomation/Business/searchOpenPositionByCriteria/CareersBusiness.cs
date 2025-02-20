using OpenQA.Selenium;
using TestAutomationFramework.AplicationInterface.CareersInterface;

namespace TestAutomationFramework.Business.searchOpenPositionByCriteria
{
    public class CareersBusiness
    {
        private readonly CareersPage careersPage;
        private readonly JobDetailPage jobDetailPage;

        public CareersBusiness(IWebDriver driver)
        {
            careersPage = new CareersPage(driver);
            jobDetailPage = new JobDetailPage(driver);
        }

        public bool searchOpenPositionByCriteria(string keyword)
        {
            careersPage.enterKeyword(keyword);
            careersPage.selectLocations();
            careersPage.clickRemoteCheck();
            careersPage.clickSubmitButton();
            careersPage.clickApplyButton();
            return jobDetailPage.getTextOnJob(keyword);
        }
    }
}
