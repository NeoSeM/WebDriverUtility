using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverUtility.Classes
{
    public class SElement : IDisposable
    {
        private IWebDriver driver;

        public SElement(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Finds Element by Id
        /// </summary>
        /// <param name="id"> Element's identificator</param>
        /// <returns> Possible actions among found element </returns>
        public SAction ById(string id) => By(ByType.Id, id);

        /// <summary>
        /// Finds Element by Name
        /// </summary>
        /// <param name="name"> Element's identificator</param>
        /// <returns> Possible actions among found element </returns>
        public SAction ByName(string name) => By(ByType.Name, name);

        /// <summary>
        /// Finds Element by TagName
        /// </summary>
        /// <param name="tagName"> Element's identificator</param>
        /// <returns> Possible actions among found element </returns>
        public SAction ByTagName(string tagName) => By(ByType.Tag, tagName);

        /// <summary>
        /// Finds Element by ClassName
        /// </summary>
        /// <param name="className"> Element's identificator</param>
        /// <returns> Possible actions among found element </returns>
        public SAction ByClassName(string className) => By(ByType.Class, className);

        // Returns By type for given element
        private SAction By(ByType byType, string name)
        {
            By by = null;
            switch (byType)
            {
                case ByType.Id:
                    by = OpenQA.Selenium.By.Id(name);
                    break;
                case ByType.Name:
                    by = OpenQA.Selenium.By.Name(name);
                    break;
                case ByType.Tag:
                    by = OpenQA.Selenium.By.TagName(name);
                    break;
                case ByType.Class:
                    by = OpenQA.Selenium.By.ClassName(name);
                    break;
            }
            return new SAction(driver, by);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
