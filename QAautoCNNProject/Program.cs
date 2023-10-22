using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Runtime.CompilerServices;

namespace QAautoCNNProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            string mainPage = "https://edition.cnn.com/";
            driver.Url = mainPage;

            Thread.Sleep(3000);

            // Accept all coockies
            IWebElement acceptAllCoockiesButtom = driver.FindElement(By.XPath("//*[@id=\"onetrust-accept-btn-handler\"]"));
            acceptAllCoockiesButtom.Click();
            Thread.Sleep(3000);


            static void CheckMainPageMenuItem(IWebDriver driver, string xPath, string keyWord)
            {
                IWebElement menuItem = driver.FindElement(By.XPath(xPath));
                menuItem.Click();
                string title = driver.Title;
                // test 1
                Console.WriteLine(title);
                Console.WriteLine("Test case 1. This page is opened:");
                Console.WriteLine(title.Contains(keyWord));
                // test 2
                string newUrl = driver.Url;
                Console.WriteLine($"Test case 2. Link is valid: {newUrl}");
                Console.WriteLine(newUrl.Contains(keyWord.ToLower()));
                Console.WriteLine();
                //return to Home Page
                driver.Url = "https://edition.cnn.com/";
            }
            
            CheckMainPageMenuItem(driver, "//*[@id=\"pageHeader\"]/div/div/div[1]/div[1]/nav/div/div[1]/a", "US");
            CheckMainPageMenuItem(driver, "//*[@id=\"pageHeader\"]/div/div/div[1]/div[1]/nav/div/div[2]/a", "World");
            CheckMainPageMenuItem(driver, "//*[@id=\"pageHeader\"]/div/div/div[1]/div[1]/nav/div/div[3]/a", "Politics");
            CheckMainPageMenuItem(driver, "//*[@id=\"pageHeader\"]/div/div/div[1]/div[1]/nav/div/div[4]/a", "Business");
            CheckMainPageMenuItem(driver, "//*[@id=\"pageHeader\"]/div/div/div[1]/div[1]/nav/div/div[5]/a", "Opinion");
            CheckMainPageMenuItem(driver, "//*[@id=\"pageHeader\"]/div/div/div[1]/div[1]/nav/div/div[6]/a", "Health");
            CheckMainPageMenuItem(driver, "//*[@id=\"pageHeader\"]/div/div/div[1]/div[1]/nav/div/div[7]/a", "Entertainment");
            CheckMainPageMenuItem(driver, "//*[@id=\"pageHeader\"]/div/div/div[1]/div[1]/nav/div/div[8]/a", "Style");
            CheckMainPageMenuItem(driver, "//*[@id=\"pageHeader\"]/div/div/div[1]/div[1]/nav/div/div[9]/a", "Travel");
            CheckMainPageMenuItem(driver, "//*[@id=\"pageHeader\"]/div/div/div[1]/div[1]/nav/div/div[10]/a", "Sports"); // bug found
            CheckMainPageMenuItem(driver, "//*[@id=\"pageHeader\"]/div/div/div[1]/div[1]/nav/div/div[11]/a", "Video");

            

           

            driver.Close();
        }
    }

}