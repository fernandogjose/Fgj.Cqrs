using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace Fgj.Cqrs.IntegrationTest.Extensions
{
    public static class WebDriverExtension
    {
        public static void LoadPage(this IWebDriver webDriver, TimeSpan waitFor, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = waitFor;
            webDriver.Navigate().GoToUrl(url);
        }

        public static string GetHtml(this IWebDriver webDriver, By by)
        {
            ReadOnlyCollection<IWebElement> webElements = webDriver.FindElements(by);
            return webElements.Count > 0
                ? webElements[0].GetAttribute("innerHTML")
                : "";
        }

        public static void ButtonClick(this IWebDriver webDriver, string id)
        {
            ReadOnlyCollection<IWebElement> webElements = webDriver.FindElements(By.Id(id));
            if (webElements.Count > 0)
            {
                webElements[0].Click();
            }
        }

        public static void AlertClickOk(this IWebDriver webDriver)
        {
            webDriver.SwitchTo().Alert().Accept();
        }

        public static void InputFill(this IWebDriver webDriver, string id, string value)
        {
            IWebElement webElement = webDriver.FindElement(By.Id(id));
            webElement.SendKeys(value);
        }

        public static void SelectByValue(this IWebDriver webDriver, string id, string value)
        {
            IWebElement webElement = webDriver.FindElement(By.Id(id));
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByValue(value);
        }
    }
}