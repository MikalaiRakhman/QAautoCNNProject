using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace QAautoCNNProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            CNNHomePage homePage = new CNNHomePage(driver);

            var allPointNames = new List<string> { "US", "World", "Politics", "Business", "Opinion", "Health", "Entertainment", "Style", "Travel", "Sports", "Video" };
            var results = new List<string>();
            foreach (var pointName in allPointNames) 
            {
                results.Add($"Result for {pointName} is  {homePage.CheckPageLink(pointName)}");
            }

            driver.Close();
        }
    }

}