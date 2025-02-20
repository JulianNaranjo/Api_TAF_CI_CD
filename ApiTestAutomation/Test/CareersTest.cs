using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomationFramework.Business.searchOpenPositionByCriteria;
using TestAutomationFramework.Core;

namespace TestAutomationFramework.Test
{

    [TestClass]
    public sealed class CareersTest : BaseTest
    {
        [TestMethod]
        [TestCategory("UI")]
        [DataRow("Python")]
        public void searchOpenPositionByCriteriaTest(string keyword)
        {
            DriverFactory.NavigateToUrl("https://www.epam.com");
            landingBusiness.ClickCareersLink();
            var careersBusiness = new CareersBusiness(driver);
            bool existKeywordPosition = careersBusiness.searchOpenPositionByCriteria(keyword);
            Assert.IsTrue(existKeywordPosition);
        }
    }

}
