using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Support.UI;

namespace JustM79
{
    public class M79TestWithWaits
    {
        private const string SearchPhrase = "iphone";

        private static IWebDriver driver;

        private static WebDriverWait wait;

        [OneTimeSetUp]
        public static void SetUpDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        [OneTimeSetUp]
        public static void SetUpWait() => wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));



        [Test]

        public void CheckM79Search()
        {
            driver.Navigate().GoToUrl("https://m79.lv/");

            string searchPhrase = "iphone";

            IWebElement searchInput = driver.FindElement(By.CssSelector("#SearchForm > span > input.form-control.category-hints.tt-input"));

            searchInput.Click();
            searchInput.SendKeys(SearchPhrase);
            searchInput.SendKeys(Keys.Enter);

            var actualItems = driver.FindElements(By.CssSelector("[class='item'] h3"))
                .Select(item => item.Text.ToLower())
                .ToList();
            var expectedItems = actualItems
                .Where(item => item.Contains(searchPhrase))
                .ToList();

            SwitchOffImplicitWait();

            Assert.True(IsElementVisibleExplicitWait(By.CssSelector("[class='item'] h3")));
            Assert.False(IsElementVisibleExplicitWait(By.CssSelector("#invalid")));


            Assert.AreEqual(expectedItems, actualItems);
        }
        [OneTimeTearDown]
        public static void TearDownDriver() => driver.Quit();

        private static bool IsElementVisible(By selector)
        {
            try
            {
                return driver.FindElement(selector).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }

        private static bool IsElementVisibleExplicitWait(By selector)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            try
            {
                return wait.Until(d => driver.FindElement(selector).Displayed);
            }
            finally
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString());
            }
        }

        private static void SwitchOffImplicitWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}
