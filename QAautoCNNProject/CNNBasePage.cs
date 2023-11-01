using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


namespace QAautoCNNProject
{
    public abstract class CNNBasePage
    {
        IWebDriver _webDriver;
        WebDriverWait _wait;

        const string ACCEPT_BUTTON_XPATH = "//*[@id=\"onetrust-accept-btn-handler\"]";
        public const string MENU_POINTS_XPATH = "//a[contains (@class, 'header__nav-item-link' )]";
        public const string HOME_PAGE_URL = "https://edition.cnn.com/";
        public const string SEARCH_PAGE_CNN = "https://edition.cnn.com/search";
        public const string SEARCH_PLACEHOLDER = "//input[@type='text' and @class = 'search__input']";
        public const string SEARCH_BUTTON = "//button[@class='search__button icon icon--search']";
        public const string SEARCH_RESULT_ELEMENTS = "//div[contains(@data-uri,'/_components/card/instances/')]";
        public CNNBasePage(IWebDriver _driver, string url)
        {
            _webDriver = _driver;
            _webDriver.Url = url;
            _webDriver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _wait.Until(ExpectedConditions.ElementToBeClickable(GetElementByXPath(ACCEPT_BUTTON_XPATH)));
            _webDriver.FindElement(By.XPath(ACCEPT_BUTTON_XPATH)).Click();
        }

        public List<IWebElement> GetElementsByXPath(string xPath) 
        {
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xPath)));
            return _webDriver.FindElements(By.XPath(xPath)).Where(x => x.Displayed && x.Enabled).ToList();
        }

        public IWebElement GetElementByXPath(string xPath) 
        {
            _wait.Until(ExpectedConditions.ElementExists(By.XPath(xPath)));
            return _webDriver.FindElement(By.XPath(xPath));        
        }

        public bool IsTitleValid(string keyWord)
        {
            return _webDriver.Title.Contains(keyWord);
        }

        public bool IsUrlValid(string keyWord)
        {
            return _webDriver.Url.Contains(keyWord);
        }

        public void NavigateBack()
        {
            _webDriver.Navigate().Back();
        }

        public void WaitUntilElementVisibleByXPath(string xPath)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
        }

        
    }
}
