using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverUtility.Classes;

namespace WebDriverUtility
{
    // Selenium custom wrapper's new version
    // with different (more simple) syntax
    public class SUtility : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly string driverLocation = "./WebDrivers/";
        private readonly bool hideConsole = false;
        // Contains element behaviours
        public SElement Element { get; set; }

        // Contains actions for element and not only
        public SAction Action { get; set; }

        // Initializing current webdrivers.
        // Currently we have two webdrivers installed -
        // Chorme and Firefox. 
        public SUtility(Browser browser, bool hideConsole)
        {
            this.hideConsole = hideConsole;

            switch (browser)
            {
                case Browser.Chrome:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--window-size=950,700");
                    ChromeDriverService driverService = ChromeDriverService.CreateDefaultService(driverLocation);
                    driverService.HideCommandPromptWindow = hideConsole;
                    driver = new ChromeDriver(driverService, chromeOptions);
                    break;
                case Browser.Firefox:
                    driver = new FirefoxDriver(driverLocation);
                    break;
            }

            Element = new SElement(driver);
            Action = new SAction(driver);
        }

        public void Dispose()
        {
            //Element.Dispose();
            //Action.Dispose();
            driver.Quit();
            //driver.Dispose();
        }
    }    
}
