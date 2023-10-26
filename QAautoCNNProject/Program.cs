using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace QAautoCNNProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            CNNHomePage homePage = new CNNHomePage(driver);


            bool USCheckResult = homePage.CheckPageLink("US");
            bool worldCheckResult = homePage.CheckPageLink("World");
            bool politicsCheckResult = homePage.CheckPageLink("Politics");
            bool businessCheckResult = homePage.CheckPageLink("Business");
            bool opinionCheckResult = homePage.CheckPageLink("Opinion");
            bool healthCheckResult = homePage.CheckPageLink("Health");
            bool entertainmentCheckResult = homePage.CheckPageLink("Entertainment");
            bool styleCheckResult = homePage.CheckPageLink("Style");
            bool travelCheckResult = homePage.CheckPageLink("Travel");
            bool sportsCheckResult = homePage.CheckPageLink("Sports"); // bug?
            bool videoCheckResult = homePage.CheckPageLink("Video");
           

            driver.Close();
        }
    }

}