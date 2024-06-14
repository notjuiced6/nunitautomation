using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Components.Impl
{
    class SearchResultItemComponent : WebComponent
    {
        private static readonly By TitleSelector = By.CssSelector("[class$='search-title']");
        private static readonly By DescriptionSelector = By.CssSelector("div.Box-sc-g0xbh4-0.LjnbQ");
        public SearchResultItemComponent(IWebElement rootElement) : base(rootElement)
        {

        }

        public bool ContainsSearchPhrase(string searchPhrase) => ContainsTextIgnoringCase(searchPhrase, TitleSelector) ||
                ContainsTextIgnoringCase(searchPhrase, DescriptionSelector);
        private bool ContainsTextIgnoringCase(string searchPhrase, By selector) => FindElement(selector).Text.ToLower().Contains(searchPhrase);
    }

}
