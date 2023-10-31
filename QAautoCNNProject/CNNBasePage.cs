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
        public CNNBasePage(IWebDriver _driver, string url)
        {
            _webDriver = _driver;
            _webDriver.Url = url;
            _webDriver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _webDriver.FindElement(By.XPath(ACCEPT_BUTTON_XPATH)).Click();
        }

        public List<IWebElement> GetElementsByXPath(string xPath) 
        {
            return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xPath)))
                        .Where(x => x.Displayed && x.Enabled).ToList();
        }

        public IWebElement GetElementByXPath(string xPath) 
        {
            return _wait.Until(ExpectedConditions.ElementExists(By.XPath(xPath)));        
        }


        
    }
}
