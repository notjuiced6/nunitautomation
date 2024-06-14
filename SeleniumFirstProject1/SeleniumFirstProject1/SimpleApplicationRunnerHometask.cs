using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01SimpleApplicationHomeTask
{
    public class SimpleApplicationHomeTaskRunner
    {
        public static void Main2(string[] args)
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