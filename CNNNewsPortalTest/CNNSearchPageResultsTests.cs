using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using QAautoCNNProject;
namespace CNNNewsPortalTest
{
    [TestClass]
    public class CNNSearchPageResultsTests
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
            Assert.IsTrue(filteredResults.Count >= results.Count / 4);
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
