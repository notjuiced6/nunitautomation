using iText.Layout;
using iText.StyledXmlParser.Jsoup.Select;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Components.Impl
{
    public class SearchComponent2 : WebComponent
    {
        public SearchComponent2(IWebElement rootElement) : base(rootElement)
        {
        }

        public void ClickOnInitialComponent()
        {
            By selector = By.XPath("//qbsearch-input/div[1]/button");
            var initialElement = FindElement(selector);
            initialElement.Click();
        }

    }
}
