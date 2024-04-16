using DnsShopUITests.Helpers;
using DnsShopUITests.Pages;

namespace DnsShopUITests
{
    [TestFixture(Browser.CHROME)]
    internal class CitySelectionTests : BaseTest
    {
        private HomePage homePage;

        public CitySelectionTests(Browser browser) : base(browser) { }

        [OneTimeSetUp]
        public new void OneTimeSetUp()
        {
            homePage = new HomePage(driver);
        }

        [SetUp]
        public void SetUp()
        {
            homePage
                .Header()
                .ClickByGeoLocationButton();
        }

        [Test, Order(1)]
        public void TestCitySelectionSearch()
        {
            string expectedCityName = "Владивосток";

            homePage
                .CitySelectionModal()
                .TypeInSearchBoxField("вЛаД")
                .SelectSuggestion(expectedCityName);

            string actualCityName = homePage
                .Header()
                .AfterPageReload()
                .GetGeoLocationCityName();

            Assert.That(actualCityName, Is.EqualTo(expectedCityName));
        }

        [Test, Order(2)]
        public void TestBigCitySelection()
        {
            IWebElement selectedBigCity = homePage
                .CitySelectionModal()
                .SelectBigCity();

            string expectedBigCityName = selectedBigCity.Text;

            selectedBigCity.Click();

            string actualBigCityName = homePage
               .Header()
               .AfterPageReload()
               .GetGeoLocationCityName();

            Assert.That(actualBigCityName, Is.EqualTo(expectedBigCityName));
        }

        [Test, Order(3)]
        public void TestCitySelectionList()
        {
            IWebElement selectedCity = homePage
                .CitySelectionModal()
                 .SelectDistrict()
                 .SelectRegion()
                 .SelectCity();

            string expectedCityName = selectedCity.Text;

            selectedCity.Click();

            string actualCityName = homePage
               .Header()
               .AfterPageReload()
               .GetGeoLocationCityName();

            Assert.That(actualCityName, Is.EqualTo(expectedCityName));
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
