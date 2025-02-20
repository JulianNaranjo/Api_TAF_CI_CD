using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationFramework.AplicationInterface.blogMatches
{
    public class InsightsPage
    {
        private readonly IWebDriver driver;

        private readonly By swipElement = By.CssSelector(".slider__right-arrow.slider-navigation-arrow");
        private readonly By text1Element = By.XPath("//div[@class='owl-item active']//span[@class='museo-sans-light']");
        private readonly By text2Element = By.XPath("//div[@class='owl-item active']//span[@class='museo-sans-500 gradient-text']");
        private readonly By readMoreButtonElement = By.CssSelector(".owl-item.active .custom-link.link-with-bottom-arrow");
        private readonly By articleTitleElement = By.CssSelector(".column-control .font-size-80-33");

        private IWebElement swip => driver.FindElement(swipElement);
        private IWebElement text1 => driver.FindElement(text1Element);
        private IWebElement text2 => driver.FindElement(text2Element);
        private IWebElement readMoreButton => driver.FindElement(readMoreButtonElement);
        private IWebElement articleTitle => driver.FindElement(articleTitleElement);

        public InsightsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void swipScroll()
        {
            for (int i = 0; i < 6; i++)
            {
                Actions downloadActions = new Actions(driver);
                downloadActions
                    .SendKeys(Keys.ArrowDown)
                    .Perform();
            }
        }

        public void clickSwipButton(int quantityClicks)
        {
            waitShowSwipButton();
            for (int i = 0; i < 2; i++)
            {
                swip.Click();
            }
        }

        public string getCombineTitle()
        {
            waitShowTitle();
            return text1.Text + " " + text2.Text;
        }

        public void clickReadMoreButton()
        {
            readMoreButton.Click();
        }

        public string getArticleTitle()
        {
            return articleTitle.Text;
        }

        private void waitShowSwipButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => swip.Displayed);
        }

        private void waitShowTitle()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => text1.Displayed);
            wait.Until(driver => text2.Displayed);
        }
    }
}
