using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QAautoCNNProject;
namespace CNNNewsPortalTest
{
    [TestClass]
    public class CNNHomePageMenuTests
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
}