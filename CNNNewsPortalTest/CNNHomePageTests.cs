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
            IWebDriver driver = new ChromeDriver();

            CNNHomePage homePage = new CNNHomePage(driver);

            Assert.IsTrue(homePage.CheckPageLink(menuItem));

            driver.Close();
        }
    }
}