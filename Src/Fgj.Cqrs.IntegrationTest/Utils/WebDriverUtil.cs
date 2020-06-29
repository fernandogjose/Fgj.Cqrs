using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Fgj.Cqrs.IntegrationTest.Utils
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(BrowserUtil browser, string pathDriver, bool headless)
        {
            IWebDriver webDriver = null;

            switch (browser)
            {
                case BrowserUtil.Firefox:
                    FirefoxOptions optionsFF = new FirefoxOptions();
                    if (headless)
                        optionsFF.AddArgument("--headless");

                    webDriver = new FirefoxDriver(pathDriver, optionsFF);
                    break;

                case BrowserUtil.Chrome:
                    ChromeOptions optionsChr = new ChromeOptions();
                    if (headless)
                        optionsChr.AddArgument("--headless");

                    webDriver = new ChromeDriver(pathDriver, optionsChr);
                    break;
            }

            return webDriver;
        }
    }
}