using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomationFramework.Business.downloadFile;
using TestAutomationFramework.Core;

namespace TestAutomationFramework.Test
{
    [TestClass]
    public sealed class AboutTest : BaseTest
    {
        [TestMethod]
        [TestCategory("UI")]
        [DataRow("EPAM_Corporate_Overview_Q4_EOY.pdf")]
        public void DownloadFile(string fileName)
        {
            DriverFactory.NavigateToUrl("https://www.epam.com");
            landingBusiness.ClickAboutLink();
            var downloadFileBusiness = new DownloadFileBusiness(driver);
            downloadFileBusiness.DownloadFile();
            bool existFile = downloadFileBusiness.ExistFile(fileName);
            Assert.IsTrue(existFile);
        }
    }
}
