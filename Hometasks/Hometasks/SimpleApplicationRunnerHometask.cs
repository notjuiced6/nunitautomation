using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using NUnit.Framework;


namespace _01SimpleApplicationHomeTask
{
    public class SimpleApplicationRunnerHometask

    {
        public static void Main(string[] args)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://m79.lv/");

            string searchPhrase = "iphone";

            IWebElement searchInput = driver.FindElement(By.CssSelector("#SearchForm > span > input.form-control.category-hints.tt-input"));

            searchInput.Click();
            searchInput.SendKeys("iphone");
            searchInput.SendKeys(Keys.Enter);

            IList<string> actualItems = driver.FindElements(By.CssSelector("[class='item'] h3"))
                .Select(item => item.Text.ToLower())
                .ToList();
            IList<string> expectedItems = actualItems
                .Where(item => item.Contains(searchPhrase))
                .ToList();

            Assert.AreEqual(expectedItems, actualItems);

            driver.Quit();
        }
    }
}