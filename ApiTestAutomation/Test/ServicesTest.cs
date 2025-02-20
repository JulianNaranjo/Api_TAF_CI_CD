using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomationFramework.Business.downloadFile;
using TestAutomationFramework.Business;
using TestAutomationFramework.Business.serviceCategory;
using TestAutomationFramework.Core;

namespace TestAutomationFramework.Test
{
    [TestClass]
    public sealed class ServicesTest : BaseTest
    {
        [TestMethod]
        [DataRow("EPAM_Corporate_Overview_Q4_EOY.pdf")]
        public void SelectServiceCategory(string fileName)
        {
            DriverFactory.NavigateToUrl("https://www.epam.com");
            landingBusiness.openDrowdown();
            var SelectServiceCategory = new ServiceCategoryBusiness(driver);
            Console.WriteLine(SelectServiceCategory.getTitle());
        }
    }
}
