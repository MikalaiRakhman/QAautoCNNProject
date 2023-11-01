using OpenQA.Selenium;


namespace QAautoCNNProject
{
    public class CNNSearchPage : CNNBasePage
    {
        
        public CNNSearchPage(IWebDriver driver) : base(driver, SEARCH_PAGE_CNN)
        {

        }
      
        public List<string> SearchElementsList(string searchKey) 
        {
            WaitUntilElementVisibleByXPath(SEARCH_PLACEHOLDER);
            var searchPlaceHolder = GetElementByXPath(SEARCH_PLACEHOLDER);
            searchPlaceHolder.SendKeys(searchKey);
            GetElementByXPath(SEARCH_BUTTON).Click();
            Thread.Sleep(2000);
            return GetElementsByXPath(SEARCH_RESULT_ELEMENTS).Select(x => x.Text).ToList();
        }

    }
}
