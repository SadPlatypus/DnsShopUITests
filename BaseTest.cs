using DnsShopUITests.Helpers;
using DnsShopUITests.Pages;

namespace DnsShopUITests
{
    internal class BaseTest
    {
        protected Browser browser;
        protected IWebDriver? driver;

        protected BaseTest(Browser browser)
        {
            this.browser = browser;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new WebDriverManager().InitDriver(browser).GetDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Navigate().GoToUrl(BasePage.BaseUrl);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}
