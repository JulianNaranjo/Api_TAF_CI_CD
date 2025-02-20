using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestAutomationFramework.Pages.serviceCategory
{
    public class ResponsibleAIPage
    {
        private readonly IWebDriver driver;

        private readonly By responsibleAITitleElement = By.PartialLinkText("Responsible AI");

        private IWebElement responsibleAITitle => driver.FindElement(responsibleAITitleElement);

        public ResponsibleAIPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string getResponsibleAITitle()
        {
            return responsibleAITitle.Text;
        }
    }
}
