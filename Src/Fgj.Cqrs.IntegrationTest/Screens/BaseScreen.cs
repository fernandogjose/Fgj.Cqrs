using Fgj.Cqrs.IntegrationTest.Utils;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;

namespace Fgj.Cqrs.IntegrationTest.Screens
{
    public class BaseScreen
    {
        protected static IWebDriver _webDriver;
        protected IConfiguration _configuration;

        public BaseScreen()
        {
            if (_webDriver == null)
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                _configuration = builder.Build();

                _webDriver = WebDriverFactory.CreateWebDriver(BrowserUtil.Chrome, $"{Directory.GetCurrentDirectory()}\\Driver", false);
                _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            }
        }

        public void CloseScreen()
        {
            _webDriver.Quit();
            _webDriver = null;
        }

        public void TakeScreenshot(string folderPath, string archiveName)
        {
            if (string.IsNullOrEmpty(folderPath))
            {
                folderPath = $@"{Directory.GetCurrentDirectory()}\Imgs\Tests\";
            }

            if (string.IsNullOrEmpty(archiveName))
            {
                archiveName = DateTime.Now.ToString("ddMMyyyyhhmm") + ".png";
            }

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            ITakesScreenshot takesScreenshot = _webDriver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile(folderPath + archiveName, ScreenshotImageFormat.Png);
        }

        public void Wait5Seconds()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }
    }
}