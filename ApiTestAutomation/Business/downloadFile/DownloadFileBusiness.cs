using OpenQA.Selenium;
using TestAutomationFramework.AplicationInterface.downloadFile;

namespace TestAutomationFramework.Business.downloadFile
{
    public class DownloadFileBusiness
    {
        private readonly AboutPage aboutPage;

        public DownloadFileBusiness(IWebDriver driver) 
        {
            aboutPage = new AboutPage(driver);
        }

        public void DownloadFile()
        {
            aboutPage.doScroll();
            aboutPage.downloadFile();
        }

        public bool ExistFile(string fileName)
        {
            return aboutPage.getExistFile(fileName);
        }
    }
}
