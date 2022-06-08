using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;

namespace DnsShopUITests.Helpers
{
    internal class WebDriverManager
    {
        private IWebDriver? driver;
        private const string driverPath = @"../../../WebDrivers";

        public WebDriverManager InitDriver(Browser browser)
        {
            switch (browser)
            {
                case Browser.CHROME:
                    driver = new ChromeDriver(driverPath);
                    break;

                case Browser.FIREFOX:

                    /*
                    FirefoxDriverService firefoxDriverService = FirefoxDriverService.CreateDefaultService(driverPath);
                    firefoxDriverService.Host = "::1";
                    driver = new FirefoxDriver(firefoxDriverService);
                    */

                    driver = new FirefoxDriver(driverPath);
                    break;

                case Browser.OPERA:
                    driver = new OperaDriver(driverPath);
                    break;

                default:
                    throw new NotFoundException("Некорректное имя браузера!");
            }

            return this;
        }

        public IWebDriver? GetDriver() => driver;

    }
}
