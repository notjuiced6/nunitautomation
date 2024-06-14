using OpenQA.Selenium;
using SeleniumTestProject.Components.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Pages.Impl
{
    public class HomePage : WebPage
    {

        public static readonly By SearchComponentSelector2 = By.XPath("//qbsearch-input/div[1]/button");
        public static readonly By SearchComponentSelector = By.XPath("//*[@id=\"query-builder-test\"]");
        public HomePage(IWebDriver driver) : base (driver)
        {

        }

        public SearchComponent SearchComponent => new SearchComponent(FindElement(SearchComponentSelector));
        public SearchComponent2 SearchComponent3 => new SearchComponent2(FindElement(SearchComponentSelector2));

        //public void PerformSearch(string searchPhrase)
        //{
            //searchInput.Click();
            //TimeSpan.FromSeconds(5);
            //searchInput2.SendKeys(searchPhrase);
            //searchInput2.SendKeys(Keys.Enter);            
        //}
    }
}
