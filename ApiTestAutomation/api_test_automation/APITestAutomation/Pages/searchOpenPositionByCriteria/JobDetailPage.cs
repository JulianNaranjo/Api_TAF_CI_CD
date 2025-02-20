using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestAutomationFramework.AplicationInterface.CareersInterface
{
    public class JobDetailPage
    {
        private readonly IWebDriver driver;

        private readonly By findTitleElement = By.CssSelector(".vacancy-details-23__job-title");

        private IWebElement findTitle => driver.FindElement(findTitleElement);

        public JobDetailPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool getTextOnJob(string keyword)
        {
            return findTitle.Text.Contains(keyword);
        }

    }
}
