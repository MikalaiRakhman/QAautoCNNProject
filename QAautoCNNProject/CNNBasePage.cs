using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
namespace QAautoCNNProject
{
    public abstract class CNNBasePage
    {
        IWebDriver _driver;
        WebDriverWait _wait;
        const string ACCEPT_BUTTON_XPATH = "//*[@id='onetrust-accept-btn-handler']";
        public CNNBasePage(IWebDriver driver, string url)
        {
            _driver = driver;
            _driver.Url = url;
            _driver.Manage().Window.Maximize();
            if (isVsisible(ACCEPT_BUTTON_XPATH))
            {
                AcceptCookies();
            }            
        }
        public List<IWebElement> GetElementsByXPath(string xPath) 
        {
            _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xPath)));
            return _driver.FindElements(By.XPath(xPath)).Where(x => x.Displayed && x.Enabled).ToList();
        }
        public IWebElement GetElementByXPath(string xPath) 
        {
            _wait.Until(ExpectedConditions.ElementExists(By.XPath(xPath)));
            return _driver.FindElement(By.XPath(xPath));        
        }
        public bool IsTitleValid(string keyWord)
        {
            return _driver.Title.Contains(keyWord);
        }
        public bool IsUrlValid(string keyWord)
        {
            return _driver.Url.Contains(keyWord);
        }
        public void NavigateBack()
        {
            _driver.Navigate().Back();
        }
        public void WaitUntilElementVisibleByXPath(string xPath)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
        }
        public void AcceptCookies() 
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _wait.Until(ExpectedConditions.ElementToBeClickable(GetElementByXPath(ACCEPT_BUTTON_XPATH)));
            _driver.FindElement(By.XPath(ACCEPT_BUTTON_XPATH)).Click();
        }
        public bool isVsisible(string xPath)
        {
            try 
            {
                var element = _driver.FindElement(By.XPath(xPath));
            }
            catch (NoSuchElementException ex)
            {
                return false; 
            }
            return _driver.FindElement(By.XPath(xPath)).Displayed && _driver.FindElement(By.XPath(xPath)).Enabled;
        }
    }
}
