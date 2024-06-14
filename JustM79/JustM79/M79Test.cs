using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using JustM79.Pages.Impl;

namespace JustM79
{
    public class M79Test
    {
        private const string SearchPhrase = "iphone";

        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void SetUpDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        
        [Test]

        public void CheckM79Search()
        {
            driver.Navigate().GoToUrl("https://m79.lv/");

            var homePage = new M79HomePage(driver);

            var searchResultsPage = new M79SearchResultsPage(driver);

            homePage.SearchComponent.PerformSearch(SearchPhrase);


            var actualItems = searchResultsPage.SearchResultsItemsText();
            var expectedItems = searchResultsPage.SearchResultsItemsWithText(SearchPhrase);

            Assert.AreEqual(expectedItems, actualItems);
        }
        [OneTimeTearDown]
        public static void TearDownDriver() => driver.Quit();
    }   
}
