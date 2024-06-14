using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTestProject.Components.Impl;
using SeleniumTestProject.Pages.Impl;
using System.Security.Cryptography.X509Certificates;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTestProject
{
    public class GitHubTest
    {
        private const string SearchPhrase = "selenium";

        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void SetUpDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void CheckGitHubSearch()
        {
            driver.Navigate().GoToUrl("https://github.com");


            var homePage = new HomePage(driver);
            var homePage2 = new HomePage(driver);
            var searchResultsPage = new SearchResultsPage(driver);


            homePage2.SearchComponent3.ClickOnInitialComponent();
            homePage.SearchComponent.PerformSearch(SearchPhrase);


            var actualItems = searchResultsPage.SearchResultsItemsText();
            var expectedItems = searchResultsPage.SearchResultsItemsWithText(SearchPhrase);

            Assert.AreEqual(expectedItems, actualItems);

        }
        [OneTimeTearDown]
        public static void TearDownDriver()
        {
            driver.Quit();
        }
    }
}
