using DnsShopUITests.Pages;
using DnsShopUITests.Utils;

namespace DnsShopUITests.Blocks
{
    internal class CitySelectionModal : BasePage
    {
        private Randomizer randomizer = new Randomizer();
        public CitySelectionModal(IWebDriver driver) : base(driver) { }

        private readonly By SearchBoxFieldLocator = By.XPath("//*[@id='select-city']//input");
        private readonly By SearchSuggestionsLocator = By.CssSelector(".cities-search > li");
        private readonly By BigCitiesButtonsLocator = By.CssSelector("span.city-bubble");
        private readonly By ListOfDistrictsLocator = By.XPath("//*[@class='districts']//a");
        private readonly By ListOfRegionsLocator = By.XPath("//*[@class='regions']//a");
        private readonly By ListOfCitiesLocator = By.XPath("//*[@class='cities']//a");

        public CitySelectionModal TypeInSearchBoxField(string cityName)
        {
            IWebElement searchBoxField = FindElementIfVisibleBy(SearchBoxFieldLocator);

            foreach (char letter in cityName)
            {
                searchBoxField.SendKeys(letter.ToString());
                Thread.Sleep(100);
            }

            return this;
        }

        public string SelectSuggestion(string cityName)
        {
            string selectedSuggestion = string.Empty;

            IReadOnlyList<IWebElement> searchSuggestionList = FindElementsIfVisibleBy(SearchSuggestionsLocator);

            foreach (var searchSuggestion in searchSuggestionList)
            {
                if (searchSuggestion.Text == cityName)
                {
                    selectedSuggestion = searchSuggestion.Text;
                    searchSuggestion.Click();
                    break;
                }
            }

            return selectedSuggestion;
        }

        public IWebElement SelectBigCity()
        {
            IReadOnlyList<IWebElement> bigCitiesButtonsList = FindElementsIfVisibleBy(BigCitiesButtonsLocator);
            return bigCitiesButtonsList.ElementAt(randomizer.GetRandomInt(bigCitiesButtonsList.Count));
        }

        public CitySelectionModal SelectDistrict()
        {
            IReadOnlyList<IWebElement> districtsList = FindElementsIfVisibleBy(ListOfDistrictsLocator);
            districtsList.ElementAt(randomizer.GetRandomInt(districtsList.Count)).Click();
            return this;
        }

        public CitySelectionModal SelectRegion()
        {
            IReadOnlyList<IWebElement> regionsList = FindElementsIfVisibleBy(ListOfRegionsLocator);
            regionsList.ElementAt(randomizer.GetRandomInt(regionsList.Count)).Click();
            return this;
        }

        public IWebElement SelectCity()
        {
            IReadOnlyList<IWebElement> citiesList = FindElementsIfVisibleBy(ListOfCitiesLocator);
            return citiesList.ElementAt(randomizer.GetRandomInt(citiesList.Count));
        }
    }
}
