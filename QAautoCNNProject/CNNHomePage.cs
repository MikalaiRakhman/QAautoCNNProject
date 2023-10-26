using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace QAautoCNNProject
{
    internal class CNNHomePage
    {
        IWebDriver _webDriver;
        const string HOME_PAGE_URL = "https://edition.cnn.com/";
        public CNNHomePage(IWebDriver _driver) 
        {
            _webDriver = _driver;
            _webDriver.Url = HOME_PAGE_URL;
            _webDriver.Manage().Window.Maximize();

            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
            wait.Until(x => x.FindElement(By.XPath("//*[@id=\"onetrust-accept-btn-handler\"]")));

            // Accept all coockies
            _webDriver.FindElement(By.XPath("//*[@id=\"onetrust-accept-btn-handler\"]")).Click();
            
            
        }

        public bool CheckPageLink(string keyWord)
        {
            string xPath = $"//a[@class='header__nav-item-link'][contains(@data-zjs-component_text, '{keyWord}')]";
            IWebElement menuItem = _webDriver.FindElement(By.XPath(xPath));
            menuItem.Click();
            string title = _webDriver.Title;
            string newUrl = _webDriver.Url;
            _webDriver.Navigate().Back();

            return title.Contains(keyWord) && newUrl.Contains(keyWord.ToLower());
        }

    }
}
