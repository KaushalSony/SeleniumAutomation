using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumAutomation.Tests.Drivers;
using System;
using System.IO;

namespace SeleniumAutomation.Tests.Tests
{
    public abstract class TestBase
    {
        protected IWebDriver _driver;
        protected string _screenshotPath;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _screenshotPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Screenshots");
            Directory.CreateDirectory(_screenshotPath);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                TakeScreenshot();
            }
            _driver?.Quit();
        }

        protected void TakeScreenshot()
        {
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            var fileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            screenshot.SaveAsFile(Path.Combine(_screenshotPath, fileName));
        }

        protected void Log(string message)
        {
            TestContext.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
        }
    }
} 