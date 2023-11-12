using OpenQA.Selenium;
namespace QAautoCNNProject
{
    public class CNNSearchPage : CNNBasePage
    {
        const string SEARCH_PAGE_CNN = "https://edition.cnn.com/search";
        const string SEARCH_PLACEHOLDER = "//input[@type='text' and @class = 'search__input']";
        const string SEARCH_BUTTON = "//button[@class='search__button icon icon--search']";
        const string SEARCH_RESULT_ELEMENTS = "//div[contains(@data-uri,'/_components/card/instances/')]";
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
