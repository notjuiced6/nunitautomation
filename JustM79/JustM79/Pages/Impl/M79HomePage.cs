using OpenQA.Selenium;
using JustM79.Components.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustM79.Pages.Impl
{
    public class M79HomePage : M79WebPage
    {
        public static readonly By SearchComponentSelector = By.XPath("//*[@id=\"query-builder-test\"]");

        public SearchComponent SearchComponent => new SearchComponent(FindElement(SearchComponentSelector));

        public M79HomePage(IWebDriver driver) : base(driver)
        {

        }
    }
}
