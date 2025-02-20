using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationFramework.AplicationInterface.downloadFile
{
    public class AboutPage
    {
        private readonly IWebDriver driver;
        WebDriverWait wait => new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        private readonly string downloadDirectory = @"C:\Users\julian_naranjo\Downloads";

        private readonly By scrollSectionElement = By.CssSelector("[style='line-height: 1;']");
        private readonly By downloadButtonElement = By.PartialLinkText("DOWNLOAD");

        private IWebElement scrollSection => driver.FindElement(scrollSectionElement);
        private IWebElement downloadButton => driver.FindElement(downloadButtonElement);

        public AboutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void doScroll()
        {
            IWebElement section = scrollSection;
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", section);
        }

        public void downloadFile()
        {
            waitShowDownloadButton();
            Actions downloadActions = new Actions(driver);
            downloadActions.Click(downloadButton)
                .Pause(TimeSpan.FromSeconds(2))
                .Perform();
        }

        public bool getExistFile(string fileName)
        {
            return File.Exists(getCombineFilePath(fileName));
        }

        private void waitShowDownloadButton()
        {
            wait.Until(driver => downloadButton.Displayed);
        }

        private string getCombineFilePath(string fileName)
        {
            return Path.Combine(downloadDirectory, fileName);
        }
    }
}
