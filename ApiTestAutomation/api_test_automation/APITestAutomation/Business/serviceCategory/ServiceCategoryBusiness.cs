using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TestAutomationFramework.AplicationInterface;
using TestAutomationFramework.Pages.serviceCategory;

namespace TestAutomationFramework.Business.serviceCategory
{
    public class ServiceCategoryBusiness
    {
        private readonly ResponsibleAIPage responsibleAIPage;

        public ServiceCategoryBusiness(IWebDriver driver)
        {
            responsibleAIPage = new ResponsibleAIPage(driver);
        }

        public string getTitle()
        {
            return responsibleAIPage.getResponsibleAITitle();
        }
    }
}
