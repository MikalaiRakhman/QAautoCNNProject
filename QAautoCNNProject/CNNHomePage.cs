using OpenQA.Selenium;

namespace QAautoCNNProject
{
    public class CNNHomePage : CNNBasePage
    {        
        const string HOME_PAGE_URL = "https://edition.cnn.com/";
        const string MENU_POINTS_XPATH = "//a[contains (@class, 'header__nav-item-link' )]";
        IWebDriver driver;


        public CNNHomePage(IWebDriver driver) : base(driver, HOME_PAGE_URL)
        {
            this.driver = driver;
        }

        public bool CheckPageLink(string keyWord)
        {

            var menuItem = GetElementsByXPath(MENU_POINTS_XPATH).Where(x => x.Displayed && x.Enabled && x.Text == keyWord).First();
            
            menuItem.Click();
            
            string title = driver.Title;
            string newUrl = driver.Url;
            driver.Navigate().Back();
            
            return title.Contains(keyWord) && newUrl.Contains(keyWord.ToLower());
        }

    }
}
