using JustM79.Components.Impl;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace JustM79.Pages.Impl
{
    class M79SearchResultsPage : M79WebPage
    {
        private static By SearchResultItemSelector => By.CssSelector("[class='item'] h3");
        private IList<SearchResultItemComponent> SearchResultsItems => FindElements(SearchResultItemSelector)
            .Select(element => new SearchResultItemComponent(element))
            .ToList();

        public M79SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public IList<string> SearchResultsItemsText() => SearchResultsItems
            .Select(item => item.Text)
            .ToList();

        public IList<string> SearchResultsItemsWithText(string searchPhrase) => SearchResultsItems
            .Where(item => item.ContainsSearchPhrase(searchPhrase))
            .Select(item => item.Text)
            .ToList();
    }
}