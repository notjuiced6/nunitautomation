﻿using OpenQA.Selenium;
using SeleniumTestProject.Components.Impl;


namespace SeleniumTestProject.Pages.Impl
{
    public class SearchResultsPage : WebPage
    {
        private static readonly By SearchResultItemSelector = By.CssSelector(".repo-list-item");

        private IList<SearchResultItemComponent> SearchResultsItems => FindElements(SearchResultItemSelector)
            .Select(element => new SearchResultItemComponent(element))
            .ToList();

        public SearchResultsPage(IWebDriver driver) : base(driver)
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