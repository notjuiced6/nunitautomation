using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustM79.Components.Impl
{
    public class SearchResultItemComponent : WebComponent
    {
        private static readonly By TitleSelector = By.CssSelector("[itemprop=\"name\"]");
        private static readonly By DescriptionSelector = By.CssSelector(".mb-1");

        public SearchResultItemComponent(IWebElement rootElement) : base(rootElement)
        {
        }

        public bool ContainsSearchPhrase(string searchPhrase) =>
            ContainsTextIgnoringCase(searchPhrase, TitleSelector) || ContainsTextIgnoringCase(searchPhrase, DescriptionSelector);

        private bool ContainsTextIgnoringCase(string searchPhrase, By selector) =>
            FindElement(selector).Text.ToLower().Contains(searchPhrase);
    }
}
