using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Linq;
using QAautoCNNProject;

namespace CNNNewsPortalTest
{
    [TestClass]
    public class CNNHomePageTests
    {
        IWebDriver _driver;

        [TestInitialize] 
        public void Initialize() 
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]
        [DataRow("US")]
        [DataRow("World")]
        [DataRow("Politics")]
        [DataRow("Business")]
        [DataRow("Opinion")]
        [DataRow("Health")]
        [DataRow("Entertainment")]
        [DataRow("Style")]
        [DataRow("Travel")]
        [DataRow("Sports")]
        [DataRow("Video")]
        public void CorrectMenuPointLinksTest(string menuItem)
        {
            CNNHomePage homePage = new CNNHomePage(_driver);
            Assert.IsTrue(homePage.CheckPageLink(menuItem));
        }

        [TestCleanup]
        public void Cleanup() 
        {
            _driver.Close();
        }
    }

    [TestClass]
    public class CNNSearchPageTests
    {
        IWebDriver _driver;
        [TestInitialize]       

        public void Initialize()
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]
        [DataRow("Poland")]
        [DataRow("Russia")]
        [DataRow("US")]
        [DataRow("Spain")]
        [DataRow("Portugal")]
        public void SearchTestPositive(string searchText)
        {
            CNNSearchPage searchPage = new CNNSearchPage(_driver);
            var results = searchPage.SearchElementsList(searchText);
            var filteredResults = results.Where(x => x.Contains(searchText)).ToList();

            Assert.IsTrue(filteredResults.Count >= results.Count / 4); // 25 процентов совпадений 
        }

        [TestMethod]
        [DataRow("sdehsreth")]
        [DataRow("!@@##^&^*(")]
        public void SearchTestNegative(string searchText)
        {
            CNNSearchPage searchPage = new CNNSearchPage(_driver);

            Assert.ThrowsException<WebDriverTimeoutException>(() => searchPage.SearchElementsList(searchText));
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Close();
        }
    }
}