using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverUtility
{
    // Selenium custom wrapper, currently with two 
    // webdrivers - Chrome and Firefox
    public class Utility : IDisposable
    {
        private IWebDriver driver;

        public Utility(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--window-size=950,700");
                    driver = new ChromeDriver("./WebDrivers/", chromeOptions);
                    break;
                case Browser.Firefox:
                    driver = new FirefoxDriver("./WebDrivers/");
                    break;
            }
        }

        // Opens up page by given URL
        public void GoToURL(string url)
        {
            driver.Url = url;
        }

        /// <summary>
        /// Clicks element
        /// </summary>
        /// <param name="byType"> The element type </param>
        /// <param name="element"> Element identificator </param>
        public void ClickElement(ByType byType, string element)
        {
            By by = GetBy(byType, element);
            driver.FindElement(by).Click();
        }

        /// <summary>
        /// Simulates text writing into element
        /// </summary>
        /// <param name="byType"> The element type </param>
        /// <param name="element"> Element identificator </param>
        /// <param name="content"> Text content of element </param>
        public void TypeTextIntoElement(ByType byType, string element, string content)
        {
            By by = GetBy(byType, element);
            driver.FindElement(by).SendKeys(content);
        }


        public void ClickElementById(string elementId) =>
            driver.FindElement(By.Id(elementId)).Click();

        public void WriteToTextBoxById(string elementId, string content) =>
            driver.FindElement(By.Id(elementId)).SendKeys(content);

        public void Wait(int seconds) =>
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(seconds);

        private By GetBy(ByType byType, string element)
        {
            By by = null;
            switch (byType)
            {
                case ByType.Id:
                    by = By.Id(element);
                    break;
                case ByType.Name:
                    by = By.Name(element);
                    break;
                case ByType.Tag:
                    by = By.TagName(element);
                    break;
                case ByType.Class:
                    by = By.ClassName(element);
                    break;
            }
            return by;
        }

        public void Dispose()
        {
            driver.Close();
            driver.Dispose();
        }
    }

    public enum ByType
    {
        Id,
        Name,
        Tag,
        Class
    }

    public enum Browser
    {
        Chrome,
        Firefox
    }
}
