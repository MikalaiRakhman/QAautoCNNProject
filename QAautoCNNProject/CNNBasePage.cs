using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium.Chrome;

namespace QAautoCNNProject
{
    public abstract class CNNBasePage
    {
        IWebDriver _webDriver;
        WebDriverWait _wait;

        const string ACCEPT_BUTTON_XPATH = "//*[@id=\"onetrust-accept-btn-handler\"]";
        const string MENU_POINTS_XPATH = "//a[contains (@class, 'header__nav-item-link' )]";
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

        
    }
}
