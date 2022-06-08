using DnsShopUITests.Blocks;

namespace DnsShopUITests.Pages
{
    internal class HomePage : BasePage
    {
        private readonly Header header;
        private readonly CitySelectionModal citySelectionModal;

        public HomePage(IWebDriver driver) : base(driver)
        {
            header = new Header(driver);
            citySelectionModal = new CitySelectionModal(driver);
        }

        public Header Header()
        {
            return header;
        }

        public CitySelectionModal CitySelectionModal()
        {
            return citySelectionModal;
        }
    }
}
