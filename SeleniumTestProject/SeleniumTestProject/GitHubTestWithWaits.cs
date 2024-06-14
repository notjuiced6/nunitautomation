using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumTestProject.Pages.Impl;
using System.Security.Cryptography.X509Certificates;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTestProject
{
    public class GitHubTestWithWaits
    {
        private const string SearchPhrase = "selenium";

        private static IWebDriver driver;

        private static WebDriverWait wait;

        [OneTimeSetUp]
        public static void SetUpDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [OneTimeSetUp]

        public static void SetUpWait() => wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        [Test]
        public void CheckGitHubSearch()
        {
            driver.Navigate().GoToUrl("https://github.com");

            IWebElement searchInput = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/header/div/div[2]/div/div/qbsearch-input/div[1]/button/span"));
            
            searchInput.Click();

            IWebElement searchInput2 = driver.FindElement(By.XPath("//*[@id=\"query-builder-test\"]"));
            
            searchInput2.SendKeys(SearchPhrase);

            searchInput2.SendKeys(Keys.Enter);

            SwitchOffImplicitWait();

            Assert.True(IsElementVisibleExplicitWait(By.CssSelector(".repo-list-item")));

            var actualItems = driver.FindElements(By.CssSelector(""))
                .Select(item => item.Text.ToLower())
                .ToList();
            var expectedItems = actualItems
                .Where(item => item.Contains(SearchPhrase))
                .ToList();
            //Assert.(actualItems.All(item => item.ToLower().Contains("invalid search phrase")));
        }
        [OneTimeTearDown]
        public static void TearDownDriver()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            driver.Quit();
        }

        private bool IsElementVisible(By selector)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            try
            {
                return driver.FindElement(selector).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            finally
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString());
            }
        }

        private bool IsElementVisibleExplicitWait(By selector)
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