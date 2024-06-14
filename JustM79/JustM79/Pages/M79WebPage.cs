using OpenQA.Selenium;
using System.Collections.Generic;

namespace JustM79.Pages
{
        public class M79WebPage
        {
            private readonly IWebDriver driver;

            protected M79WebPage(IWebDriver driver) => this.driver = driver;

            protected IWebElement FindElement(By selector) => driver.FindElement(selector);

            protected IList<IWebElement> FindElements(By selector) => driver.FindElements(selector);
        }


}