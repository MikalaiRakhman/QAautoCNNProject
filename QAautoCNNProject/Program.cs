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

            Thread.Sleep(2000);

            // Accept all coockies
            IWebElement acceptAllCoockiesButtom = driver.FindElement(By.XPath("//*[@id=\"onetrust-accept-btn-handler\"]"));
            acceptAllCoockiesButtom.Click();
            Thread.Sleep(2000);


            static void CheckMainPageMenuItem(IWebDriver driver, string keyWord)
            {
                string xPath = $"//a[@class='header__nav-item-link'][contains(@data-zjs-component_text, '{keyWord}')]";
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
            
            CheckMainPageMenuItem(driver, "US");
            CheckMainPageMenuItem(driver, "World");
            CheckMainPageMenuItem(driver, "Politics");
            CheckMainPageMenuItem(driver, "Business");
            CheckMainPageMenuItem(driver, "Opinion");
            CheckMainPageMenuItem(driver, "Health");
            CheckMainPageMenuItem(driver, "Entertainment");
            CheckMainPageMenuItem(driver, "Style");
            CheckMainPageMenuItem(driver, "Travel");
            CheckMainPageMenuItem(driver, "Sports"); // bug found
            CheckMainPageMenuItem(driver, "Video");

            

           

            driver.Close();
        }
    }

}