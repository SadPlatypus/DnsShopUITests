namespace DnsShopUITests.Pages;

internal class BasePage
{
    private IWebDriver driver;
    public const string BaseUrl = "https://www.dns-shop.ru/";

    protected BasePage(IWebDriver driver)
    {
        this.driver = driver;
    }

    protected IWebElement FindElementIfVisibleBy(By locator)
    {
        WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        return webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
    }

    protected IReadOnlyList<IWebElement> FindElementsIfVisibleBy(By locator)
    {
        WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        return webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
    }

    protected bool IsPageReloaded()
    {
        IWebElement oldPage = driver.FindElement(By.TagName("html"));
        WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        return webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(oldPage));
    }
}
