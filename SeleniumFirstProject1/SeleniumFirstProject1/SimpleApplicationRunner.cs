using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumFirstProject1
{
    public class SimpleApplicationRunner
    {
        public static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://github.com");


            string searchPhrase = "selenium";

            IWebElement searchInput = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/header/div/div[2]/div/div/qbsearch-input/div[1]/button/span"));
            

            searchInput.Click();

            IWebElement searchInput2 = driver.FindElement(By.XPath("//*[@id=\"query-builder-test\"]"));
            searchInput2.SendKeys("Selenium");
            searchInput2.SendKeys(Keys.Enter);

            IList<string> actualItems = driver.FindElements(By.CssSelector(".repo-list-item"))
                .Select(item => item.Text.ToLower())
                .ToList();
            IList<string> expectedItems = actualItems
                .Where(item => item.Contains(searchPhrase))
                .ToList();
            Assert.AreEqual(expectedItems, actualItems);    

            //Assert.(actualItems.All(item => item.ToLower().Contains("invalid search phrase")));

            driver.Quit();
        }
    }
}
