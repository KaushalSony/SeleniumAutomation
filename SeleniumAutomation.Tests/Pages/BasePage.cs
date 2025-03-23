using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Tests.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;
        protected readonly WebDriverWait _wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        protected void WaitForElementVisible(By locator)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected void WaitForElementClickable(By locator)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        protected IWebElement FindElement(By locator)
        {
            WaitForElementVisible(locator);
            return _driver.FindElement(locator);
        }

        protected string GetCurrentUrl()
        {
            return _driver.Url;
        }
    }
} 