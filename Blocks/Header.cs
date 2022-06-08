using DnsShopUITests.Pages;

namespace DnsShopUITests.Blocks
{
    internal class Header : BasePage
    {
        public Header(IWebDriver driver) : base(driver) { }

        private readonly By GeoLocationButtonLocator = By.CssSelector("div.city-select");
        private readonly By GeoLocationCityNameLocator = By.CssSelector("p.city-select__text");

        public Header ClickByGeoLocationButton()
        {
            IWebElement geoLocationButton = FindElementIfVisibleBy(GeoLocationButtonLocator);
            geoLocationButton?.Click();

            return this;
        }

        public Header AfterPageReload()
        {
            IsPageReloaded();
            return this;
        }

        public string GetGeoLocationCityName()
        {
            IWebElement geoLocationCityName = FindElementIfVisibleBy(GeoLocationCityNameLocator);
            return geoLocationCityName.Text;
        }
    }
}
