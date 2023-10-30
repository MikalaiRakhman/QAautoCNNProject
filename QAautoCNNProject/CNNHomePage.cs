using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Linq;


namespace QAautoCNNProject
{
    public class CNNHomePage
    {
        IWebDriver _webDriver;
        const string HOME_PAGE_URL = "https://edition.cnn.com/";
        public CNNHomePage(IWebDriver _driver) 
        {
            _webDriver = _driver;
            _webDriver.Url = HOME_PAGE_URL;
            _webDriver.Manage().Window.Maximize();

            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//*[@id=\"onetrust-accept-btn-handler\"]")));

            // Accept all coockies
            _webDriver.FindElement(By.XPath("//*[@id=\"onetrust-accept-btn-handler\"]")).Click();
            
            
        }

        public bool CheckPageLink(string keyWord)
        {
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
            string xPath = "//a[contains (@class, 'header__nav-item-link' )]";
            
            var menuItem = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xPath)))
                               .Where(x => x.Displayed && x.Enabled && x.Text.Contains(keyWord)).First();

            menuItem.Click();
            string title = _webDriver.Title;
            string newUrl = _webDriver.Url;
            _webDriver.Navigate().Back();

            return title.Contains(keyWord) && newUrl.Contains(keyWord.ToLower());
        }

    }
}
