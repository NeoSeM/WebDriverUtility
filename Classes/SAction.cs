using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverUtility.Classes
{
    public class SAction : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly By by;

        public SAction(IWebDriver driver)
        {
            this.driver = driver;
        }

        public SAction(IWebDriver webDriver, By by)
        {
            driver = webDriver;
            this.by = by;
        }

        /// <summary>
        /// Opens up page by given URL
        /// </summary>
        /// <param name="url"></param>
        public void Go2URL(string url) => driver.Url = url;

        /// <summary>
        /// Clicks Element
        /// </summary>
        public void Click() => driver.FindElement(by).Click();

        /// <summary>
        /// Simulates text typeing
        /// </summary>
        /// <param name="text"></param>
        public void WriteText(string text) => driver.FindElement(by).SendKeys(text);

        /// <summary>
        /// Returns Inner text of element 
        /// without leading or trailing whitespace
        /// </summary>
        /// <returns></returns>
        public string InnerHtml() => driver.FindElement(by).Text;

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
