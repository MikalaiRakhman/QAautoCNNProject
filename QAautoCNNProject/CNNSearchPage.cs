using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace QAautoCNNProject
{
    public class CNNSearchPage
    {
        IWebDriver _driver;
        const string SEARCH_PAGE_CNN = "https://edition.cnn.com/search";
        const string SEARCH_PLACEHOLDER = "//input[@type='text' and @class = 'search__input']";
        const string SEARCH_BUTTON = "//button[@class='search__button icon icon--search']";
        const string SEARCH_RESULT_ELEMENTS = "//div[contains(@data-uri,'/_components/card/instances/')]";
        WebDriverWait _wait;
        public CNNSearchPage(IWebDriver driver) 
        {
            _driver = driver;
            _driver.Url = SEARCH_PAGE_CNN;
            _driver.Manage().Window.Maximize();

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//*[@id=\"onetrust-accept-btn-handler\"]")));

            // Accept all coockies
            driver.FindElement(By.XPath("//*[@id=\"onetrust-accept-btn-handler\"]")).Click();

        }

        public List<string> StartSearch(string searchKey) 
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SEARCH_PLACEHOLDER)));

            var searchPlaceHolder = _driver.FindElement(By.XPath(SEARCH_PLACEHOLDER));
            searchPlaceHolder.SendKeys(searchKey);

            _driver.FindElement(By.XPath(SEARCH_BUTTON)).Click();
                       
            var searchElemets = _driver.FindElements(By.XPath(SEARCH_RESULT_ELEMENTS));
             
            return searchElemets.Select(x => x.Text).ToList();
        }

    }
}
