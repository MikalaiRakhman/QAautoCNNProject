using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace QAautoCNNProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://edition.cnn.com/";

            Thread.Sleep(3000);

            IWebElement acceptAllCoockiesButtom = driver.FindElement(By.XPath("//*[@id=\"onetrust-accept-btn-handler\"]"));

            acceptAllCoockiesButtom.Click();

            string title = driver.Title;

            Console.WriteLine("Test case 1. This page is opened: {0}",title == "Breaking News, Latest News and Videos | CNN");

            string newUrl = driver.Url;
            newUrl = "https://edition.cnn.com/";



            Console.WriteLine("Test case 2. Link is valid: {0}", newUrl == "https://edition.cnn.com/");


            driver.Close();
        }
    }

}