using OpenQA.Selenium;

namespace QAautoCNNProject
{
    public class CNNHomePage : CNNBasePage
    {        
        public CNNHomePage(IWebDriver driver) : base(driver, HOME_PAGE_URL)
        {

        }

        public bool CheckPageLink(string keyWord)
        {
            var menuItem = GetElementsByXPath(MENU_POINTS_XPATH).Where(x => x.Displayed && x.Enabled && x.Text == keyWord).First();
            menuItem.Click();
            bool validTitle = IsTitleValid(keyWord);
            bool validUrl = IsUrlValid(keyWord.ToLower());
            NavigateBack();
            return validTitle && validUrl;
        }

    }
}
